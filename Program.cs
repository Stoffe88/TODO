using System;
using TODO.Domain;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] taskList = new Task[2];

            bool isRunning = true;

            while (isRunning)
            {
                Clear();

                WriteLine("1. Add todo");
                Console.WriteLine("2. List todos");
                Console.WriteLine("3. Exit");

                var pressedKey = ReadKey(true);

                Clear();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:

                        Write("Title: ");
                        var title = ReadLine();

                        Write("Due date (yyyy-MM-dd hh:mm): ");
                        var dueDate = DateTime.Parse(ReadLine());

                        Task task = new Task(title, dueDate);
                        
                        if (TryFindAvailablePosition(taskList, out int index))
                        {
                            taskList[index] = task;
                        }
                        else
                        {
                            Clear();
                            Console.WriteLine("Task could not be added because you have too many tasks to do!");
                            System.Threading.Thread.Sleep(2000);
                        }

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
        public static bool TryFindAvailablePosition(Task[] tasks, out int index)
        {
            index = 0;

            while (index < tasks.Length && tasks[index] != null)
            {
                index++;
            }


            if (index < tasks.Length && tasks[index] == null)
            {
                return true;
            }

            return false;
        }
    }
}
