// See https://aka.ms/new-console-template for more information
using System;

namespace InrtoductionTypes
{
    internal class Programm
    {
        static void Main()
        {
            var flag = true;
            ShowMenu();
            while(flag)
            {
                switch(char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    // case '1' : Console.Clear(); ShowAllTypeInfo(); break;
                    // case '2' : Console.Clear(); SelectType(); break;
                    case '3' : ChangeConsoleView(); break;
                    case '0' : Console.Clear(); flag = false; break;
                    default: break;
                }
            }
            // Environment.Exit(1);
            static void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("Информация по типам:\n" +
                                  "1 — Общая информация по типам\n" +
                                  "2 — Выбрать тип из списка\n" +
                                  "3 — Параметры консоли\n" +
                                  "0 — Выход из программы");
            }
        }
        // <summary>
        // changing console colors 
        // </summary>
        static void ChangeConsoleView()
        {
            var flag = true;
            ShowMenu();
            while(flag)
            {
                switch(char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1' : ChangeConsoleBackgroundColor(); break;
                    case '2' : ChangeConsoleForegroundColor(); break;
                    case '0' : Main(); break;
                    default: break;
                }
            }
            static void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("Выберите, пожалуйста, что нужно изменить:\n" +
                                  "1 — Цвет фона\n" +
                                  "2 — Цвет шрифта\n" +
                                  "0 — Выход в главное меню\n");
            }

            static void ChangeConsoleBackgroundColor()
            {
                var flag = true;
                ShowMenu();
                while (flag)
                {
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case '1' : Console.BackgroundColor = ConsoleColor.Black; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '2' : Console.BackgroundColor = ConsoleColor.White; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '3' : Console.BackgroundColor = ConsoleColor.Yellow; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '4' : Console.BackgroundColor = ConsoleColor.DarkRed; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '5' : Console.BackgroundColor = ConsoleColor.DarkGreen; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '6' : Console.BackgroundColor = ConsoleColor.DarkMagenta; Console.Clear();
                            ChangeConsoleBackgroundColor(); break;
                        case '0' : ChangeConsoleView(); break;
                        default: break;
                    }
                }
                
                static void ShowMenu()
                {
                    Console.Clear();
                    Console.WriteLine("Изменение цвета фона:\n" +
                                      "1 — Черный\n" +
                                      "2 — Белый\n" +
                                      "3 — Желтый\n" +
                                      "4 — Красный\n" +
                                      "5 — Зеленый\n" +
                                      "6 — Розовый\n" +
                                      "0 — Выход в меню\n");
                }
            }
            static void ChangeConsoleForegroundColor()
            {
                var flag = true;
                ShowMenu();
                while (flag)
                {
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case '1' : Console.ForegroundColor = ConsoleColor.Green; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '2' : Console.ForegroundColor = ConsoleColor.Yellow; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '3' : Console.ForegroundColor = ConsoleColor.White; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '4' : Console.ForegroundColor = ConsoleColor.Black; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '5' : Console.ForegroundColor = ConsoleColor.Magenta; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '6' : Console.ForegroundColor = ConsoleColor.Blue; Console.Clear();
                            ChangeConsoleForegroundColor(); break;
                        case '0' : ChangeConsoleView(); break;
                        default: break;
                    }
                }
                
                static void ShowMenu()
                {
                    Console.Clear();
                    Console.WriteLine("Изменение цвета шрифта:\n" +
                                      "1 — Зеленый\n" +
                                      "2 — Желтый\n" +
                                      "3 — Белый\n" +
                                      "4 — Черный\n" +
                                      "5 — Розовый\n" +
                                      "6 — Синий\n" +
                                      "0 — Выход в меню\n");
                }
            }
        }
    }
}
