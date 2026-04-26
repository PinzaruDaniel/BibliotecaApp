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
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelToolbar = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblGen = new Label();
            cmbGen = new ComboBox();
            grid = new DataGridView();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(6, 6, 6, 6);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1809, 149);
            panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(28, 21);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(434, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📖  Gestionare Cărți";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            lblSubtitle.Location = new Point(32, 90);
            lblSubtitle.Margin = new Padding(6, 0, 6, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(432, 32);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Catalog complet de cărți din bibliotecă.";
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(btnAdd);
            panelToolbar.Controls.Add(btnEdit);
            panelToolbar.Controls.Add(btnDelete);
            panelToolbar.Controls.Add(btnRefresh);
            panelToolbar.Controls.Add(lblSearch);
            panelToolbar.Controls.Add(txtSearch);
            panelToolbar.Controls.Add(lblGen);
            panelToolbar.Controls.Add(cmbGen);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 149);
            panelToolbar.Margin = new Padding(6, 6, 6, 6);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(19, 21, 19, 0);
            panelToolbar.Size = new Size(1809, 117);
            panelToolbar.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(6, 6, 6, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(139, 49);
            btnAdd.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(0, 0);
            btnEdit.Margin = new Padding(6, 6, 6, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(139, 49);
            btnEdit.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(0, 0);
            btnDelete.Margin = new Padding(6, 6, 6, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(139, 49);
            btnDelete.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Margin = new Padding(6, 6, 6, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(139, 49);
            btnRefresh.TabIndex = 3;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.Location = new Point(925, 33);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(47, 32);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "🔍";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(984, 26);
            txtSearch.Margin = new Padding(6, 6, 6, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Titlu / ISBN / Autor...";
            txtSearch.Size = new Size(322, 39);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblGen
            // 
            lblGen.AutoSize = true;
            lblGen.Font = new Font("Segoe UI", 9F);
            lblGen.Location = new Point(1309, 32);
            lblGen.Margin = new Padding(6, 0, 6, 0);
            lblGen.Name = "lblGen";
            lblGen.Size = new Size(62, 32);
            lblGen.TabIndex = 6;
            lblGen.Text = "Gen:";
            // 
            // cmbGen
            // 
            cmbGen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGen.Font = new Font("Segoe UI", 9F);
            cmbGen.Items.AddRange(new object[] { "Toate", "Roman", "Poezie", "Fantasy", "Sci-Fi", "Dramă", "Non-ficțiune", "Altele" });
            cmbGen.Location = new Point(1365, 26);
            cmbGen.Margin = new Padding(6, 6, 6, 6);
            cmbGen.Name = "cmbGen";
            cmbGen.Size = new Size(238, 40);
            cmbGen.TabIndex = 7;
            cmbGen.SelectedIndexChanged += cmbGen_SelectedIndexChanged;
            // 
            // grid
            // 
            grid.ColumnHeadersHeight = 46;
            grid.Location = new Point(0, 0);
            grid.Margin = new Padding(6, 6, 6, 6);
            grid.Name = "grid";
            grid.RowHeadersWidth = 82;
            grid.Size = new Size(446, 320);
            grid.TabIndex = 0;
            StyleGrid(grid);
            // 
            // CartiForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1809, 1171);
            Controls.Add(grid);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            Margin = new Padding(6, 6, 6, 6);
            Name = "CartiForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
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
