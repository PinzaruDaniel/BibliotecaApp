namespace BibliotecaApp.Forms
{
    partial class AddEditImprumutForm
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
            this.lblFormTitle   = new Label();
            this.lblCarte       = new Label();
            this.cmbCarte       = new ComboBox();
            this.lblNumeCititor = new Label();
            this.txtNumeCititor = new TextBox();
            this.lblCNP         = new Label();
            this.txtCNP         = new TextBox();
            this.lblTelefon     = new Label();
            this.txtTelefon     = new TextBox();
            this.lblDataImp     = new Label();
            this.dtpImprumut    = new DateTimePicker();
            this.lblTermen      = new Label();
            this.dtpTermen      = new DateTimePicker();
            this.lblTarif       = new Label();
            this.nudTarif       = new NumericUpDown();
            this.lblTarifUnit   = new Label();
            this.lblError       = new Label();
            this.btnSave        = new Button();
            this.btnCancel      = new Button();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudTarif).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.Add(this.lblFormTitle);
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 50;

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Dock      = DockStyle.Fill;
            this.lblFormTitle.Font      = new Font("Segoe UI", 12f, FontStyle.Bold);
            this.lblFormTitle.ForeColor = Color.White;
            this.lblFormTitle.Text      = "Împrumut Nou";
            this.lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;

            int lx = 15, tx = 170, tw = 245, y = 65;

            L(this.lblCarte,       "Carte *:",           lx, y);
            this.cmbCarte.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCarte.Font          = new Font("Segoe UI", 9f);
            this.cmbCarte.Location      = new Point(tx, y);
            this.cmbCarte.Size          = new Size(tw, 23);
            this.cmbCarte.TabIndex      = 0;

            L(this.lblNumeCititor, "Nume Cititor *:",    lx, y + 45);
            T(this.txtNumeCititor, tx, y + 45, tw, 1);

            L(this.lblCNP,         "CNP *:",             lx, y + 90);
            T(this.txtCNP,         tx, y + 90, 140, 2);
            this.txtCNP.Leave += new EventHandler(this.txtCNP_Leave);

            L(this.lblTelefon,     "Telefon:",           lx, y + 135);
            T(this.txtTelefon,     tx, y + 135, 140, 3);
            this.txtTelefon.Leave += new EventHandler(this.txtTelefon_Leave);

            L(this.lblDataImp,     "Data Împrumut *:",   lx, y + 180);
            this.dtpImprumut.Format   = DateTimePickerFormat.Short;
            this.dtpImprumut.Location = new Point(tx, y + 178);
            this.dtpImprumut.Size     = new Size(tw, 23);
            this.dtpImprumut.TabIndex = 4;
            this.dtpImprumut.Value    = DateTime.Today;

            L(this.lblTermen,      "Termen Returnare *:",lx, y + 225);
            this.dtpTermen.Format   = DateTimePickerFormat.Short;
            this.dtpTermen.Location = new Point(tx, y + 223);
            this.dtpTermen.Size     = new Size(tw, 23);
            this.dtpTermen.TabIndex = 5;
            this.dtpTermen.Value    = DateTime.Today.AddDays(14);

            L(this.lblTarif,       "Tarif penalitate:",  lx, y + 270);
            this.nudTarif.DecimalPlaces = 2;
            this.nudTarif.Font          = new Font("Segoe UI", 9f);
            this.nudTarif.Increment     = 0.25m;
            this.nudTarif.Location      = new Point(tx, y + 268);
            this.nudTarif.Maximum       = 100;
            this.nudTarif.Minimum       = 0;
            this.nudTarif.Size          = new Size(90, 23);
            this.nudTarif.TabIndex      = 6;
            this.nudTarif.Value         = 0.50m;

            this.lblTarifUnit.AutoSize = true;
            this.lblTarifUnit.Font     = new Font("Segoe UI", 9f);
            this.lblTarifUnit.Location = new Point(tx + 98, y + 272);
            this.lblTarifUnit.Text     = "USD / zi întârziere";

            this.lblError.AutoSize  = false;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.ForeColor = Color.FromArgb(196, 43, 43);
            this.lblError.Location  = new Point(lx, y + 305);
            this.lblError.Size      = new Size(400, 20);
            this.lblError.Text      = "";

            Btn(this.btnSave,   "💾 Salvează", Color.FromArgb(34,139,34),   new Point(tx - 15, y + 330), 7, this.btnSave_Click);
            Btn(this.btnCancel, "❌ Anulează",  Color.FromArgb(108,117,125), new Point(tx + 115, y + 330), 8, this.btnCancel_Click);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.ClientSize          = new Size(450, y + 380);
            this.Controls.AddRange(new Control[] {
                this.panelHeader,
                this.lblCarte, this.cmbCarte,
                this.lblNumeCititor, this.txtNumeCititor,
                this.lblCNP, this.txtCNP,
                this.lblTelefon, this.txtTelefon,
                this.lblDataImp, this.dtpImprumut,
                this.lblTermen, this.dtpTermen,
                this.lblTarif, this.nudTarif, this.lblTarifUnit,
                this.lblError, this.btnSave, this.btnCancel });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyPreview      = true;
            this.MaximizeBox     = false;
            this.Name            = "AddEditImprumutForm";
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Text            = "Înregistrare Împrumut Nou";
            this.KeyDown        += new KeyEventHandler(this.AddEditImprumutForm_KeyDown);

            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.nudTarif).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static void L(Label lbl, string t, int x, int y)
        { lbl.AutoSize=true; lbl.Font=new Font("Segoe UI",9f); lbl.Location=new Point(x,y+4); lbl.Text=t; }
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
        private Label           lblCarte;
        private ComboBox        cmbCarte;
        private Label           lblNumeCititor;
        private TextBox         txtNumeCititor;
        private Label           lblCNP;
        private TextBox         txtCNP;
        private Label           lblTelefon;
        private TextBox         txtTelefon;
        private Label           lblDataImp;
        private DateTimePicker  dtpImprumut;
        private Label           lblTermen;
        private DateTimePicker  dtpTermen;
        private Label           lblTarif;
        private NumericUpDown   nudTarif;
        private Label           lblTarifUnit;
        private Label           lblError;
        private Button          btnSave;
        private Button          btnCancel;
    }
}
