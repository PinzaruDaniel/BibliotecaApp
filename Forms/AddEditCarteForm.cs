using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Forms
{
    public partial class AddEditCarteForm : Form
    {
        private readonly int? _carteId;

        public AddEditCarteForm(int? carteId = null)
        {
            _carteId = carteId;
            InitializeComponent();
            this.Text        = _carteId.HasValue ? "Editare Carte" : "Adăugare Carte Nouă";
            lblFormTitle.Text = this.Text;
            LoadAutori();
            if (_carteId.HasValue) LoadCarte();
        }

        private void LoadAutori()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery(
                    "SELECT AutorID, Prenume+' '+Nume AS Autor FROM Autori ORDER BY Autor");
                cmbAutor.DataSource    = dt;
                cmbAutor.DisplayMember = "Autor";
                cmbAutor.ValueMember   = "AutorID";
            }
            catch { }
        }

        private void LoadCarte()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Carti WHERE CarteID = @id",
                    new SqlParameter("@id", _carteId!));
                if (dt.Rows.Count == 0) return;
                var r = dt.Rows[0];
                txtTitlu.Text     = r["Titlu"].ToString()!;
                txtISBN.Text      = r["ISBN"].ToString()!;
                txtAn.Text        = r["AnPublicare"].ToString()!;
                nudExemplare.Value = Convert.ToInt32(r["NrExemplare"]);
                cmbAutor.SelectedValue = r["AutorID"];
                int idx = cmbGen.Items.IndexOf(r["Gen"].ToString()!);
                cmbGen.SelectedIndex = idx >= 0 ? idx : 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void txtISBN_Leave(object sender, EventArgs e) => ValidateISBN();
        private void txtAn_Leave(object sender, EventArgs e)   => ValidateAn();

        private bool ValidateISBN()
        {
            bool ok = Regex.IsMatch(txtISBN.Text.Trim(),
                @"^(978|979)-[\d\-]{10,16}$|^\d{10}$|^\d{13}$");
            txtISBN.BackColor = ok ? Color.White : Color.FromArgb(255, 230, 230);
            if (!ok) lblError.Text = "ISBN invalid! Format: 978-xxx-xx-xxxx-x sau 13 cifre.";
            return ok;
        }

        private bool ValidateAn()
        {
            bool ok = int.TryParse(txtAn.Text, out int an) && an >= 1000 && an <= DateTime.Now.Year;
            txtAn.BackColor = ok ? Color.White : Color.FromArgb(255, 230, 230);
            if (!ok) lblError.Text = $"Anul trebuie să fie între 1000 și {DateTime.Now.Year}.";
            return ok;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrWhiteSpace(txtTitlu.Text)) { lblError.Text = "Titlul este obligatoriu!"; return; }
            if (!ValidateISBN() || !ValidateAn()) return;

            try
            {
                int autorId = Convert.ToInt32(cmbAutor.SelectedValue);
                int an      = int.Parse(txtAn.Text);
                string gen  = cmbGen.SelectedItem!.ToString()!;
                int nrEx    = (int)nudExemplare.Value;

                if (_carteId.HasValue)
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Carti SET Titlu=@t,AutorID=@a,ISBN=@i,AnPublicare=@an,Gen=@g,NrExemplare=@ne WHERE CarteID=@id",
                        new SqlParameter("@t",  txtTitlu.Text.Trim()),
                        new SqlParameter("@a",  autorId),
                        new SqlParameter("@i",  txtISBN.Text.Trim()),
                        new SqlParameter("@an", an),
                        new SqlParameter("@g",  gen),
                        new SqlParameter("@ne", nrEx),
                        new SqlParameter("@id", _carteId));
                else
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Carti(Titlu,AutorID,ISBN,AnPublicare,Gen,NrExemplare,NrDisponibil) VALUES(@t,@a,@i,@an,@g,@ne,@nd)",
                        new SqlParameter("@t",  txtTitlu.Text.Trim()),
                        new SqlParameter("@a",  autorId),
                        new SqlParameter("@i",  txtISBN.Text.Trim()),
                        new SqlParameter("@an", an),
                        new SqlParameter("@g",  gen),
                        new SqlParameter("@ne", nrEx),
                        new SqlParameter("@nd", nrEx));

                MessageBox.Show(_carteId.HasValue ? "Carte actualizată!" : "Carte adăugată!",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { lblError.Text = $"Eroare: {ex.Message}"; }
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void AddEditCarteForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
        }
    }
}
