using Microsoft.Data.Sqlite;

namespace StudentWorksheetStarter.Data
{
    public static class Database
    {
        public static SqliteConnection GetConnection()
        {
            var connection =
                new SqliteConnection("Data Source=students.db");
            connection.Open();
            return connection;
        }
    }
}