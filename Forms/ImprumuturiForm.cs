using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BibliotecaApp.Forms
{
    public partial class ImprumuturiForm : Form
    {
        private DataTable _fullData = new();

        public ImprumuturiForm()
        {
            Text = "Împrumuturi";
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _fullData = DatabaseHelper.ExecuteQuery(@"
                    SELECT i.ImprumutID,
                           c.Titlu AS Carte,
                           i.NumeCititor,
                           i.CNPCititor,
                           i.TelefonCititor,
                           i.DataImprumut,
                           i.DataReturnareEstimata,
                           i.DataReturnareReala,
                           CASE i.Returnat WHEN 1 THEN 'Da' ELSE 'Nu' END AS Returnat,
                           i.TarifPenalitate,
                           DATEDIFF(day, i.DataReturnareEstimata,
                               CASE WHEN i.DataReturnareReala IS NOT NULL
                                    THEN i.DataReturnareReala
                                    ELSE CAST(GETDATE() AS DATE) END) AS ZileIntarziere
                    FROM Imprumuturi i
                    JOIN Carti c ON i.CarteID = c.CarteID
                    ORDER BY i.DataImprumut DESC");

                grid.DataSource = _fullData;
                FormatGrid();

                int active = _fullData.AsEnumerable().Count(r => r["Returnat"].ToString() == "Nu");
                lblSummary.Text =
                    $"   Total: {_fullData.Rows.Count}  |  Active: {active}  |  Returnate: {_fullData.Rows.Count - active}";
                FilterData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void FormatGrid()
        {
            if (grid.Columns.Count == 0) return;
            grid.Columns["ImprumutID"].Width            = 40;  grid.Columns["ImprumutID"].HeaderText            = "ID";
            grid.Columns["Carte"].Width                 = 180; grid.Columns["Carte"].HeaderText                 = "Carte";
            grid.Columns["NumeCititor"].Width           = 150; grid.Columns["NumeCititor"].HeaderText           = "Cititor";
            grid.Columns["CNPCititor"].Width            = 120; grid.Columns["CNPCititor"].HeaderText            = "CNP";
            grid.Columns["TelefonCititor"].Width        = 100; grid.Columns["TelefonCititor"].HeaderText        = "Telefon";
            grid.Columns["DataImprumut"].Width          = 95;  grid.Columns["DataImprumut"].HeaderText          = "Data Împ.";
            grid.Columns["DataReturnareEstimata"].Width = 85;  grid.Columns["DataReturnareEstimata"].HeaderText = "Termen";
            grid.Columns["DataReturnareReala"].Width    = 90;  grid.Columns["DataReturnareReala"].HeaderText    = "Ret. Reală";
            grid.Columns["Returnat"].Width              = 70;  grid.Columns["Returnat"].HeaderText              = "Returnat";
            grid.Columns["TarifPenalitate"].Width       = 55;  grid.Columns["TarifPenalitate"].HeaderText       = "$/zi";
            grid.Columns["ZileIntarziere"].Width        = 75;  grid.Columns["ZileIntarziere"].HeaderText        = "Zile Înt.";
        }

        private void FilterData()
        {
            string q = txtSearch.Text.Trim();
            var rows = _fullData.AsEnumerable();
            if (!string.IsNullOrEmpty(q))
                rows = rows.Where(r =>
                    r["NumeCititor"].ToString()!.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    r["Carte"].ToString()!.Contains(q,       StringComparison.OrdinalIgnoreCase) ||
                    r["CNPCititor"].ToString()!.Contains(q,  StringComparison.OrdinalIgnoreCase));
            if (chkDoarActive.Checked)
                rows = rows.Where(r => r["Returnat"].ToString() == "Nu");
            var list = rows.ToList();
            grid.DataSource = list.Count > 0 ? list.CopyToDataTable() : _fullData.Clone();
        }

        private void grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grid.Rows.Count) return;
            var row = grid.Rows[e.RowIndex];
            if (row.Cells["Returnat"].Value?.ToString() == "Nu" &&
                Convert.ToInt32(row.Cells["ZileIntarziere"].Value ?? 0) > 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new AddEditImprumutForm().ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați un împrumut!", "Atenție"); return; }
            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["ImprumutID"].Value);
            if (new AddEditImprumutForm(id).ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați un împrumut!", "Atenție"); return; }
            if (grid.SelectedRows[0].Cells["Returnat"].Value?.ToString() == "Da")
            { MessageBox.Show("Cartea a fost deja returnată!", "Info"); return; }

            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["ImprumutID"].Value);
            if (MessageBox.Show("Marcați cartea ca returnată astăzi?", "Confirmare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Imprumuturi SET Returnat=1, DataReturnareReala=@d WHERE ImprumutID=@id",
                    new SqlParameter("@d",  DateTime.Today),
                    new SqlParameter("@id", id));
                DatabaseHelper.ExecuteNonQuery(
                    @"UPDATE Carti SET NrDisponibil = NrDisponibil + 1
                      WHERE CarteID = (SELECT CarteID FROM Imprumuturi WHERE ImprumutID = @id)",
                    new SqlParameter("@id", id));
                MessageBox.Show("Returnare înregistrată!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show($"Eroare: {ex.Message}"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați un împrumut!", "Atenție"); return; }
            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["ImprumutID"].Value);
            if (MessageBox.Show("Ștergeți definitiv acest împrumut?", "Confirmare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Imprumuturi WHERE ImprumutID=@id",
                    new SqlParameter("@id", id));
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show($"Eroare: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterData();
        private void chkDoarActive_CheckedChanged(object sender, EventArgs e) => FilterData();
    }
}
