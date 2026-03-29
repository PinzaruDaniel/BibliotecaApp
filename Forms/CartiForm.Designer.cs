namespace BibliotecaApp.Forms
{
    partial class CartiForm
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
            this.panelHeader  = new Panel();
            this.lblTitle     = new Label();
            this.lblSubtitle  = new Label();
            this.panelToolbar = new Panel();
            this.btnAdd       = new Button();
            this.btnEdit      = new Button();
            this.btnDelete    = new Button();
            this.btnRefresh   = new Button();
            this.lblSearch    = new Label();
            this.txtSearch    = new TextBox();
            this.lblGen       = new Label();
            this.cmbGen       = new ComboBox();
            this.grid         = new DataGridView();

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

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new Font("Segoe UI", 16f, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location  = new Point(15, 10);
            this.lblTitle.Text      = "📖  Gestionare Cărți";

            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location  = new Point(17, 42);
            this.lblSubtitle.Text      = "Catalog complet de cărți din bibliotecă.";

            // panelToolbar
            this.panelToolbar.BackColor = Color.White;
            this.panelToolbar.Controls.AddRange(new Control[] {
                this.btnAdd, this.btnEdit, this.btnDelete, this.btnRefresh,
                this.lblSearch, this.txtSearch, this.lblGen, this.cmbGen });
            this.panelToolbar.Dock    = DockStyle.Top;
            this.panelToolbar.Height  = 55;
            this.panelToolbar.Padding = new Padding(10, 10, 10, 0);

            MakeBtn(this.btnAdd,     "➕ Adaugă",    Color.FromArgb(34,139,34),   new Point(10,11),  this.btnAdd_Click);
            MakeBtn(this.btnEdit,    "✏️ Editează",  Color.FromArgb(41,98,143),   new Point(130,11), this.btnEdit_Click);
            MakeBtn(this.btnDelete,  "🗑️ Șterge",   Color.FromArgb(196,43,43),   new Point(250,11), this.btnDelete_Click);
            MakeBtn(this.btnRefresh, "🔄 Reîncarcă", Color.FromArgb(100,120,140), new Point(370,11), this.btnRefresh_Click);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font     = new Font("Segoe UI", 9f);
            this.lblSearch.Location = new Point(500, 15);
            this.lblSearch.Text     = "🔍";

            this.txtSearch.Font            = new Font("Segoe UI", 9f);
            this.txtSearch.Location        = new Point(520, 12);
            this.txtSearch.PlaceholderText = "Titlu / ISBN / Autor...";
            this.txtSearch.Size            = new Size(175, 23);
            this.txtSearch.TextChanged    += new EventHandler(this.txtSearch_TextChanged);

            this.lblGen.AutoSize = true;
            this.lblGen.Font     = new Font("Segoe UI", 9f);
            this.lblGen.Location = new Point(705, 15);
            this.lblGen.Text     = "Gen:";

            this.cmbGen.DropDownStyle          = ComboBoxStyle.DropDownList;
            this.cmbGen.Font                   = new Font("Segoe UI", 9f);
            this.cmbGen.Items.AddRange(new object[] { "Toate","Roman","Poezie","Fantasy","Sci-Fi","Dramă","Non-ficțiune","Altele" });
            this.cmbGen.Location               = new Point(735, 12);
            this.cmbGen.Name                   = "cmbGen";
            this.cmbGen.SelectedIndex          = 0;
            this.cmbGen.Size                   = new Size(130, 23);
            this.cmbGen.SelectedIndexChanged  += new EventHandler(this.cmbGen_SelectedIndexChanged);

            // grid
            StyleGrid(this.grid);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.Controls.AddRange(new Control[] { this.grid, this.panelToolbar, this.panelHeader });
            this.Name                = "CartiForm";
            this.Size                = new Size(1000, 620);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.grid).EndInit();
            this.ResumeLayout(false);
        }

        private static void MakeBtn(Button btn, string text, Color color, Point loc, EventHandler handler)
        {
            btn.BackColor                 = color;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btn.ForeColor                 = Color.White;
            btn.Location                  = loc;
            btn.Size                      = new Size(110, 30);
            btn.Text                      = text;
            btn.UseVisualStyleBackColor   = false;
            btn.Cursor                    = Cursors.Hand;
            btn.Click                    += handler;
        }

        private static void StyleGrid(DataGridView dgv)
        {
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor       = Color.White;
            dgv.BorderStyle           = BorderStyle.None;
            dgv.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersHeight   = 38;
            dgv.Dock                  = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect           = false;
            dgv.Name                  = "grid";
            dgv.ReadOnly              = true;
            dgv.RowTemplate.Height    = 32;
            dgv.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(26, 60, 90);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.DefaultCellStyle.Font                     = new Font("Segoe UI", 9f);
            dgv.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(70, 160, 220);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 244, 255);
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
        private Label           lblGen;
        private ComboBox        cmbGen;
        private DataGridView    grid;
    }
}
