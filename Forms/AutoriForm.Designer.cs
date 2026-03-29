namespace BibliotecaApp.Forms
{
    partial class AutoriForm
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
            this.btnEdit        = new Button();
            this.btnDelete      = new Button();
            this.btnRefresh     = new Button();
            this.lblSearch      = new Label();
            this.txtSearch      = new TextBox();
            this.grid           = new DataGridView();

            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.AddRange(new Control[] { this.lblTitle, this.lblSubtitle });
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 70;
            this.panelHeader.Name      = "panelHeader";

            this.lblTitle.AutoSize   = true;
            this.lblTitle.Font       = new Font("Segoe UI", 16f, FontStyle.Bold);
            this.lblTitle.ForeColor  = Color.White;
            this.lblTitle.Location   = new Point(15, 10);
            this.lblTitle.Name       = "lblTitle";
            this.lblTitle.Text       = "👤  Gestionare Autori";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location  = new Point(17, 42);
            this.lblSubtitle.Name      = "lblSubtitle";
            this.lblSubtitle.Text      = "Adăugați, editați sau ștergeți autori din sistem.";

            // panelToolbar
            this.panelToolbar.BackColor = Color.White;
            this.panelToolbar.Controls.AddRange(new Control[] {
                this.btnAdd, this.btnEdit, this.btnDelete, this.btnRefresh,
                this.lblSearch, this.txtSearch });
            this.panelToolbar.Dock      = DockStyle.Top;
            this.panelToolbar.Height    = 55;
            this.panelToolbar.Name      = "panelToolbar";
            this.panelToolbar.Padding   = new Padding(10, 10, 10, 0);

            StyleToolbarButton(this.btnAdd,     "➕ Adaugă",    Color.FromArgb(34, 139, 34),      new Point(10, 11), this.btnAdd_Click);
            StyleToolbarButton(this.btnEdit,    "✏️ Editează",  Color.FromArgb(41, 98, 143),       new Point(135, 11), this.btnEdit_Click);
            StyleToolbarButton(this.btnDelete,  "🗑️ Șterge",   Color.FromArgb(196, 43, 43),       new Point(260, 11), this.btnDelete_Click);
            StyleToolbarButton(this.btnRefresh, "🔄 Reîncarcă", Color.FromArgb(100, 120, 140),     new Point(385, 11), this.btnRefresh_Click);

            this.lblSearch.AutoSize  = true;
            this.lblSearch.Font      = new Font("Segoe UI", 9f);
            this.lblSearch.Location  = new Point(520, 15);
            this.lblSearch.Name      = "lblSearch";
            this.lblSearch.Text      = "🔍 Caută:";

            this.txtSearch.Font              = new Font("Segoe UI", 9f);
            this.txtSearch.Location          = new Point(580, 12);
            this.txtSearch.Name              = "txtSearch";
            this.txtSearch.PlaceholderText   = "Nume sau prenume...";
            this.txtSearch.Size              = new Size(200, 23);
            this.txtSearch.TextChanged      += new EventHandler(this.txtSearch_TextChanged);

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
            this.grid.Name                       = "grid";
            this.grid.ReadOnly                   = true;
            this.grid.RowTemplate.Height         = 32;
            this.grid.SelectionMode              = DataGridViewSelectionMode.FullRowSelect;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(26, 60, 90);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            this.grid.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.grid.DefaultCellStyle.Font                     = new Font("Segoe UI", 9f);
            this.grid.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(70, 160, 220);
            this.grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 244, 255);

            // AutoriForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.Controls.AddRange(new Control[] { this.grid, this.panelToolbar, this.panelHeader });
            this.KeyPreview          = true;
            this.Name                = "AutoriForm";
            this.Size                = new Size(900, 600);
            this.KeyDown            += new KeyEventHandler(this.AutoriForm_KeyDown);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).EndInit();
            this.ResumeLayout(false);
        }

        private static void StyleToolbarButton(Button btn, string text, Color color, Point loc, EventHandler handler)
        {
            btn.BackColor                       = color;
            btn.FlatStyle                       = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize       = 0;
            btn.Font                            = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btn.ForeColor                       = Color.White;
            btn.Location                        = loc;
            btn.Name                            = "btn_" + text.Replace(" ", "");
            btn.Size                            = new Size(115, 30);
            btn.Text                            = text;
            btn.UseVisualStyleBackColor         = false;
            btn.Cursor                          = Cursors.Hand;
            btn.Click                          += handler;
        }

        #endregion

        private Panel           panelHeader;
        private Label           lblTitle;
        private Label           lblSubtitle;
        private Panel           panelToolbar;
        private Button          btnAdd;
        private Button          btnEdit;
        private Button          btnDelete;
        private Button          btnRefresh;
        private Label           lblSearch;
        private TextBox         txtSearch;
        private DataGridView    grid;
    }
}
