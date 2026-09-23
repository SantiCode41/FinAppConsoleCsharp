using FinAppCsharp;
using Microsoft.Data.Sqlite;

using var db = new Database();
StartUpSequence.Run(db);

// Prototype of the interactive menu
//int mainMenuSelection = InteractiveMenu.GenerateMenu(["Option 1", "Option 2", "Option 3"]);
//Console.WriteLine(mainMenuSelection);

Helpers.WriteCentered("WELCOME TO DOLLARULE!!!");
int welcomeMenuSelection = InteractiveMenu.GenerateMenu(["ENTER", "QUIT"], 1);
if (welcomeMenuSelection == 2)
{
    Environment.Exit(0);    
}

Helpers.WriteCentered("Log in or Sign up?");
int logInOrSignUpMenuSelection = InteractiveMenu.GenerateMenu(["Log In", "Sign Up"], 1);
string userName = string.Empty;
string password = string.Empty;
string confirmPassword = string.Empty;
if (logInOrSignUpMenuSelection == 1)
{
    Helpers.WriteCentered("Username: ", false);
    userName = Helpers.GetString();
    Helpers.WriteCentered("Password: ", false);
    password = Helpers.GetString();
    Helpers.LogIn(userName, password);
}
else if (logInOrSignUpMenuSelection == 2)
{
    //Helpers.CreateNewAccount(db);
}

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

if (menuChoiceInt != 1 && menuChoiceInt != 2)
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
    CreateBudget.Run(db);
}
else
{
    Environment.Exit(2);
}

// Program Ending
Console.WriteLine("Thank you for using Dollarule");
