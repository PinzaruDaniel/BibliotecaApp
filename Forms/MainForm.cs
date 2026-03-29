namespace BibliotecaApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            timerClock.Start();
            UpdateClock();
            ShowDashboard();
        }

        private void UpdateClock() =>
            lblTime.Text = $"{DateTime.Now:dd.MM.yyyy   HH:mm:ss}   ";

        private void timerClock_Tick(object sender, EventArgs e) => UpdateClock();

        // ── Navigation ──
        private void OpenForm(Form form)
        {
            panelContent.Controls.Clear();
            form.TopLevel        = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock            = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
            lblStatusSection.Text = $"  📂  {form.Text}";
        }

        private void ShowDashboard()
        {
            panelContent.Controls.Clear();
            var lbl = new Label
            {
                Text      = "📚  Bun venit în Gestiunea Bibliotecii!\r\n\r\n" +
                             "Selectați o secțiune din panoul lateral.\r\n\r\n" +
                             "Ctrl+1 → Autori   |   Ctrl+2 → Cărți   |   Ctrl+3 → Împrumuturi\r\n" +
                             "Ctrl+4 → Penalități   |   Esc → Panou principal",
                Font      = new Font("Segoe UI", 12f),
                ForeColor = Color.FromArgb(60, 90, 130),
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContent.Controls.Add(lbl);
            lblStatusSection.Text = "  ✅  Panou principal";
        }

        // ── Menu / button handlers ──
        private void btnAutori_Click(object sender, EventArgs e)       => OpenForm(new AutoriForm());
        private void btnCarti_Click(object sender, EventArgs e)        => OpenForm(new CartiForm());
        private void btnImprumuturi_Click(object sender, EventArgs e)  => OpenForm(new ImprumuturiForm());
        private void btnPenalitati_Click(object sender, EventArgs e)   => OpenForm(new PenalitatiForm());
        private void btnRaport_Click(object sender, EventArgs e)       => OpenForm(new RaportForm());
        private void btnExit_Click(object sender, EventArgs e)         => ConfirmAndExit();

        private void miAutori_Click(object sender, EventArgs e)      => OpenForm(new AutoriForm());
        private void miCarti_Click(object sender, EventArgs e)       => OpenForm(new CartiForm());
        private void miImprumuturi_Click(object sender, EventArgs e) => OpenForm(new ImprumuturiForm());
        private void miPenalitati_Click(object sender, EventArgs e)  => OpenForm(new PenalitatiForm());
        private void miRaport_Click(object sender, EventArgs e)      => OpenForm(new RaportForm());
        private void miExit_Click(object sender, EventArgs e)        => ConfirmAndExit();

        private void ConfirmAndExit()
        {
            if (MessageBox.Show("Doriți să ieșiți din aplicație?", "Confirmare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Doriți să ieșiți?", "Confirmare",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D1) OpenForm(new AutoriForm());
            if (e.Control && e.KeyCode == Keys.D2) OpenForm(new CartiForm());
            if (e.Control && e.KeyCode == Keys.D3) OpenForm(new ImprumuturiForm());
            if (e.Control && e.KeyCode == Keys.D4) OpenForm(new PenalitatiForm());
            if (e.KeyCode == Keys.Escape)           ShowDashboard();
        }
    }
}
