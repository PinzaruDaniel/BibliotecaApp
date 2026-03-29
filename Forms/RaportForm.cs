using BibliotecaApp.Database;
using System.Data;
using System.Text;

namespace BibliotecaApp.Forms
{
    public partial class RaportForm : Form
    {
        public RaportForm()
        {
            Text = "Rapoarte";
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                string tip = cmbTipRaport.SelectedItem?.ToString() ?? "";
                sb.AppendLine("╔══════════════════════════════════════════════════╗");
                sb.AppendLine("║      BIBLIOTECA DIGITALĂ – RAPORT STATISTIC      ║");
                sb.AppendLine("╚══════════════════════════════════════════════════╝");
                sb.AppendLine($"  Tip raport  : {tip}");
                sb.AppendLine($"  Generat la  : {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine("  ─────────────────────────────────────────────────");

                switch (cmbTipRaport.SelectedIndex)
                {
                    case 0: GeneralStats(sb);   break;
                    case 1: TopCarti(sb);        break;
                    case 2: CititoriActivi(sb);  break;
                    case 3: PenalitatiRaport(sb);break;
                    case 4: StocCarti(sb);       break;
                }

                sb.AppendLine();
                sb.AppendLine("  ─────────────────────────────────────────────────");
                sb.AppendLine($"  © {DateTime.Now.Year} Gestiune Bibliotecă  |  Azure SQL Database");
                rtbRaport.Text = sb.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare"); }
        }

        private void GeneralStats(StringBuilder sb)
        {
            var r = DatabaseHelper.ExecuteQuery(@"
                SELECT
                  (SELECT COUNT(*) FROM Autori) AS TotalAutori,
                  (SELECT COUNT(*) FROM Carti) AS TotalCarti,
                  (SELECT SUM(NrExemplare) FROM Carti) AS TotalExemplare,
                  (SELECT COUNT(*) FROM Imprumuturi) AS TotalImprumuturi,
                  (SELECT COUNT(*) FROM Imprumuturi WHERE Returnat=0) AS ImprumuturiActive,
                  (SELECT COUNT(*) FROM Imprumuturi WHERE Returnat=0 AND DataReturnareEstimata < CAST(GETDATE() AS DATE)) AS CuIntarziere").Rows[0];
            sb.AppendLine("\n  📚 STATISTICI GENERALE:\n");
            sb.AppendLine($"  • Total autori înregistrați  : {r["TotalAutori"]}");
            sb.AppendLine($"  • Total titluri de cărți     : {r["TotalCarti"]}");
            sb.AppendLine($"  • Total exemplare fizice     : {r["TotalExemplare"]}");
            sb.AppendLine($"  • Total împrumuturi           : {r["TotalImprumuturi"]}");
            sb.AppendLine($"  • Împrumuturi active          : {r["ImprumuturiActive"]}");
            sb.AppendLine($"  • Cu întârziere (neret.)     : {r["CuIntarziere"]}");
        }

        private void TopCarti(StringBuilder sb)
        {
            var dt = DatabaseHelper.ExecuteQuery(@"
                SELECT TOP 10 c.Titlu, COUNT(*) AS NrImprumuturi
                FROM Imprumuturi i JOIN Carti c ON i.CarteID=c.CarteID
                GROUP BY c.Titlu ORDER BY NrImprumuturi DESC");
            sb.AppendLine("\n  🏆 TOP 10 CĂRȚI ÎMPRUMUTATE:\n");
            int i = 1;
            foreach (DataRow r in dt.Rows)
                sb.AppendLine($"  {i++,2}. {r["Titlu"],-35} → {r["NrImprumuturi"]} împrumuturi");
        }

        private void CititoriActivi(StringBuilder sb)
        {
            var dt = DatabaseHelper.ExecuteQuery(@"
                SELECT NumeCititor, COUNT(*) AS NrActive, MIN(DataReturnareEstimata) AS CelMaiVechi
                FROM Imprumuturi WHERE Returnat=0
                GROUP BY NumeCititor ORDER BY NrActive DESC");
            sb.AppendLine("\n  👤 CITITORI CU ÎMPRUMUTURI ACTIVE:\n");
            foreach (DataRow r in dt.Rows)
                sb.AppendLine($"  • {r["NumeCititor"],-30} | {r["NrActive"]} active | termen: {r["CelMaiVechi"]:dd.MM.yyyy}");
        }

        private void PenalitatiRaport(StringBuilder sb)
        {
            var dt = DatabaseHelper.ExecuteQuery(@"
                SELECT i.NumeCititor, c.Titlu, i.DataReturnareEstimata,
                       DATEDIFF(day,i.DataReturnareEstimata,CAST(GETDATE() AS DATE)) AS ZileInt,
                       i.TarifPenalitate,
                       DATEDIFF(day,i.DataReturnareEstimata,CAST(GETDATE() AS DATE))*i.TarifPenalitate AS Penalitate
                FROM Imprumuturi i JOIN Carti c ON i.CarteID=c.CarteID
                WHERE i.Returnat=0 AND i.DataReturnareEstimata < CAST(GETDATE() AS DATE)
                ORDER BY ZileInt DESC");
            sb.AppendLine("\n  ⚠️  ÎMPRUMUTURI CU PENALITĂȚI ACTIVE:\n");
            decimal total = 0;
            foreach (DataRow r in dt.Rows)
            {
                decimal pen = Convert.ToDecimal(r["Penalitate"]);
                total += pen;
                sb.AppendLine($"  • {r["NumeCititor"],-25} | {r["Titlu"],-25} | {r["ZileInt"]} zile | ${pen:F2}");
            }
            sb.AppendLine($"\n  TOTAL PENALITĂȚI: ${total:F2}");
        }

        private void StocCarti(StringBuilder sb)
        {
            var dt = DatabaseHelper.ExecuteQuery(@"
                SELECT c.Titlu, a.Prenume+' '+a.Nume AS Autor, c.NrExemplare, c.NrDisponibil
                FROM Carti c JOIN Autori a ON c.AutorID=a.AutorID
                ORDER BY c.NrDisponibil ASC");
            sb.AppendLine("\n  📦 STOC DISPONIBIL CĂRȚI:\n");
            foreach (DataRow r in dt.Rows)
            {
                int disp  = Convert.ToInt32(r["NrDisponibil"]);
                string tag = disp == 0 ? "⛔ EPUIZAT" : $"✅ {disp} disp.";
                sb.AppendLine($"  {r["Titlu"],-35} | {r["Autor"],-20} | Total: {r["NrExemplare"]} | {tag}");
            }
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbRaport.Text)) btnGenerate_Click(sender, e);
            using var sfd = new SaveFileDialog { Filter = "Text files (*.txt)|*.txt",
                FileName = $"Raport_{DateTime.Now:yyyyMMdd}.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, rtbRaport.Text, Encoding.UTF8);
                MessageBox.Show("Raport exportat!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            btnGenerate_Click(sender, e);
            using var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv",
                FileName = $"Raport_{DateTime.Now:yyyyMMdd}.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, rtbRaport.Text, Encoding.UTF8);
                MessageBox.Show("Export CSV realizat!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
