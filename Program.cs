using System;
using System.Collections.Generic;
namespace PersonnelAccounting
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1 - Добавить досье");
            Console.WriteLine("2 - Вывести все досье");
            Console.WriteLine("3 - Удалить досье");
            Console.WriteLine("4 - Выход с программы");
        }

        static int ReadCommand()
        {
            int choice = -1;
            int.TryParse(Console.ReadLine(), out choice);
            while(choice <= 0 || choice > 4)
            {
                Console.Write("Ошибка ввода! Повторите ещё раз: ");
                int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }

        static void InitWorker(ref string fullName, ref string position)
        {
            Console.Write("Введите ФИО работника: ");
            fullName = Console.ReadLine();
            Console.Write("Введите должность работника: ");
            position = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> workers = new Dictionary<string, string>();
            bool exit = false;
            int choice;
            string newFullName = "";
            string newPosition = "";
            string removableName;
            while (exit == false)
            {
                ShowMenu();
                Console.Write("Выберите команду: ");
                choice = ReadCommand();
                switch (choice)
                {
                    case 1:
                        InitWorker(ref newFullName, ref newPosition);
                        workers.Add(newFullName, newPosition);
                        break;
                    case 2:
                        foreach (var worker in workers)
                        {
                            Console.WriteLine($"ФИО - {worker.Key}, должность - {worker.Value}");
                        }
                        break;
                    case 3:
                        Console.Write("Введите ФИО работника, которого хотите удалить: ");
                        removableName = Console.ReadLine();
                        if (workers.ContainsKey(removableName) == false)
                        {
                            Console.Write("Данный работник не найден.");
                        }
                        else
                        {
                            workers.Remove(removableName);
                            Console.WriteLine("Досье удалено");
                        }
                        break;
                    case 4:
                        exit = true;
                        break;
                }
                Console.WriteLine("\nНажмите на любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
