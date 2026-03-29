namespace BibliotecaApp.Forms
{
    partial class ImprumuturiForm
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
            this.btnAdd         = new Button();
            this.btnReturn      = new Button();
            this.btnEdit        = new Button();
            this.btnDelete      = new Button();
            this.btnRefresh     = new Button();
            this.txtSearch      = new TextBox();
            this.chkDoarActive  = new CheckBox();
            this.grid           = new DataGridView();
            this.lblSummary     = new Label();

            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
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
            this.lblTitle.Text      = "📋  Gestionare Împrumuturi";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location  = new Point(17, 42);
            this.lblSubtitle.Text      = "Registrul complet al împrumuturilor de cărți.";

            // panelToolbar
            this.panelToolbar.BackColor = Color.White;
            this.panelToolbar.Controls.AddRange(new Control[] {
                this.btnAdd, this.btnReturn, this.btnEdit, this.btnDelete, this.btnRefresh,
                this.txtSearch, this.chkDoarActive });
            this.panelToolbar.Dock    = DockStyle.Top;
            this.panelToolbar.Height  = 55;

            MkBtn(this.btnAdd,     "➕ Împrumut nou", Color.FromArgb(34,139,34),   new Point(10,12),  130, this.btnAdd_Click);
            MkBtn(this.btnReturn,  "✅ Returnează",   Color.FromArgb(41,98,143),   new Point(148,12), 120, this.btnReturn_Click);
            MkBtn(this.btnEdit,    "✏️ Editează",     Color.FromArgb(100,130,160), new Point(276,12), 105, this.btnEdit_Click);
            MkBtn(this.btnDelete,  "🗑️ Șterge",      Color.FromArgb(196,43,43),   new Point(389,12), 95,  this.btnDelete_Click);
            MkBtn(this.btnRefresh, "🔄 Reîncarcă",    Color.FromArgb(100,120,140), new Point(492,12), 105, this.btnRefresh_Click);

            this.txtSearch.Font            = new Font("Segoe UI", 9f);
            this.txtSearch.Location        = new Point(610, 15);
            this.txtSearch.PlaceholderText = "Caută cititor / carte...";
            this.txtSearch.Size            = new Size(175, 23);
            this.txtSearch.TextChanged    += new EventHandler(this.txtSearch_TextChanged);

            this.chkDoarActive.AutoSize  = true;
            this.chkDoarActive.Font      = new Font("Segoe UI", 9f);
            this.chkDoarActive.Location  = new Point(800, 16);
            this.chkDoarActive.Text      = "Doar active";
            this.chkDoarActive.CheckedChanged += new EventHandler(this.chkDoarActive_CheckedChanged);

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
            this.grid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.grid_RowPrePaint);

            // lblSummary
            this.lblSummary.BackColor  = Color.White;
            this.lblSummary.Dock       = DockStyle.Bottom;
            this.lblSummary.Font       = new Font("Segoe UI", 9f);
            this.lblSummary.ForeColor  = Color.FromArgb(26, 60, 90);
            this.lblSummary.Height     = 28;
            this.lblSummary.Name       = "lblSummary";
            this.lblSummary.Text       = "";
            this.lblSummary.TextAlign  = ContentAlignment.MiddleLeft;

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.Controls.AddRange(new Control[] { this.grid, this.lblSummary, this.panelToolbar, this.panelHeader });
            this.Name                = "ImprumuturiForm";
            this.Size                = new Size(1050, 640);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).EndInit();
            this.ResumeLayout(false);
        }

        private static void MkBtn(Button btn, string text, Color color, Point loc, int width, EventHandler handler)
        {
            btn.BackColor                 = color;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
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
        private Button          btnAdd;
        private Button          btnReturn;
        private Button          btnEdit;
        private Button          btnDelete;
        private Button          btnRefresh;
        private TextBox         txtSearch;
        private CheckBox        chkDoarActive;
        private DataGridView    grid;
        private Label           lblSummary;
    }
}
