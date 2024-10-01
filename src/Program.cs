namespace MikhailovProject
{
    using System;
    using System.Security.Cryptography;

    internal class Program
    {
        bool end = false;
        static string Playername;
        static bool Haskey = false;
        static bool HasLockPick = false;
        static bool[] artifactsfound = new bool[3]; // 0 : Под кроватью, 1: Вентиляция, 2 Тумбочка

        static void Main(string[] args)
        {
            Startgame();
        }

        static void Startgame()
        {
            Console.WriteLine("Проснулся");
            Console.Write("имя");
            Playername = Console.ReadLine();
            Console.WriteLine($"Хелоу, {Playername}");

            while (true)
            {
                Console.WriteLine("\nДействия");
                Console.WriteLine("1.Открыть дверь");
                Console.WriteLine("2.Заглянуть под кровать");
                Console.WriteLine("3.Открыть ящик в углу комнаты");
                Console.WriteLine("4.Открыть вентиляцию");
                Console.WriteLine("5.Взглянуть на тумбочку");
                Console.WriteLine("6.Взглянуть на статую рядом с дверью");
                Console.WriteLine("Введите номер действия или 'Выход' для выхода");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        OpenDoor();
                        break;
                    case "2":
                        LookUnderTheBed();
                        break;
                    case "3":
                        OpenBoxInTheCornerOfTheRoom();
                        break;
                    case "4":
                        VentOpen();
                        break;
                    case "5":
                        LookAtBedsideTable();
                        break;
                    case "6":
                        LookAtTheStatueNearTheDoor();
                        break;
                    case "Выход":
                        ;
                        Console.WriteLine("Вы покидаете игру");
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.Попробуйте еще раз");
                        break;

                }

            }

            static void OpenDoor()
            {
                if (HasLockPick)
                {
                    Console.WriteLine($"{Playername},Вы сбежали!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"{Playername},дверь закрыта.Вам нужна отмычка");
                }
            }
        }
        static void LookUnderTheBed()
        {
            if (!artifactsfound[0])
            {
                artifactsfound[0] = true;
                Console.WriteLine($"{Playername}Вы нашли первый артефакт");
            }
            else
            {
                Console.WriteLine($"{Playername},Под кроватью ничего нет");
            }

        }
        static void OpenBoxInTheCornerOfTheRoom()
        {
            if (Haskey)
            {
                HasLockPick = true;
                Console.WriteLine($"{Playername},вы открыли ящик и нашли отмычку");
            }
            else
            {
                Console.WriteLine($"{Playername},ящик закрыт.Активируйте статую,чтобы получить ключ");
            }
        }
        static void VentOpen()
        {
            int attempts = 0;
            while (true)
            {
                if (!artifactsfound[1])
                Console.WriteLine("Попробуйте открыть ветниляцию.");
                string input = Console.ReadLine();
                
                attempts++;
                if (attempts == 1)
                {
                    Console.WriteLine($"{Playername},поддается");
                }    
                if (attempts == 2)
                {
                    Console.WriteLine($"{Playername},еще чуть-чуть");
                }

                if (attempts == 3)
                {
                    artifactsfound[1] = true;
                    Console.WriteLine($"{Playername}вы нашли второй артефакт.");
                    break ;
                }
                else
                {
                    Console.WriteLine($"{Playername},ноу");
                }




            }
        }

        static void LookAtBedsideTable()
        {
            if (!artifactsfound[2])
            {
                artifactsfound[2] = true;
                    Console.WriteLine($"{Playername},вы нашли третий артефакт");
            }
            else
            {
                Console.WriteLine($"{Playername},ничего нет");
            }
        }
        static void LookAtTheStatueNearTheDoor()
        {
            if (artifactsfound[0] && artifactsfound[1] && artifactsfound[2])
            {
                Haskey = true;
                Console.WriteLine($"{Playername},вы активировали статую и получили ключ");
            }
            else
            {
                Console.WriteLine($"{Playername},вам нужно собрать три артефакта");
            }
        }
    }
}