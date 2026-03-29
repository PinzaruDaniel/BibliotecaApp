namespace BibliotecaApp.Forms
{
    partial class MainForm
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

            this.menuStrip          = new MenuStrip();
            this.miAutori           = new ToolStripMenuItem();
            this.miCarti            = new ToolStripMenuItem();
            this.miImprumuturi      = new ToolStripMenuItem();
            this.miPenalitati       = new ToolStripMenuItem();
            this.miRaport           = new ToolStripMenuItem();
            this.miSeparator        = new ToolStripSeparator();
            this.miExit             = new ToolStripMenuItem();
            this.panelSide          = new Panel();
            this.lblMenuTitle       = new Label();
            this.btnAutori          = new Button();
            this.btnCarti           = new Button();
            this.btnImprumuturi     = new Button();
            this.btnPenalitati      = new Button();
            this.btnRaport          = new Button();
            this.btnExit            = new Button();
            this.panelContent       = new Panel();
            this.statusStrip        = new StatusStrip();
            this.lblStatusSection   = new ToolStripStatusLabel();
            this.lblStatusSep       = new ToolStripStatusLabel();
            this.lblTime            = new ToolStripStatusLabel();
            this.timerClock         = new System.Windows.Forms.Timer(components);

            this.menuStrip.SuspendLayout();
            this.panelSide.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // ── menuStrip ──
            this.menuStrip.BackColor = Color.FromArgb(26, 60, 90);
            this.menuStrip.ForeColor = Color.White;
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.miAutori, this.miCarti, this.miImprumuturi,
                this.miPenalitati, this.miRaport, this.miSeparator, this.miExit });
            this.menuStrip.Location  = new Point(0, 0);
            this.menuStrip.Name      = "menuStrip";
            this.menuStrip.Size      = new Size(1100, 24);
            this.menuStrip.Text      = "menuStrip";

            StyleMenuItem(this.miAutori,      "👤  Autori",       this.miAutori_Click);
            StyleMenuItem(this.miCarti,       "📖  Cărți",        this.miCarti_Click);
            StyleMenuItem(this.miImprumuturi, "📋  Împrumuturi",  this.miImprumuturi_Click);
            StyleMenuItem(this.miPenalitati,  "💰  Penalități",   this.miPenalitati_Click);
            StyleMenuItem(this.miRaport,      "📊  Raport",       this.miRaport_Click);
            StyleMenuItem(this.miExit,        "🚪  Ieșire",       this.miExit_Click);

            // ── panelSide ──
            this.panelSide.BackColor = Color.FromArgb(26, 60, 90);
            this.panelSide.Controls.AddRange(new Control[] {
                this.lblMenuTitle, this.btnAutori, this.btnCarti,
                this.btnImprumuturi, this.btnPenalitati, this.btnRaport, this.btnExit });
            this.panelSide.Dock     = DockStyle.Left;
            this.panelSide.Name     = "panelSide";
            this.panelSide.Width    = 200;

            // lblMenuTitle
            this.lblMenuTitle.AutoSize  = false;
            this.lblMenuTitle.Dock      = DockStyle.Top;
            this.lblMenuTitle.Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            this.lblMenuTitle.ForeColor = Color.FromArgb(70, 160, 220);
            this.lblMenuTitle.Height    = 40;
            this.lblMenuTitle.Name      = "lblMenuTitle";
            this.lblMenuTitle.Text      = "MENIU PRINCIPAL";
            this.lblMenuTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Side buttons
            StyleSideButton(this.btnAutori,      "👤  Autori",       new Point(12, 50),  this.btnAutori_Click);
            StyleSideButton(this.btnCarti,        "📖  Cărți",        new Point(12, 100), this.btnCarti_Click);
            StyleSideButton(this.btnImprumuturi,  "📋  Împrumuturi",  new Point(12, 150), this.btnImprumuturi_Click);
            StyleSideButton(this.btnPenalitati,   "💰  Penalități",   new Point(12, 200), this.btnPenalitati_Click);
            StyleSideButton(this.btnRaport,       "📊  Raport",       new Point(12, 250), this.btnRaport_Click);
            StyleSideButton(this.btnExit,         "🚪  Ieșire",       new Point(12, 320), this.btnExit_Click);
            this.btnExit.BackColor = Color.FromArgb(100, 30, 30);

            // panelContent
            this.panelContent.BackColor = Color.FromArgb(245, 247, 250);
            this.panelContent.Dock      = DockStyle.Fill;
            this.panelContent.Name      = "panelContent";
            this.panelContent.Padding   = new Padding(10);

            // statusStrip
            this.statusStrip.BackColor = Color.FromArgb(26, 60, 90);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatusSection, this.lblStatusSep, this.lblTime });
            this.statusStrip.Name      = "statusStrip";

            this.lblStatusSection.ForeColor  = Color.FromArgb(100, 210, 130);
            this.lblStatusSection.Name       = "lblStatusSection";
            this.lblStatusSection.Text       = "  ✅  Conectat la BibliotecaDB";
            this.lblStatusSection.Spring     = false;

            this.lblStatusSep.Name  = "lblStatusSep";
            this.lblStatusSep.Spring= true;

            this.lblTime.ForeColor  = Color.White;
            this.lblTime.Name       = "lblTime";
            this.lblTime.Text       = "";
            this.lblTime.TextAlign  = ContentAlignment.MiddleRight;

            // timerClock
            this.timerClock.Interval  = 1000;
            this.timerClock.Tick     += new EventHandler(this.timerClock_Tick);

            // MainForm
            this.AutoScaleDimensions   = new SizeF(7F, 15F);
            this.AutoScaleMode         = AutoScaleMode.Font;
            this.ClientSize            = new Size(1100, 680);
            this.Controls.AddRange(new Control[] {
                this.panelContent, this.panelSide, this.menuStrip, this.statusStrip });
            this.KeyPreview            = true;
            this.MainMenuStrip         = this.menuStrip;
            this.MinimumSize           = new Size(900, 580);
            this.Name                  = "MainForm";
            this.StartPosition         = FormStartPosition.CenterScreen;
            this.Text                  = "Gestiune Bibliotecă – Panou Principal";
            this.FormClosing          += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown              += new KeyEventHandler(this.MainForm_KeyDown);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelSide.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static void StyleMenuItem(ToolStripMenuItem mi, string text, EventHandler handler)
        {
            mi.ForeColor  = Color.White;
            mi.Name       = "mi_" + text.Trim();
            mi.Text       = text;
            mi.Click     += handler;
        }

        private static void StyleSideButton(Button btn, string text, Point loc, EventHandler handler)
        {
            btn.BackColor             = Color.FromArgb(40, 80, 120);
            btn.FlatStyle             = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(60, 100, 150);
            btn.FlatAppearance.BorderSize  = 1;
            btn.Font                  = new Font("Segoe UI", 9.5f);
            btn.ForeColor             = Color.White;
            btn.Location              = loc;
            btn.Name                  = "btn_" + text.Trim();
            btn.Padding               = new Padding(8, 0, 0, 0);
            btn.Size                  = new Size(176, 40);
            btn.Text                  = text;
            btn.TextAlign             = ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = false;
            btn.Cursor                = Cursors.Hand;
            btn.Click                += handler;
        }

        #endregion

        private MenuStrip              menuStrip;
        private ToolStripMenuItem      miAutori;
        private ToolStripMenuItem      miCarti;
        private ToolStripMenuItem      miImprumuturi;
        private ToolStripMenuItem      miPenalitati;
        private ToolStripMenuItem      miRaport;
        private ToolStripSeparator     miSeparator;
        private ToolStripMenuItem      miExit;
        private Panel                  panelSide;
        private Label                  lblMenuTitle;
        private Button                 btnAutori;
        private Button                 btnCarti;
        private Button                 btnImprumuturi;
        private Button                 btnPenalitati;
        private Button                 btnRaport;
        private Button                 btnExit;
        private Panel                  panelContent;
        private StatusStrip            statusStrip;
        private ToolStripStatusLabel   lblStatusSection;
        private ToolStripStatusLabel   lblStatusSep;
        private ToolStripStatusLabel   lblTime;
        private System.Windows.Forms.Timer timerClock;
    }
}
