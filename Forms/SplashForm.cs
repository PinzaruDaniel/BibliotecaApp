using BibliotecaApp.Database;

namespace BibliotecaApp.Forms
{
    public partial class SplashForm : Form
    {
        private int _step = 0;

        private readonly string[] _statusMessages =
        {
            "Inițializare aplicație...",
            "Verificare conexiune bază de date...",
            "Încărcare configurație...",
            "Pregătire interfață...",
            "Gata!"
        };

        public SplashForm()
        {
            InitializeComponent();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            _step++;
            progressBar.Value   = Math.Min(_step * 20, 100);
            lblStatus.Text      = _step <= 4 ? _statusMessages[_step] : _statusMessages[4];

            if (_step >= 5)
            {
                timerSplash.Stop();
                OpenLoginForm();
            }
        }

        private void OpenLoginForm()
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
