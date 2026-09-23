using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
using FinAppCsharp;

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
                Username TEXT NOT NULL UNIQUE,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Password TEXT NOT NULL
            );
            """;
        create.ExecuteNonQuery();
    }

    public User AddUserToUserTable(User newUser)
    {
        var insert = _connection.CreateCommand();
        insert.CommandText = """
            INSERT INTO Users (Username, FirstName, LastName, Password)
            VALUES ($username, $firstname, $lastname, $password)
            """;
        insert.Parameters.AddWithValue("$username", newUser.username);
        insert.Parameters.AddWithValue("$firstname", newUser.firstName);
        insert.Parameters.AddWithValue("$lastname", newUser.lastName);
        insert.Parameters.AddWithValue("$password", newUser.password);
        insert.ExecuteNonQuery();

        var query = _connection.CreateCommand();
        query.CommandText = "SELECT Id FROM Users WHERE Username = $username;";
        query.Parameters.AddWithValue("$username", newUser.username);
        long userId = (long)query.ExecuteScalar();

        newUser.userId = userId;
        if (newUser.userId == -1)
        {
            Console.WriteLine("Error updating user Id after adding user to user table");
            Environment.Exit(2);
        }

        return newUser;
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

    public void CreateTableBudget()
    {
        var create = _connection.CreateCommand();
        create.CommandText = """
            CREATE TABLE IF NOT EXISTS Budget (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Type TEXT,
                Month TEXT,
                Date TEXT,
                Day INTEGER,
                Item TEXT,
                Amount REAL,
                Balance REAL,
                Notes TEXT
            );
            """;
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

    public bool FindUserInUserTable(string userName)
    {
        var lookup = _connection.CreateCommand();
        lookup.CommandText = """
            SELECT COUNT(*) FROM Users WHERE Username = $userName;
            """;
        lookup.Parameters.AddWithValue("$userName", userName);
        long count = (long)lookup.ExecuteScalar();
        if (count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool PasswordCheck(string username, string passwordEntered)
    {
        var query = _connection.CreateCommand();
        query.CommandText = """
            SELECT Password FROM Users WHERE Username = $username;
            """;
        query.Parameters.AddWithValue("$username", username);
        string userPassword = (string)query.ExecuteScalar();
        if (passwordEntered.Equals(userPassword, StringComparison.Ordinal))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public User GetUser(string username)
    {
        var query = _connection.CreateCommand();
        query.CommandText = "SELECT * FROM Users WHERE Username = $username;";
        query.Parameters.AddWithValue("$username", username);
        using var reader = query.ExecuteReader();
        // I may change the following lines later to use Reflection so I can learn it
        User userFound = new User();
        reader.Read();
        userFound.userId = reader.GetInt64(reader.GetOrdinal("Id"));
        userFound.username = reader.GetString(reader.GetOrdinal("Username"));
        userFound.firstName = reader.GetString(reader.GetOrdinal("FirstName"));
        userFound.lastName = reader.GetString(reader.GetOrdinal("LastName"));
        userFound.password = reader.GetString(reader.GetOrdinal("Password"));
        return userFound;
        
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}