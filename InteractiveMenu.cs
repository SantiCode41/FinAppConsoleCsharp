using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinAppCsharp
{
    internal class InteractiveMenu
    {
        public static int GenerateMenu(string[] options, int yOffset = 0)
        {
            int selected = 0;
            Console.CursorVisible = false;

            int maxOptionLength = options.Max(s => s.Length);
            int menuOptionLength = maxOptionLength + 10;
            //Console.WriteLine(menuOptionLength);

            while (true)
            {
                Console.SetCursorPosition(0, yOffset);
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Helpers.WriteCentered(options[i].PadLeft((menuOptionLength + options[i].Length) / 2).PadRight(menuOptionLength));
                    Console.ResetColor();
                }

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    selected = (selected - 1 + options.Length) % options.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selected = (selected + 1) % options.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    //Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    return selected + 1;
                }
            }
        }
    }
}
