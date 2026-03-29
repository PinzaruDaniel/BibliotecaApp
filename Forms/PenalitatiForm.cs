using BibliotecaApp.Database;
using BibliotecaApp.Logic;
using System.Data;

namespace BibliotecaApp.Forms
{
    public partial class PenalitatiForm : Form
    {
        private readonly PenaltyCalculator _calculator = new PenaltyCalculator();

        public PenalitatiForm()
        {
            Text = "Penalități";
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string filter = chkDoarActive.Checked ? "AND i.Returnat = 0" : "";
                var dt = DatabaseHelper.ExecuteQuery($@"
                    SELECT i.ImprumutID, i.NumeCititor, c.Titlu AS Carte,
                           i.DataImprumut, i.DataReturnareEstimata, i.DataReturnareReala,
                           i.Returnat, i.TarifPenalitate
                    FROM Imprumuturi i
                    JOIN Carti c ON i.CarteID = c.CarteID
                    WHERE 1=1 {filter}
                    ORDER BY i.DataReturnareEstimata");

                // Construiește DataTable cu calcule OOP
                var result = new DataTable();
                result.Columns.Add("ID",               typeof(int));
                result.Columns.Add("Cititor",          typeof(string));
                result.Columns.Add("Carte",            typeof(string));
                result.Columns.Add("Data Împrumut",    typeof(DateTime));
                result.Columns.Add("Termen",           typeof(DateTime));
                result.Columns.Add("Returnată",        typeof(string));
                result.Columns.Add("Zile Întârziere",  typeof(int));
                result.Columns.Add("Tarif $/zi",       typeof(decimal));
                result.Columns.Add("Penalitate ($)",   typeof(decimal));
                result.Columns.Add("Status",           typeof(string));

                decimal totalPenalitate  = 0;
                int     cazuriCuPenalitate = 0;

                foreach (DataRow row in dt.Rows)
                {
                    var   dataEstimata = Convert.ToDateTime(row["DataReturnareEstimata"]);
                    DateTime? dataReala = row["DataReturnareReala"] == DBNull.Value
                        ? null : Convert.ToDateTime(row["DataReturnareReala"]);
                    bool  returnat = Convert.ToBoolean(row["Returnat"]);
                    decimal tarif  = Convert.ToDecimal(row["TarifPenalitate"]);

                    // Clasa OOP PenaltyCalculator face calculul
                    var report = _calculator.GenereazaRaport(
                        row["NumeCititor"].ToString()!,
                        row["Carte"].ToString()!,
                        Convert.ToDateTime(row["DataImprumut"]),
                        dataEstimata, dataReala, returnat, tarif);

                    totalPenalitate += report.PenalitateTotala;
                    if (report.AreIntarziere) cazuriCuPenalitate++;

                    result.Rows.Add(
                        row["ImprumutID"], row["NumeCititor"], row["Carte"],
                        row["DataImprumut"], dataEstimata,
                        returnat ? "Da" : "Nu",
                        report.ZileIntarziere, tarif,
                        report.PenalitateTotala,
                        report.StatusImprumut);
                }

                grid.DataSource = result;
                FormatGrid();
                ColorRows();

                lblNrCazuri.Text = $"Cazuri cu penalitate: {cazuriCuPenalitate}";
                lblTotal.Text    = $"Total penalități datorate: {totalPenalitate:C2}";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void FormatGrid()
        {
            if (grid.Columns.Count == 0) return;
            grid.Columns["ID"].Width             = 40;
            grid.Columns["Cititor"].Width         = 160;
            grid.Columns["Carte"].Width           = 180;
            grid.Columns["Data Împrumut"].Width   = 100;
            grid.Columns["Termen"].Width          = 85;
            grid.Columns["Returnată"].Width       = 75;
            grid.Columns["Zile Întârziere"].Width = 95;
            grid.Columns["Tarif $/zi"].Width      = 75;
            grid.Columns["Penalitate ($)"].Width  = 100;
            grid.Columns["Status"].Width          = 200;
            grid.Columns["Tarif $/zi"].DefaultCellStyle.Format    = "C2";
            grid.Columns["Penalitate ($)"].DefaultCellStyle.Format = "C2";
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow r in grid.Rows)
            {
                int zile = Convert.ToInt32(r.Cells["Zile Întârziere"].Value ?? 0);
                if (zile > 0 && r.Cells["Returnată"].Value?.ToString() == "Nu")
                {
                    r.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                    r.DefaultCellStyle.ForeColor = Color.DarkRed;
                    r.DefaultCellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else if (zile > 0)
                {
                    r.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                    r.DefaultCellStyle.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
        private void chkDoarActive_CheckedChanged(object sender, EventArgs e) => LoadData();

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter   = "CSV files (*.csv)|*.csv",
                FileName = $"Penalitati_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8);
                var cols = grid.Columns.Cast<DataGridViewColumn>().Select(c => $"\"{c.HeaderText}\"");
                sw.WriteLine(string.Join(",", cols));
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(c => $"\"{c.Value}\"");
                    sw.WriteLine(string.Join(",", cells));
                }
                MessageBox.Show($"Export realizat cu succes!\n{sfd.FileName}", "Export CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Eroare export: {ex.Message}"); }
        }
    }
}
