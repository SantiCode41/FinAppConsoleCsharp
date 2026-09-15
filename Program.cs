using Microsoft.Data.Sqlite;

using var db = new Database();
db.CreateTableUsers();
db.CreateTableLogs();

Console.WriteLine("WELCOME TO DOLLARULE!!!");

Console.Write("Username: ");
string userName = Console.ReadLine();
db.InsertStartUpLog(userName);

Console.WriteLine($"Welcome {userName}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("Screen should be clear now");




