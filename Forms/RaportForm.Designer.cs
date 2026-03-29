namespace BibliotecaApp.Forms
{
    partial class RaportForm
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
            this.panelHeader    = new Panel();
            this.lblTitle       = new Label();
            this.lblSubtitle    = new Label();
            this.panelToolbar   = new Panel();
            this.cmbTipRaport   = new ComboBox();
            this.btnGenerate    = new Button();
            this.btnExportTxt   = new Button();
            this.btnExportCsv   = new Button();
            this.rtbRaport      = new RichTextBox();

            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.AddRange(new Control[] { this.lblTitle, this.lblSubtitle });
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 70;

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new Font("Segoe UI", 16f, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(15, 10);
            this.lblTitle.Text      = "📊  Rapoarte și Statistici";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location  = new Point(17, 42);
            this.lblSubtitle.Text      = "Generați rapoarte statistice despre activitatea bibliotecii.";

            // panelToolbar
            this.panelToolbar.BackColor = Color.White;
            this.panelToolbar.Controls.AddRange(new Control[] {
                this.cmbTipRaport, this.btnGenerate, this.btnExportTxt, this.btnExportCsv });
            this.panelToolbar.Dock    = DockStyle.Top;
            this.panelToolbar.Height  = 55;

            this.cmbTipRaport.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipRaport.Font          = new Font("Segoe UI", 9f);
            this.cmbTipRaport.Items.AddRange(new object[] {
                "Statistici Generale",
                "Cărți cu Cele Mai Multe Împrumuturi",
                "Cititori cu Împrumuturi Active",
                "Împrumuturi cu Penalități",
                "Stoc Disponibil Cărți" });
            this.cmbTipRaport.Location      = new Point(10, 14);
            this.cmbTipRaport.SelectedIndex = 0;
            this.cmbTipRaport.Size          = new Size(240, 23);

            MkBtn(this.btnGenerate,   "📊 Generează",   Color.FromArgb(41,98,143),   new Point(260,12), 120, this.btnGenerate_Click);
            MkBtn(this.btnExportTxt,  "📄 Export .TXT", Color.FromArgb(34,139,34),   new Point(388,12), 120, this.btnExportTxt_Click);
            MkBtn(this.btnExportCsv,  "📊 Export .CSV", Color.FromArgb(100,130,160), new Point(516,12), 120, this.btnExportCsv_Click);

            // rtbRaport
            this.rtbRaport.BackColor   = Color.FromArgb(28, 28, 28);
            this.rtbRaport.BorderStyle = BorderStyle.None;
            this.rtbRaport.Dock        = DockStyle.Fill;
            this.rtbRaport.Font        = new Font("Consolas", 10f);
            this.rtbRaport.ForeColor   = Color.FromArgb(200, 230, 200);
            this.rtbRaport.Name        = "rtbRaport";
            this.rtbRaport.ReadOnly    = true;
            this.rtbRaport.Text        = "\r\n\r\n   Apăsați «📊 Generează» pentru a crea un raport.";

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.Controls.AddRange(new Control[] { this.rtbRaport, this.panelToolbar, this.panelHeader });
            this.Name                = "RaportForm";
            this.Size                = new Size(1000, 620);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);
        }

        private static void MkBtn(Button btn, string text, Color color, Point loc, int width, EventHandler handler)
        {
            btn.BackColor                 = color;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 9f, FontStyle.Bold);
            btn.ForeColor                 = Color.White;
            btn.Location                  = loc;
            btn.Size                      = new Size(width, 30);
            btn.Text                      = text;
            btn.UseVisualStyleBackColor   = false;
            btn.Cursor                    = Cursors.Hand;
            btn.Click                    += handler;
        }

        #endregion

        private Panel       panelHeader;
        private Label       lblTitle;
        private Label       lblSubtitle;
        private Panel       panelToolbar;
        private ComboBox    cmbTipRaport;
        private Button      btnGenerate;
        private Button      btnExportTxt;
        private Button      btnExportCsv;
        private RichTextBox rtbRaport;
    }
}
