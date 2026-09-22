using FinAppCsharp;

class CreateBudget
{
    public static void Run(Database db)
    {
        db.CreateTableBudget();

        Console.Clear();
        string menuText = """
            1 - Create Manually
            2 - Upload File
            """;
        Console.WriteLine(menuText);

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
            // Run the CreateManually method
            CreateManually(db);
        }
        else if (menuChoiceInt == 2)
        {
            // Run the UploadFile method
        }
        else
        {
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
