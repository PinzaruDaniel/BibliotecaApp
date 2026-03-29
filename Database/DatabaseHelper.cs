using Microsoft.Data.SqlClient;
using System.Data;

namespace BibliotecaApp.Database
{
    /// <summary>
    /// Clasă helper pentru gestionarea conexiunii și operațiunilor cu baza de date Azure SQL.
    /// Implementează pattern-ul de acces centralizat la date.
    /// </summary>
    public static class DatabaseHelper
    {
        private static string _connectionString = "";

        public static void SetConnectionString(string cs) => _connectionString = cs;
        public static string GetConnectionString() => _connectionString;

        public static SqlConnection GetConnection() => new SqlConnection(_connectionString);

        /// <summary>Execută un SELECT și returnează un DataTable.</summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            try
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = new SqlCommand(sql, conn);
                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                using var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Eroare bază de date (SQL {ex.Number}): {ex.Message}");
            }
            return dt;
        }

        /// <summary>Execută INSERT / UPDATE / DELETE și returnează numărul de rânduri afectate.</summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = new SqlCommand(sql, conn);
                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Eroare bază de date (SQL {ex.Number}): {ex.Message}");
            }
        }

        /// <summary>Execută o interogare și returnează prima celulă a primului rând.</summary>
        public static object? ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                using var cmd = new SqlCommand(sql, conn);
                if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Eroare bază de date (SQL {ex.Number}): {ex.Message}");
            }
        }

        /// <summary>Testează dacă conexiunea la baza de date este activă.</summary>
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using var conn = GetConnection();
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
