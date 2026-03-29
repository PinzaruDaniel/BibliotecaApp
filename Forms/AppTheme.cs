namespace BibliotecaApp.Forms
{
    /// <summary>
    /// Clasă statică ce definește schema de culori și fonturi uniforme ale aplicației.
    /// Asigură consistența vizuală pe toate formele (UI/UX).
    /// </summary>
    public static class AppTheme
    {
        // Culori principale
        public static readonly Color PrimaryColor    = Color.FromArgb(26, 60, 90);   // Navy Blue
        public static readonly Color SecondaryColor  = Color.FromArgb(41, 98, 143);  // Medium Blue
        public static readonly Color AccentColor     = Color.FromArgb(70, 160, 220); // Light Blue
        public static readonly Color SuccessColor    = Color.FromArgb(34, 139, 34);  // Forest Green
        public static readonly Color DangerColor     = Color.FromArgb(196, 43, 43);  // Red
        public static readonly Color WarningColor    = Color.FromArgb(220, 140, 10); // Amber
        public static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);
        public static readonly Color PanelColor      = Color.White;
        public static readonly Color HeaderTextColor = Color.White;
        public static readonly Color GridRowAlt      = Color.FromArgb(235, 244, 255);

        // Fonturi
        public static readonly Font TitleFont    = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font ButtonFont   = new Font("Segoe UI", 9f,  FontStyle.Bold);
        public static readonly Font LabelFont    = new Font("Segoe UI", 9f,  FontStyle.Regular);
        public static readonly Font GridFont     = new Font("Segoe UI", 9f,  FontStyle.Regular);
        public static readonly Font HeaderFont   = new Font("Segoe UI", 10f, FontStyle.Bold);

        /// <summary>Stilizează un buton de acțiune principală.</summary>
        public static void StylePrimaryButton(Button btn)
        {
            btn.BackColor = SecondaryColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;
        }

        /// <summary>Stilizează un buton de pericol (ștergere).</summary>
        public static void StyleDangerButton(Button btn)
        {
            btn.BackColor = DangerColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;
        }

        /// <summary>Stilizează un buton secundar (gri).</summary>
        public static void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(108, 117, 125);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;
        }

        /// <summary>Stilizează un DataGridView conform temei aplicației.</summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = PanelColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 230, 240);
            dgv.DefaultCellStyle.Font = GridFont;
            dgv.DefaultCellStyle.SelectionBackColor = AccentColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridRowAlt;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.ColumnHeadersHeight = 38;
            dgv.RowTemplate.Height = 32;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }
    }
}
