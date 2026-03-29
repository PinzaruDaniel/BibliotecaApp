using BibliotecaApp.Database;

namespace BibliotecaApp.Forms
{
    public partial class LoginForm : Form
    {
        private int _failedAttempts = 0;
        private const string DEMO_USER = "admin";
        private const string DEMO_PASS = "biblioteca2026";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                lblError.Text = "Completați utilizatorul și parola!";
                return;
            }

            if (txtUser.Text.Trim() == DEMO_USER && txtPass.Text == DEMO_PASS)
            {
                if (!DatabaseHelper.TestConnection(out string dbError))
                {
                    var result = MessageBox.Show(
                        $"Atenție: Nu s-a putut conecta la baza de date.\n{dbError}\n\n" +
                        "Doriți să continuați în modul offline?",
                        "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }

                var mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                _failedAttempts++;
                lblError.Text = $"Credențiale incorecte! (Încercarea {_failedAttempts}/3)";
                txtPass.Clear();
                txtPass.Focus();

                if (_failedAttempts >= 3)
                {
                    MessageBox.Show("Prea multe încercări eșuate. Aplicația se va închide.",
                        "Securitate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }
    }
}
