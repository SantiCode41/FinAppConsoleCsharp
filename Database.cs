using Microsoft.Data.Sqlite;

class Database : IDisposable
{
    private readonly SqliteConnection _connection;
    public Database()
    {
        _connection = new SqliteConnection("Data Source=app.db");
        _connection.Open();
    }

    public void CreateTableUsers()
    {
        var create = _connection.CreateCommand();
        create.CommandText = """
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL
            );
            """;
        create.ExecuteNonQuery();
    }

    public void CreateTableLogs()
    {
        var create = _connection.CreateCommand();
        create.CommandText = """
            CREATE TABLE IF NOT EXISTS Logs (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                User TEXT,
                Type TEXT NOT NULL,
                DateTime TEXT NOT NULL
            );
            """;
        create.ExecuteNonQuery();
    }

    public void InsertStartUpLog(string userName)
    {
        var insert = _connection.CreateCommand();
        string logType = "start up";
        DateTime dateAndTime = DateTime.Now;

        insert.CommandText = """
            INSERT INTO Logs (User, Type, DateTime)
            VALUES ($userName, $logType, $dateAndTime)
            """;
        insert.Parameters.AddWithValue("$userName", userName);
        insert.Parameters.AddWithValue("$logType", logType);
        insert.Parameters.AddWithValue("$dateAndTime", dateAndTime.ToString("g"));

        insert.ExecuteNonQuery();
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}