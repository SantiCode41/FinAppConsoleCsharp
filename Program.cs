using Microsoft.Data.Sqlite;

using var db = new Database();
StartUpSequence.Run(db);

Console.WriteLine("WELCOME TO DOLLARULE!!!");
Console.Write("Username: ");
string userName = string.Empty;
try
{
    userName = Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong: {ex.Message}");
    Environment.Exit(1);
}

db.InsertStartUpLog(userName);

Console.WriteLine($"Welcome {userName}");
Console.ReadLine();
Console.Clear();
Console.WriteLine("Screen should be clear now");
