using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppCsharp
{
    internal class Helpers
    {
        public static string GetString(string outputText = "")
        {
            if (outputText != "")
            {
                Console.Write(outputText);
            }
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

        public static void WriteCentered(string text, bool newLine = true)
        {
            int left = Math.Max(0, (Console.WindowWidth - text.Length) / 2);
            Console.SetCursorPosition(left, Console.CursorTop);
            if (!newLine)
            {
                Console.Write(text);
            }
            else
            {
                Console.WriteLine(text);
            }
        }
    }
}
