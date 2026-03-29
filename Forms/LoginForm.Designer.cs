namespace BibliotecaApp.Forms
{
    partial class LoginForm
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
            this.lblAppTitle    = new Label();
            this.panelCard      = new Panel();
            this.lblCardTitle   = new Label();
            this.lblUser        = new Label();
            this.txtUser        = new TextBox();
            this.lblPass        = new Label();
            this.txtPass        = new TextBox();
            this.lblError       = new Label();
            this.btnLogin       = new Button();
            this.lblDemoHint    = new Label();

            this.panelHeader.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(26, 60, 90);
            this.panelHeader.Controls.Add(this.lblAppTitle);
            this.panelHeader.Dock      = DockStyle.Top;
            this.panelHeader.Height    = 110;
            this.panelHeader.Name      = "panelHeader";

            // lblAppTitle
            this.lblAppTitle.AutoSize  = false;
            this.lblAppTitle.Dock      = DockStyle.Fill;
            this.lblAppTitle.Font      = new Font("Segoe UI", 18f, FontStyle.Bold);
            this.lblAppTitle.ForeColor = Color.White;
            this.lblAppTitle.Name      = "lblAppTitle";
            this.lblAppTitle.Text      = "📚  Gestiune Bibliotecă";
            this.lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelCard
            this.panelCard.BackColor   = Color.White;
            this.panelCard.BorderStyle = BorderStyle.FixedSingle;
            this.panelCard.Controls.AddRange(new Control[] {
                this.lblCardTitle, this.lblUser, this.txtUser,
                this.lblPass, this.txtPass, this.lblError, this.btnLogin });
            this.panelCard.Location    = new Point(40, 130);
            this.panelCard.Name        = "panelCard";
            this.panelCard.Size        = new Size(340, 270);

            // lblCardTitle
            this.lblCardTitle.AutoSize  = false;
            this.lblCardTitle.Font      = new Font("Segoe UI", 12f, FontStyle.Bold);
            this.lblCardTitle.ForeColor = Color.FromArgb(26, 60, 90);
            this.lblCardTitle.Location  = new Point(20, 18);
            this.lblCardTitle.Name      = "lblCardTitle";
            this.lblCardTitle.Size      = new Size(300, 30);
            this.lblCardTitle.Text      = "Conectare la sistem";

            // lblUser
            this.lblUser.AutoSize  = true;
            this.lblUser.Font      = new Font("Segoe UI", 9f);
            this.lblUser.Location  = new Point(20, 68);
            this.lblUser.Name      = "lblUser";
            this.lblUser.Text      = "Utilizator:";

            // txtUser
            this.txtUser.Font      = new Font("Segoe UI", 9f);
            this.txtUser.Location  = new Point(20, 86);
            this.txtUser.Name      = "txtUser";
            this.txtUser.Size      = new Size(300, 23);
            this.txtUser.TabIndex  = 0;
            this.txtUser.Text      = "admin";

            // lblPass
            this.lblPass.AutoSize  = true;
            this.lblPass.Font      = new Font("Segoe UI", 9f);
            this.lblPass.Location  = new Point(20, 120);
            this.lblPass.Name      = "lblPass";
            this.lblPass.Text      = "Parolă:";

            // txtPass
            this.txtPass.Font         = new Font("Segoe UI", 9f);
            this.txtPass.Location     = new Point(20, 138);
            this.txtPass.Name         = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size         = new Size(300, 23);
            this.txtPass.TabIndex     = 1;
            this.txtPass.KeyDown     += new KeyEventHandler(this.txtPass_KeyDown);

            // lblError
            this.lblError.AutoSize  = false;
            this.lblError.Font      = new Font("Segoe UI", 8.5f);
            this.lblError.ForeColor = Color.FromArgb(196, 43, 43);
            this.lblError.Location  = new Point(20, 172);
            this.lblError.Name      = "lblError";
            this.lblError.Size      = new Size(300, 20);
            this.lblError.Text      = "";

            // btnLogin
            this.btnLogin.BackColor             = Color.FromArgb(41, 98, 143);
            this.btnLogin.FlatStyle             = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font                  = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.btnLogin.ForeColor             = Color.White;
            this.btnLogin.Location              = new Point(20, 200);
            this.btnLogin.Name                  = "btnLogin";
            this.btnLogin.Size                  = new Size(300, 38);
            this.btnLogin.TabIndex              = 2;
            this.btnLogin.Text                  = "  Conectare";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Cursor                = Cursors.Hand;
            this.btnLogin.Click                += new EventHandler(this.btnLogin_Click);

            // lblDemoHint
            this.lblDemoHint.AutoSize  = false;
            this.lblDemoHint.Font      = new Font("Segoe UI", 8f, FontStyle.Italic);
            this.lblDemoHint.ForeColor = Color.Gray;
            this.lblDemoHint.Location  = new Point(40, 420);
            this.lblDemoHint.Name      = "lblDemoHint";
            this.lblDemoHint.Size      = new Size(340, 20);
            this.lblDemoHint.Text      = "Demo: admin / biblioteca2026";
            this.lblDemoHint.TextAlign = ContentAlignment.MiddleCenter;

            // LoginForm
            this.AutoScaleDimensions   = new SizeF(7F, 15F);
            this.AutoScaleMode         = AutoScaleMode.Font;
            this.BackColor             = Color.FromArgb(245, 247, 250);
            this.ClientSize            = new Size(420, 460);
            this.Controls.AddRange(new Control[] { this.panelCard, this.lblDemoHint, this.panelHeader });
            this.FormBorderStyle       = FormBorderStyle.FixedSingle;
            this.KeyPreview            = true;
            this.MaximizeBox           = false;
            this.Name                  = "LoginForm";
            this.StartPosition         = FormStartPosition.CenterScreen;
            this.Text                  = "Autentificare – Gestiune Bibliotecă";
            this.KeyDown              += new KeyEventHandler(this.LoginForm_KeyDown);

            this.panelHeader.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel   panelHeader;
        private Label   lblAppTitle;
        private Panel   panelCard;
        private Label   lblCardTitle;
        private Label   lblUser;
        private TextBox txtUser;
        private Label   lblPass;
        private TextBox txtPass;
        private Label   lblError;
        private Button  btnLogin;
        private Label   lblDemoHint;
    }
}
