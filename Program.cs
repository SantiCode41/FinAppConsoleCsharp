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
User currentUser = new User();

if (logInOrSignUpMenuSelection == 1)  // Log In
{
    currentUser.Copy(Helpers.LogIn(db));
    if (currentUser.userId != -1)
    {
        Helpers.WriteCentered("LOG IN SUCCEEDED");
        Thread.Sleep(2000);
    }
}
else if (logInOrSignUpMenuSelection == 2)  // Sign Up
{
    currentUser.Copy(Helpers.CreateNewAccount(db));

}

db.InsertStartUpLog(currentUser.username);
Console.Clear();

Helpers.WriteCentered($"Welcome {currentUser.username}");
Helpers.WriteCentered($"Please make a selection");

int mainMenuSelection = InteractiveMenu.GenerateMenu(["View Budget", "Create Budget"], 2);

if (mainMenuSelection == 1)  // View Budget
{
    //TODO - Run the ViewBudget class
}
else if (mainMenuSelection == 2)  // Create budget
{
    //TODO - Run the CreateBudget class
    CreateBudget.Run(db);
}
else
{
    Console.WriteLine("Error occured at main menu");
    Environment.Exit(3);
}

// Program Ending
Console.WriteLine("Thank you for using Dollarule");
