using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BibliotecaApp.Forms
{
    public partial class AutoriForm : Form
    {
        private DataTable _fullData = new();

        public AutoriForm()
        {
            Text = "Autori";
            InitializeComponent();
            StyleToolbarButton(btnAdd, "➕ Adaugă", Color.FromArgb(34, 139, 34), new Point(19, 26), btnAdd_Click);
            StyleToolbarButton(btnEdit, "✏️ Editează", Color.FromArgb(100, 130, 160), new Point(142, 26), btnEdit_Click);
            StyleToolbarButton(btnDelete, "🗑️ Șterge", Color.FromArgb(196, 43, 43), new Point(265, 26), btnDelete_Click);
            StyleToolbarButton(btnRefresh, "🔄 Reîncarcă", Color.FromArgb(100, 120, 140), new Point(388, 26), btnRefresh_Click);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _fullData = DatabaseHelper.ExecuteQuery(
                    "SELECT AutorID, Nume, Prenume, DataNasterii, Nationalitate, DataAdaugare FROM Autori ORDER BY Nume, Prenume");
                grid.DataSource = _fullData;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor:\n{ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (grid.Columns.Count == 0) return;
            grid.Columns["AutorID"].HeaderText       = "ID";             grid.Columns["AutorID"].Width       = 50;
            grid.Columns["Nume"].HeaderText          = "Nume";           grid.Columns["Nume"].Width          = 150;
            grid.Columns["Prenume"].HeaderText       = "Prenume";        grid.Columns["Prenume"].Width       = 150;
            grid.Columns["DataNasterii"].HeaderText  = "Data Nașterii";  grid.Columns["DataNasterii"].Width  = 120;
            grid.Columns["Nationalitate"].HeaderText = "Naționalitate";  grid.Columns["Nationalitate"].Width = 120;
            grid.Columns["DataAdaugare"].HeaderText  = "Înregistrat";    grid.Columns["DataAdaugare"].Width  = 130;
        }

        private void FilterData()
        {
            string q = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(q))
            {
                grid.DataSource = _fullData;
                return;
            }
            var filtered = _fullData.AsEnumerable()
                .Where(r => r["Nume"].ToString()!.Contains(q, StringComparison.OrdinalIgnoreCase)
                         || r["Prenume"].ToString()!.Contains(q, StringComparison.OrdinalIgnoreCase))
                .ToList();
            grid.DataSource = filtered.Count > 0 ? filtered.CopyToDataTable() : _fullData.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new AddEditAutorForm().ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați un autor!", "Atenție"); return; }
            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["AutorID"].Value);
            if (new AddEditAutorForm(id).ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați un autor!", "Atenție"); return; }
            int    id   = Convert.ToInt32(grid.SelectedRows[0].Cells["AutorID"].Value);
            string name = $"{grid.SelectedRows[0].Cells["Prenume"].Value} {grid.SelectedRows[0].Cells["Nume"].Value}";

            if (MessageBox.Show($"Ștergeți autorul «{name}»?\nAceastă acțiune este ireversibilă.",
                    "Confirmare Ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Autori WHERE AutorID = @id",
                    new SqlParameter("@id", id));
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nu s-a putut șterge autorul.\n{ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterData();

        private void AutoriForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) btnAdd_Click(sender, e);
            if (e.KeyCode == Keys.Delete)         btnDelete_Click(sender, e);
            if (e.KeyCode == Keys.F5)             LoadData();
        }
    }
}
