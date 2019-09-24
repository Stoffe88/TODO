using System;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Clear();

                WriteLine("1. Add todo");
                Console.WriteLine("2. List todos");
                Console.WriteLine("3. Exit");

                var pressedKey = ReadKey(true);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:

                        break;

                    case ConsoleKey.D2:

                        break;

                    case ConsoleKey.D3:

                        isRunning = false;

                        break;

                    default:

                        break;
                }
            }


        }
    }
}
