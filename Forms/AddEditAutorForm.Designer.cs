namespace BibliotecaApp.Forms
{
    partial class AddEditAutorForm
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
            this.panelHeader        = new Panel();
            this.lblFormTitle       = new Label();
            this.lblNume            = new Label();
            this.txtNume            = new TextBox();
            this.lblPrenume         = new Label();
            this.txtPrenume         = new TextBox();
            this.lblNationalitate   = new Label();
            this.txtNationalitate   = new TextBox();
            this.lblDataNasterii    = new Label();
            this.chkNastere         = new CheckBox();
            this.dtpNastere         = new DateTimePicker();
            this.lblBiografie       = new Label();
            this.txtBiografie       = new RichTextBox();
            this.lblError           = new Label();
            this.btnSave            = new Button();
            this.btnCancel          = new Button();

            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.Add(this.lblFormTitle);
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 50;
            this.panelHeader.Name      = "panelHeader";

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Dock      = DockStyle.Fill;
            this.lblFormTitle.Font      = new Font("Segoe UI", 13f, FontStyle.Bold);
            this.lblFormTitle.ForeColor = Color.White;
            this.lblFormTitle.Name      = "lblFormTitle";
            this.lblFormTitle.Text      = "Adăugare Autor";
            this.lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;

            int lx = 15, tx = 160, tw = 255, y = 65;

            // Nume
            PlaceLabel(this.lblNume, "Nume *:", lx, y);
            PlaceTextBox(this.txtNume, tx, y, tw, 0);
            this.txtNume.Leave += new EventHandler(this.txtNume_Leave);

            // Prenume
            PlaceLabel(this.lblPrenume, "Prenume *:", lx, y + 45);
            PlaceTextBox(this.txtPrenume, tx, y + 45, tw, 1);
            this.txtPrenume.Leave += new EventHandler(this.txtPrenume_Leave);

            // Nationalitate
            PlaceLabel(this.lblNationalitate, "Naționalitate:", lx, y + 90);
            PlaceTextBox(this.txtNationalitate, tx, y + 90, tw, 2);
            this.txtNationalitate.Text = "Română";

            // Data nasterii
            PlaceLabel(this.lblDataNasterii, "Data Nașterii:", lx, y + 135);
            this.chkNastere.AutoSize     = true;
            this.chkNastere.Font         = new Font("Segoe UI", 9f);
            this.chkNastere.Location     = new Point(tx, y + 137);
            this.chkNastere.Name         = "chkNastere";
            this.chkNastere.Text         = "Specificat";
            this.chkNastere.TabIndex     = 3;
            this.chkNastere.CheckedChanged += new EventHandler(this.chkNastere_CheckedChanged);

            this.dtpNastere.Enabled      = false;
            this.dtpNastere.Format       = DateTimePickerFormat.Short;
            this.dtpNastere.Location     = new Point(tx + 90, y + 133);
            this.dtpNastere.Name         = "dtpNastere";
            this.dtpNastere.Size         = new Size(165, 23);
            this.dtpNastere.TabIndex     = 4;
            this.dtpNastere.Value        = new DateTime(1950, 1, 1);

            // Biografie
            PlaceLabel(this.lblBiografie, "Biografie:", lx, y + 180);
            this.txtBiografie.BorderStyle = BorderStyle.FixedSingle;
            this.txtBiografie.Font        = new Font("Segoe UI", 9f);
            this.txtBiografie.Location    = new Point(tx, y + 178);
            this.txtBiografie.Name        = "txtBiografie";
            this.txtBiografie.Size        = new Size(tw, 90);
            this.txtBiografie.TabIndex    = 5;

            // lblError
            this.lblError.AutoSize  = false;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.ForeColor = Color.FromArgb(196, 43, 43);
            this.lblError.Location  = new Point(lx, y + 280);
            this.lblError.Name      = "lblError";
            this.lblError.Size      = new Size(400, 20);
            this.lblError.Text      = "";

            // Buttons
            StyleDialogButton(this.btnSave,   "💾 Salvează", Color.FromArgb(34,139,34), new Point(tx - 15, y + 307), 6, this.btnSave_Click);
            StyleDialogButton(this.btnCancel, "❌ Anulează",  Color.FromArgb(108,117,125), new Point(tx + 115, y + 307), 7, this.btnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode       = AutoScaleMode.Font;
            this.BackColor           = Color.FromArgb(245, 247, 250);
            this.ClientSize          = new Size(450, y + 355);
            this.Controls.AddRange(new Control[] {
                this.panelHeader,
                this.lblNume, this.txtNume,
                this.lblPrenume, this.txtPrenume,
                this.lblNationalitate, this.txtNationalitate,
                this.lblDataNasterii, this.chkNastere, this.dtpNastere,
                this.lblBiografie, this.txtBiografie,
                this.lblError, this.btnSave, this.btnCancel });
            this.FormBorderStyle     = FormBorderStyle.FixedDialog;
            this.KeyPreview          = true;
            this.MaximizeBox         = false;
            this.Name                = "AddEditAutorForm";
            this.StartPosition       = FormStartPosition.CenterParent;
            this.Text                = "Adăugare Autor Nou";
            this.KeyDown            += new KeyEventHandler(this.AddEditAutorForm_KeyDown);

            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static void PlaceLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font     = new Font("Segoe UI", 9f);
            lbl.Location = new Point(x, y + 4);
            lbl.Text     = text;
        }
        private static void PlaceTextBox(TextBox tb, int x, int y, int w, int tabIndex)
        {
            tb.Font     = new Font("Segoe UI", 9f);
            tb.Location = new Point(x, y);
            tb.Size     = new Size(w, 23);
            tb.TabIndex = tabIndex;
        }
        private static void StyleDialogButton(Button btn, string text, Color color, Point loc, int tabIndex, EventHandler handler)
        {
            btn.BackColor             = color;
            btn.FlatStyle             = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                  = new Font("Segoe UI", 9f, FontStyle.Bold);
            btn.ForeColor             = Color.White;
            btn.Location              = loc;
            btn.Name                  = "btn_" + text.Trim();
            btn.Size                  = new Size(120, 33);
            btn.TabIndex              = tabIndex;
            btn.Text                  = text;
            btn.UseVisualStyleBackColor = false;
            btn.Cursor                = Cursors.Hand;
            btn.Click                += handler;
        }

        #endregion

        private Panel           panelHeader;
        private Label           lblFormTitle;
        private Label           lblNume;
        private TextBox         txtNume;
        private Label           lblPrenume;
        private TextBox         txtPrenume;
        private Label           lblNationalitate;
        private TextBox         txtNationalitate;
        private Label           lblDataNasterii;
        private CheckBox        chkNastere;
        private DateTimePicker  dtpNastere;
        private Label           lblBiografie;
        private RichTextBox     txtBiografie;
        private Label           lblError;
        private Button          btnSave;
        private Button          btnCancel;
    }
}
