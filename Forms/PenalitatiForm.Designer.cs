namespace BibliotecaApp.Forms
{
    partial class PenalitatiForm
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
            this.btnRefresh     = new Button();
            this.btnExport      = new Button();
            this.chkDoarActive  = new CheckBox();
            this.lblFormula     = new Label();
            this.grid           = new DataGridView();
            this.panelSummary   = new Panel();
            this.lblNrCazuri    = new Label();
            this.lblTotal       = new Label();

            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).BeginInit();
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
            this.lblTitle.Text      = "💰  Calculator Penalități";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location  = new Point(17, 42);
            this.lblSubtitle.Text      = "Calcul automat al penalităților ($) pentru întârzieri la returnare.";

            // panelToolbar
            this.panelToolbar.BackColor = Color.White;
            this.panelToolbar.Controls.AddRange(new Control[] {
                this.btnRefresh, this.btnExport, this.chkDoarActive, this.lblFormula });
            this.panelToolbar.Dock    = DockStyle.Top;
            this.panelToolbar.Height  = 55;

            MkBtn(this.btnRefresh, "🔄 Recalculează", Color.FromArgb(41,98,143),  new Point(10,12),  148, this.btnRefresh_Click);
            MkBtn(this.btnExport,  "📄 Export CSV",   Color.FromArgb(34,139,34),  new Point(166,12), 120, this.btnExport_Click);

            this.chkDoarActive.AutoSize  = true;
            this.chkDoarActive.Checked   = true;
            this.chkDoarActive.Font      = new Font("Segoe UI", 9f);
            this.chkDoarActive.Location  = new Point(300, 16);
            this.chkDoarActive.Text      = "Doar împrumuturi active";
            this.chkDoarActive.CheckedChanged += new EventHandler(this.chkDoarActive_CheckedChanged);

            this.lblFormula.AutoSize  = true;
            this.lblFormula.Font      = new Font("Segoe UI", 8.5f, FontStyle.Italic);
            this.lblFormula.ForeColor = Color.FromArgb(100, 120, 150);
            this.lblFormula.Location  = new Point(470, 17);
            this.lblFormula.Text      = "ℹ️  Penalitate = max(0, DataAzi – Termen) × Tarif$/zi";

            // grid
            this.grid.AllowUserToAddRows         = false;
            this.grid.AllowUserToDeleteRows      = false;
            this.grid.BackgroundColor            = Color.White;
            this.grid.BorderStyle                = BorderStyle.None;
            this.grid.CellBorderStyle            = DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid.ColumnHeadersHeight        = 38;
            this.grid.Dock                       = DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles  = false;
            this.grid.MultiSelect                = false;
            this.grid.ReadOnly                   = true;
            this.grid.RowTemplate.Height         = 32;
            this.grid.SelectionMode              = DataGridViewSelectionMode.FullRowSelect;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(26, 60, 90);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.grid.DefaultCellStyle.Font                     = new Font("Segoe UI", 9f);
            this.grid.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(70, 160, 220);
            this.grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 244, 255);

            // panelSummary
            this.panelSummary.BackColor = Color.FromArgb(26, 60, 90);
            this.panelSummary.Controls.AddRange(new Control[] { this.lblNrCazuri, this.lblTotal });
            this.panelSummary.Dock      = DockStyle.Bottom;
            this.panelSummary.Height    = 68;
            this.panelSummary.Padding   = new Padding(20, 8, 20, 8);

            this.lblNrCazuri.AutoSize  = true;
            this.lblNrCazuri.Font      = new Font("Segoe UI", 10f);
            this.lblNrCazuri.ForeColor = Color.White;
            this.lblNrCazuri.Location  = new Point(20, 10);
            this.lblNrCazuri.Text      = "Cazuri cu penalitate: 0";

            this.lblTotal.AutoSize  = true;
            this.lblTotal.Font      = new Font("Segoe UI", 15f, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(255, 220, 80);
            this.lblTotal.Location  = new Point(20, 34);
            this.lblTotal.Text      = "Total penalități: $0.00";

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.Controls.AddRange(new Control[] {
                this.grid, this.panelSummary, this.panelToolbar, this.panelHeader });
            this.Name                = "PenalitatiForm";
            this.Size                = new Size(1050, 640);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).EndInit();
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

        private Panel           panelHeader;
        private Label           lblTitle;
        private Label           lblSubtitle;
        private Panel           panelToolbar;
        private Button          btnRefresh;
        private Button          btnExport;
        private CheckBox        chkDoarActive;
        private Label           lblFormula;
        private DataGridView    grid;
        private Panel           panelSummary;
        private Label           lblNrCazuri;
        private Label           lblTotal;
    }
}
