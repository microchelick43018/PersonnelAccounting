using System;
using System.Collections.Generic;
namespace PersonnelAccounting
{
    class Program
    {
        static int ReadInt()
        {
            int value;
            bool isCorrect = int.TryParse(Console.ReadLine(), out value);
            while (isCorrect == false)
            {
                Console.Write("Неверный ввод. Повторите еще раз: ");
                isCorrect = int.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
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

        static void InitWorker(out string fullName, out string position)
        {
            Console.Write("Введите ФИО работника: ");
            fullName = Console.ReadLine();
            Console.Write("Введите должность работника: ");
            position = Console.ReadLine();
        }

        static List<int> GetListOfNumbersOfDuplicateName(List<string> fullNames, string word)
        {
            List<int> repeatedNumbers = new List<int>();
            for (int i = 0; i < fullNames.Count; i++)
            {
                if (fullNames[i] == word)
                {
                    repeatedNumbers.Add(i);
                }
            }
            return repeatedNumbers;
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> workers = new Dictionary<string, string>();
            List<string> fullNames = new List<string>();
            List<string> positons = new List<string>();
            bool exit = false;
            int choice;
            while (exit == false)
            {
                ShowMenu();
                Console.Write("Выберите команду: ");
                choice = ReadCommand();
                switch (choice)
                {
                    case 1:
                        string newFullName;
                        string newPosition;
                        InitWorker(out newFullName, out newPosition);
                        fullNames.Add(newFullName);
                        positons.Add(newPosition);
                        break;
                    case 2:
                        for (int i = 0; i < fullNames.Count; i++)
                        {
                            Console.WriteLine($"ФИО - {fullNames[i]}, должность - {positons[i]}");
                        }
                        break;
                    case 3:
                        string removableName;
                        Console.Write("Введите ФИО работника, которого хотите удалить: ");
                        removableName = Console.ReadLine();
                        List <int> repeatedNumbers = new List<int>();
                        repeatedNumbers = GetListOfNumbersOfDuplicateName(fullNames, removableName);
                        if (repeatedNumbers.Count == 0)
                        {
                            Console.WriteLine("Работник с таким именем не найден!");
                        }
                        else if(repeatedNumbers.Count == 1)
                        {
                            Console.WriteLine($"Досье {fullNames[repeatedNumbers[0]]} - {positons[repeatedNumbers[0]]} удалено.");
                            fullNames.RemoveAt(repeatedNumbers[0]);
                            positons.RemoveAt(repeatedNumbers[0]);
                        }
                        else
                        {
                            Console.WriteLine("Найдено несколько повторов. Выберите какой хотите удалить: ");
                            for (int i = 0; i < repeatedNumbers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {fullNames[repeatedNumbers[i]]} - {positons[repeatedNumbers[i]]}");
                            }
                            int choiceOfRemove = ReadInt();
                            while (choiceOfRemove <= 0 || choiceOfRemove > repeatedNumbers.Count)
                            {
                                Console.Write("Неверный ввод. Повторите попытку: ");
                                choiceOfRemove = ReadInt();
                            }
                            fullNames.RemoveAt(choiceOfRemove - 1);
                            positons.RemoveAt(choiceOfRemove - 1);
                        }
                        repeatedNumbers.Clear();
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
