using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Forms
{
    public partial class AddEditImprumutForm : Form
    {
        private readonly int? _imprumutId;

        public AddEditImprumutForm(int? imprumutId = null)
        {
            _imprumutId = imprumutId;
            InitializeComponent();
            this.Text        = _imprumutId.HasValue ? "Editare Împrumut" : "Înregistrare Împrumut Nou";
            lblFormTitle.Text = this.Text;
            LoadCarti();
            if (_imprumutId.HasValue) LoadImprumut();
        }

        private void LoadCarti()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery(
                    "SELECT CarteID, Titlu FROM Carti WHERE NrDisponibil > 0 ORDER BY Titlu");
                cmbCarte.DataSource    = dt;
                cmbCarte.DisplayMember = "Titlu";
                cmbCarte.ValueMember   = "CarteID";
            }
            catch { }
        }

        private void LoadImprumut()
        {
            try
            {
                var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Imprumuturi WHERE ImprumutID=@id",
                    new SqlParameter("@id", _imprumutId!));
                if (dt.Rows.Count == 0) return;
                var r = dt.Rows[0];
                cmbCarte.SelectedValue     = r["CarteID"];
                txtNumeCititor.Text        = r["NumeCititor"].ToString()!;
                txtCNP.Text                = r["CNPCititor"].ToString()!;
                txtTelefon.Text            = r["TelefonCititor"].ToString()!;
                dtpImprumut.Value          = Convert.ToDateTime(r["DataImprumut"]);
                dtpTermen.Value            = Convert.ToDateTime(r["DataReturnareEstimata"]);
                nudTarif.Value             = Convert.ToDecimal(r["TarifPenalitate"]);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void txtCNP_Leave(object sender, EventArgs e)
        {
            bool ok = Regex.IsMatch(txtCNP.Text.Trim(), @"^\d{13}$");
            txtCNP.BackColor = ok ? Color.White : Color.FromArgb(255, 230, 230);
            lblError.Text    = ok ? "" : "CNP-ul trebuie să conțină exact 13 cifre!";
        }

        private void txtTelefon_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text)) return;
            bool ok = Regex.IsMatch(txtTelefon.Text.Trim(), @"^(\+4|0)\d{9}$");
            txtTelefon.BackColor = ok ? Color.White : Color.FromArgb(255, 230, 230);
            if (!ok) lblError.Text = "Format telefon invalid! Ex: 0721000000";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrWhiteSpace(txtNumeCititor.Text))
            { lblError.Text = "Numele cititorului este obligatoriu!"; return; }
            if (!Regex.IsMatch(txtCNP.Text.Trim(), @"^\d{13}$"))
            { lblError.Text = "CNP invalid – trebuie să conțină exact 13 cifre!"; return; }
            if (dtpTermen.Value.Date <= dtpImprumut.Value.Date)
            { lblError.Text = "Termenul de returnare trebuie să fie după data împrumutului!"; return; }

            try
            {
                int carteId = Convert.ToInt32(cmbCarte.SelectedValue);
                object telDb = string.IsNullOrWhiteSpace(txtTelefon.Text)
                    ? DBNull.Value : (object)txtTelefon.Text.Trim();

                if (_imprumutId.HasValue)
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Imprumuturi SET CarteID=@c,NumeCititor=@n,CNPCititor=@cnp," +
                        "TelefonCititor=@t,DataImprumut=@di,DataReturnareEstimata=@dr,TarifPenalitate=@tp " +
                        "WHERE ImprumutID=@id",
                        new SqlParameter("@c",   carteId),
                        new SqlParameter("@n",   txtNumeCititor.Text.Trim()),
                        new SqlParameter("@cnp", txtCNP.Text.Trim()),
                        new SqlParameter("@t",   telDb),
                        new SqlParameter("@di",  dtpImprumut.Value.Date),
                        new SqlParameter("@dr",  dtpTermen.Value.Date),
                        new SqlParameter("@tp",  nudTarif.Value),
                        new SqlParameter("@id",  _imprumutId));
                else
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Imprumuturi(CarteID,NumeCititor,CNPCititor,TelefonCititor," +
                        "DataImprumut,DataReturnareEstimata,TarifPenalitate) VALUES(@c,@n,@cnp,@t,@di,@dr,@tp)",
                        new SqlParameter("@c",   carteId),
                        new SqlParameter("@n",   txtNumeCititor.Text.Trim()),
                        new SqlParameter("@cnp", txtCNP.Text.Trim()),
                        new SqlParameter("@t",   telDb),
                        new SqlParameter("@di",  dtpImprumut.Value.Date),
                        new SqlParameter("@dr",  dtpTermen.Value.Date),
                        new SqlParameter("@tp",  nudTarif.Value));
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Carti SET NrDisponibil = NrDisponibil - 1 WHERE CarteID=@c",
                        new SqlParameter("@c", carteId));
                }

                MessageBox.Show("Împrumut salvat cu succes!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { lblError.Text = $"Eroare: {ex.Message}"; }
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void AddEditImprumutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
        }
    }
}
