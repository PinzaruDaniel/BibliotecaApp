using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Forms
{
    public partial class AddEditAutorForm : Form
    {
        private readonly int? _autorId;

        public AddEditAutorForm(int? autorId = null)
        {
            _autorId = autorId;
            InitializeComponent();
            this.Text = _autorId.HasValue ? "Editare Autor" : "Adăugare Autor Nou";
            lblFormTitle.Text = this.Text;
            if (_autorId.HasValue) LoadAutor();
        }

        private void LoadAutor()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery(
                    "SELECT * FROM Autori WHERE AutorID = @id",
                    new SqlParameter("@id", _autorId!));
                if (dt.Rows.Count == 0) return;
                var r = dt.Rows[0];
                txtNume.Text          = r["Nume"].ToString()!;
                txtPrenume.Text       = r["Prenume"].ToString()!;
                txtNationalitate.Text = r["Nationalitate"].ToString()!;
                txtBiografie.Text     = r["Biografie"].ToString()!;
                if (r["DataNasterii"] != DBNull.Value)
                {
                    chkNastere.Checked = true;
                    dtpNastere.Value   = Convert.ToDateTime(r["DataNasterii"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void chkNastere_CheckedChanged(object sender, EventArgs e)
        {
            dtpNastere.Enabled = chkNastere.Checked;
        }

        private void txtNume_Leave(object sender, EventArgs e)
        {
            ValidateNameField(txtNume, "Numele");
        }

        private void txtPrenume_Leave(object sender, EventArgs e)
        {
            ValidateNameField(txtPrenume, "Prenumele");
        }

        private bool ValidateNameField(TextBox tb, string fieldName)
        {
            bool ok = Regex.IsMatch(tb.Text.Trim(),
                @"^[A-Za-zÀ-ÿăîâșțĂÎÂȘȚ\s\-'.]{2,100}$");
            tb.BackColor   = ok ? Color.White : Color.FromArgb(255, 230, 230);
            lblError.Text  = ok ? "" : $"{fieldName} conține caractere nepermise sau este prea scurt!";
            return ok;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtNume.Text) || string.IsNullOrWhiteSpace(txtPrenume.Text))
            { lblError.Text = "Câmpurile Nume și Prenume sunt obligatorii!"; return; }

            if (!ValidateNameField(txtNume, "Numele") || !ValidateNameField(txtPrenume, "Prenumele"))
                return;

            try
            {
                object dataDb = chkNastere.Checked ? (object)dtpNastere.Value.Date : DBNull.Value;
                object bioDb  = string.IsNullOrWhiteSpace(txtBiografie.Text) ? DBNull.Value : (object)txtBiografie.Text.Trim();

                if (_autorId.HasValue)
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Autori SET Nume=@n, Prenume=@p, DataNasterii=@d, Nationalitate=@nat, Biografie=@b WHERE AutorID=@id",
                        new SqlParameter("@n",   txtNume.Text.Trim()),
                        new SqlParameter("@p",   txtPrenume.Text.Trim()),
                        new SqlParameter("@d",   dataDb),
                        new SqlParameter("@nat", txtNationalitate.Text.Trim()),
                        new SqlParameter("@b",   bioDb),
                        new SqlParameter("@id",  _autorId));
                else
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Autori (Nume, Prenume, DataNasterii, Nationalitate, Biografie) VALUES (@n,@p,@d,@nat,@b)",
                        new SqlParameter("@n",   txtNume.Text.Trim()),
                        new SqlParameter("@p",   txtPrenume.Text.Trim()),
                        new SqlParameter("@d",   dataDb),
                        new SqlParameter("@nat", txtNationalitate.Text.Trim()),
                        new SqlParameter("@b",   bioDb));

                MessageBox.Show(_autorId.HasValue ? "Autor actualizat cu succes!" : "Autor adăugat cu succes!",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { lblError.Text = $"Eroare: {ex.Message}"; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddEditAutorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
        }
    }
}
