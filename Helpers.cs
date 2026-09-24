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

        public static User LogIn(Database db)
        {
            string username;
            string password;
            User userFound = new User();
            // Query DB for userName and password match
            while (true)
            {
                Helpers.WriteCentered("Username: ", false);
                username = Helpers.GetString();
                Helpers.WriteCentered("Password: ", false);
                password = Helpers.GetString();

                if (!db.FindUserInUserTable(username))
                {
                    Helpers.WriteCentered("Invalid log in attempt");
                    Helpers.WriteCentered("Please try again");

                }
                else
                {
                    if (!db.PasswordCheck(username, password))
                    {
                        Helpers.WriteCentered("Invalid log in attempt");
                        Helpers.WriteCentered("Please try again");
                    }
                    else
                    {
                        userFound.Copy(db.GetUser(username));
                        return userFound;
                    }
                }
            }
            // This code will be reachable once I add the menu option after a failed attempt
            // that will ask a user if they want to try again or exit.
            return userFound;
        }

        public static User CreateNewAccount(Database db)
        {
            bool userNameFound = true;
            string username = string.Empty;
            while (userNameFound)
            {
                Helpers.WriteCentered("Enter desired Username: ", false);
                username = Helpers.GetString();
                if (!db.FindUserInUserTable(username))
                {
                    userNameFound = false;
                }
                else
                {
                    Helpers.WriteCentered("Username is already take.");
                    Helpers.WriteCentered("Please choose a different Username.");
                }
            }

            bool passwordsMatch = false;
            string password = string.Empty;
            string verifyPassword = string.Empty;
            while (!passwordsMatch)
            {
                Helpers.WriteCentered("Enter password: ", false);
                password = Helpers.GetString();
                Helpers.WriteCentered("Reenter password: ", false);
                verifyPassword = Helpers.GetString();
                if (password.Equals(verifyPassword, StringComparison.Ordinal))
                {
                    passwordsMatch = true;
                }
                else
                {
                    Helpers.WriteCentered("Passwords did not match! Please try again.");
                }
            }

            Helpers.WriteCentered("Enter first name: ", false);
            string firstName = Helpers.GetString();
            Helpers.WriteCentered("Enter last name: ", false);
            string lastName = Helpers.GetString();

            User newUser = new User(username, firstName, lastName, password);
            newUser = db.AddUserToUserTable(newUser);
            return newUser;            

        }
    }
}
