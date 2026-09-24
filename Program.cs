using FinAppCsharp;
using Microsoft.Data.Sqlite;

using var db = new Database();
StartUpSequence.Run(db);

// Prototype program loop
string desiredAction = "Main Menu";
User currentUser = new User();
int welcomeMenuSelection;
int logInOrSignUpMenuSelection;
bool running = true;
while (running)
{
    switch (desiredAction)
    {
        case "Main Menu":
            Helpers.WriteCentered("WELCOME TO DOLLARULE!!!");
            welcomeMenuSelection = InteractiveMenu.GenerateMenu(["ENTER", "QUIT"], 1);
            if (welcomeMenuSelection == 1)
            {
                desiredAction = "Log In or Sign Up";
            }
            else if (welcomeMenuSelection == 2)
            {
                desiredAction = "Exit Program";
            }
            break;
        case "Log In or Sign Up":
            Helpers.WriteCentered("Log in or Sign up?");
            logInOrSignUpMenuSelection = InteractiveMenu.GenerateMenu(["Log In", "Sign Up"], 1);
            
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
        default:
            Console.WriteLine("Invalid action requested.");
            Console.WriteLine("Closing program.");
            Thread.Sleep(2500);
            running = false;
            break;

    }
}

Console.WriteLine("Program loop has been exited");
return;

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
