using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Input
    {
        // Reads a position from the user as follows:
        // -- valid inputs are 1, 2, 3 or q with return values 0, 1, 2 or -1, respectively.
        // -- typed characters are not display on screen until the user types a valid character
        public int GetPosition()
        {            
            while (true)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                
                switch(keyInput.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Write("1");
                        return 0;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Write("2");
                        return 1;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Write("3");
                        return 2;
                    case ConsoleKey.Q:
                        Console.Write("q");
                        return -1;
                }
            }
        }

        // Reads the number of discs as follows:
        // -- Prompt with "How many discs (3...5)?"
        // -- Valid input is between 3 to 5
        // -- Should take care of invalid input
        public int GetDiscCount()
        {
            int number = 0;

            while (true)
            {
                try
                {
                    Console.Write("How many dicss (3...5): ");
                    number = Convert.ToInt32(Console.ReadLine());

                    if (number < 3 || number > 5)
                    {
                        throw new Exception();
                    }

                    return number;
                }
                catch
                {
                    Console.WriteLine("Invalid number.");
                }
            }
        }
    }
}
