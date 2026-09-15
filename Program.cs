using FinAppCsharp;
using Microsoft.Data.Sqlite;

using var db = new Database();
StartUpSequence.Run(db);

Console.WriteLine("WELCOME TO DOLLARULE!!!");
Console.Write("Username: ");
string userName = string.Empty;
userName = Helpers.GetString();

db.InsertStartUpLog(userName);

Console.WriteLine($"Welcome {userName}");
Thread.Sleep(3000);

string menuText = """

    1 - View Budget
    2 - Create Budget
    Make Selection: 
    """;
Console.Write(menuText);
string menuChoice = Helpers.GetString();
int menuChoiceInt = 0;
if (int.TryParse(menuChoice, out int n))
{
    menuChoiceInt = n;
}
else
{
    Console.WriteLine("Not a valid selection.");
    Thread.Sleep(2000);
    Environment.Exit(1);
}

if (menuChoiceInt == 0)
{
    Console.WriteLine("Not a valid selection.");
    Thread.Sleep(2000);
    Environment.Exit(1);
}
else if (menuChoiceInt == 1)
{
    // Run the ViewBudget class
}
else if (menuChoiceInt == 2)
{
    // Run the CreateBudget class
}
else
{
    Environment.Exit(2);
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("Screen should be clear now");
