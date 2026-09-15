using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppCsharp
{
    internal class Helpers
    {
        public static string GetString()
        {
            string returnString = string.Empty;
            try
            {
                returnString = Console.ReadLine();
                if (string.IsNullOrEmpty(returnString))
                {
                    Console.WriteLine("Error at GetString.");
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
                Environment.Exit(1);
            }
            return returnString;
        }
    }
}
