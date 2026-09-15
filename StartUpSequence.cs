class StartUpSequence
{
    public static void Run(Database db)
    {
        db.CreateTableUsers();
        db.CreateTableLogs();
    }
}