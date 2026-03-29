namespace BibliotecaApp.Forms
{
    partial class SplashForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.panelHeader    = new Panel();
            this.lblTitle       = new Label();
            this.lblSubtitle    = new Label();
            this.panelBody      = new Panel();
            this.progressBar    = new ProgressBar();
            this.lblStatus      = new Label();
            this.lblCopyright   = new Label();
            this.timerSplash    = new System.Windows.Forms.Timer(components);

            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor  = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.AddRange(new Control[] { this.lblTitle, this.lblSubtitle });
            this.panelHeader.Dock       = DockStyle.Top;
            this.panelHeader.Height     = 200;
            this.panelHeader.Name       = "panelHeader";

            // lblTitle
            this.lblTitle.AutoSize      = false;
            this.lblTitle.Dock          = DockStyle.None;
            this.lblTitle.Font          = new Font("Segoe UI", 22f, FontStyle.Bold);
            this.lblTitle.ForeColor     = Color.White;
            this.lblTitle.Location      = new Point(0, 70);
            this.lblTitle.Name          = "lblTitle";
            this.lblTitle.Size          = new Size(520, 50);
            this.lblTitle.Text          = "📚  Gestiune Bibliotecă";
            this.lblTitle.TextAlign     = ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.AutoSize   = false;
            this.lblSubtitle.Dock       = DockStyle.None;
            this.lblSubtitle.Font       = new Font("Segoe UI", 10f, FontStyle.Regular);
            this.lblSubtitle.ForeColor  = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location   = new Point(0, 128);
            this.lblSubtitle.Name       = "lblSubtitle";
            this.lblSubtitle.Size       = new Size(520, 28);
            this.lblSubtitle.Text       = "Sistem de Management al Bibliotecii  v1.0";
            this.lblSubtitle.TextAlign  = ContentAlignment.MiddleCenter;

            // panelBody
            this.panelBody.BackColor    = Color.FromArgb(240, 244, 250);
            this.panelBody.Controls.AddRange(new Control[] { this.progressBar, this.lblStatus, this.lblCopyright });
            this.panelBody.Dock         = DockStyle.Fill;
            this.panelBody.Name         = "panelBody";
            this.panelBody.Padding      = new Padding(60, 30, 60, 20);

            // progressBar
            this.progressBar.Location   = new Point(60, 30);
            this.progressBar.Maximum    = 100;
            this.progressBar.Minimum    = 0;
            this.progressBar.Name       = "progressBar";
            this.progressBar.Size       = new Size(400, 22);
            this.progressBar.Style      = ProgressBarStyle.Continuous;
            this.progressBar.Value      = 0;

            // lblStatus
            this.lblStatus.AutoSize     = false;
            this.lblStatus.Font         = new Font("Segoe UI", 9f);
            this.lblStatus.ForeColor    = Color.FromArgb(80, 100, 130);
            this.lblStatus.Location     = new Point(60, 62);
            this.lblStatus.Name         = "lblStatus";
            this.lblStatus.Size         = new Size(400, 22);
            this.lblStatus.Text         = "Inițializare aplicație...";
            this.lblStatus.TextAlign    = ContentAlignment.MiddleCenter;

            // lblCopyright
            this.lblCopyright.AutoSize  = false;
            this.lblCopyright.Font      = new Font("Segoe UI", 8f);
            this.lblCopyright.ForeColor = Color.FromArgb(150, 170, 190);
            this.lblCopyright.Location  = new Point(60, 100);
            this.lblCopyright.Name      = "lblCopyright";
            this.lblCopyright.Size      = new Size(400, 20);
            this.lblCopyright.Text      = "© 2026 Biblioteca Digitală  |  Powered by Azure SQL";
            this.lblCopyright.TextAlign = ContentAlignment.MiddleCenter;

            // timerSplash
            this.timerSplash.Interval   = 500;
            this.timerSplash.Tick      += new EventHandler(this.timerSplash_Tick);
            this.timerSplash.Enabled    = true;

            // SplashForm
            this.AutoScaleDimensions    = new SizeF(7F, 15F);
            this.AutoScaleMode          = AutoScaleMode.Font;
            this.BackColor              = Color.FromArgb(240, 244, 250);
            this.ClientSize             = new Size(520, 320);
            this.Controls.AddRange(new Control[] { this.panelBody, this.panelHeader });
            this.FormBorderStyle        = FormBorderStyle.None;
            this.Name                   = "SplashForm";
            this.StartPosition          = FormStartPosition.CenterScreen;
            this.Text                   = "Gestiune Bibliotecă";

            this.panelHeader.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel       panelHeader;
        private Panel       panelBody;
        private Label       lblTitle;
        private Label       lblSubtitle;
        private ProgressBar progressBar;
        private Label       lblStatus;
        private Label       lblCopyright;
        private System.Windows.Forms.Timer timerSplash;
    }
}
