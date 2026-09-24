using FinAppCsharp;

class CreateBudget
{
    public static void Run(Database db)
    {
        db.CreateTableBudget();

        Console.Clear();
        Helpers.WriteCentered("Create New Budget");
        int createBudgetMenuSelection = InteractiveMenu.GenerateMenu(["Create Manually", "Create from upload file"], 1);

        if (createBudgetMenuSelection == 1)
        {
            //TODO - Run the CreateManually method

        }
        else if (createBudgetMenuSelection == 2)
        {
            //TODO - Run the CreateViaUploadFile method
        }
        else
        {
            Console.WriteLine("Error at create budget menu selection");
            Environment.Exit(2);
        }

    }

    private static void CreateManually(Database db)
    {
        Console.WriteLine("Enter the requested information");
        string dueDate = Helpers.GetString("Due Date: ");
        string item = Helpers.GetString("Item Name: ");
        string notes = Helpers.GetString("Notes: ");
        string type = Helpers.GetString("Type (In or Out): ");
    }
}
