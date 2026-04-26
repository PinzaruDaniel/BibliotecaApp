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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            panelHeader.Size = new Size(1623, 149);
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
            lblTitle.Size = new Size(466, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👤  Gestionare Autori";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(180, 210, 240);
            lblSubtitle.Location = new Point(32, 90);
            lblSubtitle.Margin = new Padding(6, 0, 6, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(508, 32);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Adăugați, editați sau ștergeți autori din sistem.";
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
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 149);
            panelToolbar.Margin = new Padding(6, 6, 6, 6);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(19, 21, 19, 0);
            panelToolbar.Size = new Size(1623, 117);
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
            lblSearch.Location = new Point(945, 29);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(120, 32);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "🔍 Caută:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(1077, 26);
            txtSearch.Margin = new Padding(6, 6, 6, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nume sau prenume...";
            txtSearch.Size = new Size(368, 39);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 244, 255);
            grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(26, 60, 90);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            grid.ColumnHeadersHeight = 38;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(70, 160, 220);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle3;
            grid.Dock = DockStyle.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.Location = new Point(0, 266);
            grid.Margin = new Padding(6, 6, 6, 6);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 82;
            grid.RowTemplate.Height = 32;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(1623, 863);
            grid.TabIndex = 0;
            // 
            // AutoriForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1623, 1129);
            Controls.Add(grid);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            KeyPreview = true;
            Margin = new Padding(6, 6, 6, 6);
            Name = "AutoriForm";
            KeyDown += AutoriForm_KeyDown;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
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
