using System;
using TODO.Domain;
using static System.Console;

namespace TODO
{
    class Program
    {
        static Task[] taskList = new Task[100];
        static void Main(string[] args)
        {
            
            int taskIdCounter = 1;

            bool isRunning = true;

            while (isRunning)
            {
                Clear();

                WriteLine("1. Add todo");
                WriteLine("2. List todos");
                WriteLine("3. Exit");

                var pressedKey = ReadKey(true);

                Clear();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:

                        Write("Title: ");
                        var title = ReadLine();

                        Write("Due date (yyyy-MM-dd hh:mm): ");
                        var dueDate = DateTime.Parse(ReadLine());

                        
                        
                        if (TryFindAvailablePosition(taskList, out int index))
                        {
                            taskList[index] = new Task(taskIdCounter++, title, dueDate);
                            Clear();
                            Console.WriteLine($"Task added: {taskList[index].Title}");
                        }
                        else
                        {
                            Clear();
                            Console.WriteLine("Task could not be added because you have too many tasks to do!");
                            System.Threading.Thread.Sleep(2000);
                        }

                        break;

                    case ConsoleKey.D2:

                        Console.WriteLine("ID TODO                 Due date        Completed   Completed date");
                        Console.WriteLine("---------------------------------------------------------------");

                        //int numberOfTasks = 0;

                        //while (numberOfTasks < taskList.Length && taskList[numberOfTasks] != null)
                        //{
                        //    numberOfTasks++;
                        //}

                        foreach (var todo in taskList)
                        {
                            if (todo == null) continue;
                            Console.WriteLine($"{todo.Id}. {todo.Title}     {todo.DueDate}      {todo.Completed}");
                        }

                        ReadKey(true);
                        
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
