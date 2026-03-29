using BibliotecaApp.Database;
using BibliotecaApp.Forms;
using System.Text.Json;

namespace BibliotecaApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            var json = File.ReadAllText("appsettings.json");
            var doc  = JsonDocument.Parse(json);
            var cs   = doc.RootElement.GetProperty("ConnectionString").GetString() ?? "";
            DatabaseHelper.SetConnectionString(cs);
            MessageBox.Show($"CS: {cs}", "Debug");
        }
        catch
        {
            MessageBox.Show(
                "Nu s-a putut încărca configurația aplicației.\nVerificați fișierul appsettings.json.",
                "Eroare Configurație", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Application.Run(new SplashForm());
    }
}
