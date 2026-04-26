using BibliotecaApp.Database;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace BibliotecaApp.Forms
{
    public partial class CartiForm : Form
    {
        private DataTable _fullData = new();

        public CartiForm()
        {
            Text = "Cărți";
            InitializeComponent();
            MakeBtn(btnAdd, "➕ Adaugă", Color.FromArgb(34, 139, 34), new Point(19, 26), btnAdd_Click);
            MakeBtn(btnEdit, "✏️ Editează", Color.FromArgb(100, 130, 160), new Point(137, 26), btnEdit_Click);
            MakeBtn(btnDelete, "🗑️ Șterge", Color.FromArgb(196, 43, 43), new Point(255, 26), btnDelete_Click);
            MakeBtn(btnRefresh, "🔄 Reîncarcă", Color.FromArgb(100, 120, 140), new Point(373, 26), btnRefresh_Click);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _fullData = DatabaseHelper.ExecuteQuery(@"
                    SELECT c.CarteID, c.Titlu,
                           a.Prenume + ' ' + a.Nume AS Autor,
                           c.ISBN, c.AnPublicare, c.Gen,
                           c.NrExemplare, c.NrDisponibil
                    FROM Carti c
                    JOIN Autori a ON c.AutorID = a.AutorID
                    ORDER BY c.Titlu");
                grid.DataSource = _fullData;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (grid.Columns.Count == 0) return;
            grid.Columns["CarteID"].Width     = 45;  grid.Columns["CarteID"].HeaderText     = "ID";
            grid.Columns["Titlu"].Width       = 220; grid.Columns["Titlu"].HeaderText       = "Titlu";
            grid.Columns["Autor"].Width       = 160; grid.Columns["Autor"].HeaderText       = "Autor";
            grid.Columns["ISBN"].Width        = 145; grid.Columns["ISBN"].HeaderText        = "ISBN";
            grid.Columns["AnPublicare"].Width = 55;  grid.Columns["AnPublicare"].HeaderText = "An";
            grid.Columns["Gen"].Width         = 90;  grid.Columns["Gen"].HeaderText         = "Gen";
            grid.Columns["NrExemplare"].Width = 65;  grid.Columns["NrExemplare"].HeaderText = "Total";
            grid.Columns["NrDisponibil"].Width= 65;  grid.Columns["NrDisponibil"].HeaderText= "Disp.";
        }

        private void FilterData()
        {
            string q   = txtSearch.Text.Trim();
            string gen = cmbGen.SelectedItem?.ToString() ?? "Toate";
            var rows = _fullData.AsEnumerable();
            if (!string.IsNullOrEmpty(q))
                rows = rows.Where(r =>
                    r["Titlu"].ToString()!.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    r["ISBN"].ToString()!.Contains(q,  StringComparison.OrdinalIgnoreCase) ||
                    r["Autor"].ToString()!.Contains(q, StringComparison.OrdinalIgnoreCase));
            if (gen != "Toate")
                rows = rows.Where(r => r["Gen"].ToString() == gen);
            var list = rows.ToList();
            grid.DataSource = list.Count > 0 ? list.CopyToDataTable() : _fullData.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new AddEditCarteForm().ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați o carte!", "Atenție"); return; }
            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["CarteID"].Value);
            if (new AddEditCarteForm(id).ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0) { MessageBox.Show("Selectați o carte!", "Atenție"); return; }
            int    id    = Convert.ToInt32(grid.SelectedRows[0].Cells["CarteID"].Value);
            string title = grid.SelectedRows[0].Cells["Titlu"].Value.ToString()!;
            if (MessageBox.Show($"Ștergeți cartea «{title}»?", "Confirmare Ștergere",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Carti WHERE CarteID = @id",
                    new SqlParameter("@id", id));
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show($"Eroare: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterData();
        private void cmbGen_SelectedIndexChanged(object sender, EventArgs e) => FilterData();
    }
}
