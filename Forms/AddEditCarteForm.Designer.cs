namespace BibliotecaApp.Forms
{
    partial class AddEditCarteForm
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
            this.lblFormTitle = new Label();
            this.lblTitlu     = new Label();
            this.txtTitlu     = new TextBox();
            this.lblAutor     = new Label();
            this.cmbAutor     = new ComboBox();
            this.lblISBN      = new Label();
            this.txtISBN      = new TextBox();
            this.lblAn        = new Label();
            this.txtAn        = new TextBox();
            this.lblGen       = new Label();
            this.cmbGen       = new ComboBox();
            this.lblExemplare = new Label();
            this.nudExemplare = new NumericUpDown();
            this.lblError     = new Label();
            this.btnSave      = new Button();
            this.btnCancel    = new Button();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudExemplare).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.Add(this.lblFormTitle);
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 50;

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Dock      = DockStyle.Fill;
            this.lblFormTitle.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            this.lblFormTitle.ForeColor = Color.White;
            this.lblFormTitle.Text      = "Adăugare Carte";
            this.lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;

            int lx = 15, tx = 160, tw = 255, y = 65;

            L(this.lblTitlu,    "Titlu *:",        lx, y);
            T(this.txtTitlu,    tx, y,      tw, 0);

            L(this.lblAutor,    "Autor *:",        lx, y + 45);
            this.cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAutor.Font     = new Font("Segoe UI", 9f);
            this.cmbAutor.Location = new Point(tx, y + 45);
            this.cmbAutor.Size     = new Size(tw, 23);
            this.cmbAutor.TabIndex = 1;

            L(this.lblISBN,     "ISBN *:",         lx, y + 90);
            T(this.txtISBN,     tx, y + 90,  tw, 2);
            this.txtISBN.Leave += new EventHandler(this.txtISBN_Leave);

            L(this.lblAn,       "An Publicare *:", lx, y + 135);
            T(this.txtAn,       tx, y + 135, 80, 3);
            this.txtAn.Leave   += new EventHandler(this.txtAn_Leave);

            L(this.lblGen,      "Gen:",            lx, y + 180);
            this.cmbGen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGen.Font     = new Font("Segoe UI", 9f);
            this.cmbGen.Items.AddRange(new object[] { "Roman","Poezie","Fantasy","Sci-Fi","Dramă","Non-ficțiune","Altele" });
            this.cmbGen.Location = new Point(tx, y + 180);
            this.cmbGen.SelectedIndex = 0;
            this.cmbGen.Size     = new Size(150, 23);
            this.cmbGen.TabIndex = 4;

            L(this.lblExemplare,"Nr. Exemplare:",  lx, y + 225);
            this.nudExemplare.Font     = new Font("Segoe UI", 9f);
            this.nudExemplare.Location = new Point(tx, y + 225);
            this.nudExemplare.Maximum  = 999;
            this.nudExemplare.Minimum  = 1;
            this.nudExemplare.Size     = new Size(80, 23);
            this.nudExemplare.TabIndex = 5;
            this.nudExemplare.Value    = 1;

            this.lblError.AutoSize  = false;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.ForeColor = Color.FromArgb(196, 43, 43);
            this.lblError.Location  = new Point(lx, y + 265);
            this.lblError.Size      = new Size(400, 20);
            this.lblError.Text      = "";

            Btn(this.btnSave,   "💾 Salvează", Color.FromArgb(34,139,34),   new Point(tx - 15, y + 290), 6, this.btnSave_Click);
            Btn(this.btnCancel, "❌ Anulează",  Color.FromArgb(108,117,125), new Point(tx + 115, y + 290), 7, this.btnCancel_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.ClientSize          = new Size(450, y + 338);
            this.Controls.AddRange(new Control[] {
                this.panelHeader,
                this.lblTitlu, this.txtTitlu,
                this.lblAutor, this.cmbAutor,
                this.lblISBN,  this.txtISBN,
                this.lblAn,    this.txtAn,
                this.lblGen,   this.cmbGen,
                this.lblExemplare, this.nudExemplare,
                this.lblError, this.btnSave, this.btnCancel });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyPreview      = true;
            this.MaximizeBox     = false;
            this.Name            = "AddEditCarteForm";
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Adăugare Carte Nouă";
            this.KeyDown        += new KeyEventHandler(this.AddEditCarteForm_KeyDown);

            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.nudExemplare).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static void L(Label lbl, string text, int x, int y)
        { lbl.AutoSize=true; lbl.Font=new Font("Segoe UI",9f); lbl.Location=new Point(x,y+4); lbl.Text=text; }
        private static void T(TextBox tb, int x, int y, int w, int tab)
        { tb.Font=new Font("Segoe UI",9f); tb.Location=new Point(x,y); tb.Size=new Size(w,23); tb.TabIndex=tab; }
        private static void Btn(Button btn, string text, Color color, Point loc, int tab, EventHandler handler)
        { btn.BackColor=color; btn.FlatStyle=FlatStyle.Flat; btn.FlatAppearance.BorderSize=0;
          btn.Font=new Font("Segoe UI",9f,FontStyle.Bold); btn.ForeColor=Color.White;
          btn.Location=loc; btn.Size=new Size(120,33); btn.TabIndex=tab; btn.Text=text;
          btn.UseVisualStyleBackColor=false; btn.Cursor=Cursors.Hand; btn.Click+=handler; }

        #endregion

        private Panel           panelHeader;
        private Label           lblFormTitle;
        private Label           lblTitlu;
        private TextBox         txtTitlu;
        private Label           lblAutor;
        private ComboBox        cmbAutor;
        private Label           lblISBN;
        private TextBox         txtISBN;
        private Label           lblAn;
        private TextBox         txtAn;
        private Label           lblGen;
        private ComboBox        cmbGen;
        private Label           lblExemplare;
        private NumericUpDown   nudExemplare;
        private Label           lblError;
        private Button          btnSave;
        private Button          btnCancel;
    }
}
