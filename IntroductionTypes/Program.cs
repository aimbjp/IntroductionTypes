using System;
using System.Numerics;
using System.Reflection;

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
                    case '1' : Console.Clear(); ShowAllTypeInfo(); break;
                    case '2' : Console.Clear(); SelectType(); break;
                    case '3' : ChangeConsoleView(); break;
                    case '0' : Console.Clear(); flag = false; break;
                    default: break;
                }
            }
            Environment.Exit(1);
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
        // changing console view 
        // back and foregrounds colors
        // </summary>
        public static void ChangeConsoleView()
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
        // <summary>
        // show general info about types
        // longest name method and name of type with
        // the largest number of fields
        // </summary>
        public static void ShowAllTypeInfo()
        {
            var flag = true;
            var myAsm = Assembly.GetExecutingAssembly();
            var thisAssemblyTypes = myAsm.GetTypes(); 
            var refAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> types = new ();
            foreach(var asm in refAssemblies)
                types.AddRange(asm.GetTypes());
            var nRefTypes = 0;
            var nValueTypes = 0;
            var longestMethodName = "";
            var maxAmountFields = 0;
            var maxFieldsTypeName = "";
            foreach(var t in types)
            {
                var countFields = 0;
                
                if(t.IsClass)
                    nRefTypes++;
                else if(t.IsValueType)
                    nValueTypes++;
                
                foreach (var method in t.GetMethods())
                {
                    if (method.Name.Length > longestMethodName.Length) longestMethodName = method.Name;
                }

                if (t.GetFields().Length > maxAmountFields)
                {
                    maxAmountFields = t.GetFields().Length;
                    maxFieldsTypeName = t.Name;
                }
            } 
            ShowMenu();
            while (flag)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    default: Main(); break;
                }
            }
            
            void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("Общая информация по типам\n" +
                                  "Подключенные сборки: " + thisAssemblyTypes.Length + "\n" +
                                  "Всего типов по всем подключенным сборкам: " + types.Count + "\n" +
                                  "Ссылочные типы (только классы): " + nRefTypes + "\n" +
                                  "Значимые типы: " + nValueTypes + "\n" +
                                  "Самое длинное название свойства: " + longestMethodName + "\n" +
                                  "Тип с наибольшим числом полей: " + maxFieldsTypeName + "\n" +
                                  "\nНажмите любую клавишу, чтобы вернуться в главное меню");
            }
        }
        // <summary>
        // show all info about types (basics)
        // </summary>
        public static void SelectType()
        {
            var flag = true;
            ShowMenu();
            while (flag)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1' : ShowInfoType(typeof(uint)); break;
                    case '2' : ShowInfoType(typeof(int)); break;
                    case '3' : ShowInfoType(typeof(long)); break;
                    case '4' : ShowInfoType(typeof(float)); break;
                    case '5' : ShowInfoType(typeof(double)); break;
                    case '6' : ShowInfoType(typeof(char)); break;
                    case '7' : ShowInfoType(typeof(string)); break;
                    case '8' : ShowInfoType(typeof(Vector)); break;
                    case '9' : ShowInfoType(typeof(Matrix4x4)); break;
                    case '0' : Main(); break;
                    default: break;
                }
            }
            
            static void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("Информация по типам\n" +
                                  "Выберите тип:\n" +
                                  "----------------------------\n" +
                                  "1 — uint\n" +
                                  "2 — int\n" +
                                  "3 — long\n" +
                                  "4 — float\n" +
                                  "5 — double\n" +
                                  "6 — char\n" +
                                  "7 — string\n" +
                                  "8 — Vector\n" +
                                  "9 — Matrix\n" +
                                  "0 — Выход в главное меню\n");
            }

            static void ShowInfoType(Type type)
            {
                var flag = true;
                ShowMenu();
                while (flag)
                {
                    switch (char.ToLower(Console.ReadKey(true).KeyChar))
                    {
                        case 'm' :
                            ShowAddInfoType(); break;
                        case '0' :
                            SelectType(); break;
                        default: break;
                    }
                }
                
                void ShowMenu()
                {
                    Console.Clear();
                    Console.WriteLine("Информация по типу: " + type + "\n" +
                                      "\tЗначимый тип: " + (type.IsValueType ? "+" : "-") + "\n" +
                                      "\tПространство имен: " + type.Namespace + "\n" +
                                      "\tСборка: " + type.Assembly.GetName().Name + "\n" +
                                      "\tОбщее число элементов: " + type.GetMembers().Length + "\n" +
                                      "\tЧисло методов: " + type.GetMethods().Length + "\n" +
                                      "\tЧисло свойств: " + type.GetProperties().Length + "\n" +
                                      "\tЧисло полей: " + type.GetFields().Length + "\n" +
                                      "\tСписок полей: " + CreateStringFields() + "\n" +
                                      "\tСписок свойств: " + CreateStringProps() + "\n" +
                                      "\n" +
                                      "Нажмите 'M' для вывода дополнительной информации по методам\n" +
                                      "Нажмите '0' для выхода в меню\n" );
                                      
                    string CreateStringFields()
                    {
                        var fieldNames = new List<string>();
                        foreach (var item in type.GetFields())
                        {
                            fieldNames.Add(item.Name);
                        }
                        var sFieldsNames = String.Join(", ", fieldNames);
                        return (sFieldsNames.Length > 0)?sFieldsNames:"—";
                    }
                    string CreateStringProps()
                    {
                        var propNames = new List<string>();
                        foreach (var item in type.GetProperties())
                        {
                            propNames.Add(item.Name);
                        }
                        var sPropsNames = String.Join(", ", propNames);
                        return (sPropsNames.Length > 0)?sPropsNames:"—";
                    }
                }
                
                void ShowAddInfoType()
                {
                    var top = 1;
                    var flag = true;
                    ShowMenu();
                    while (flag)
                    {
                        switch (char.ToLower(Console.ReadKey(true).KeyChar))
                        {                                
                            case '0' : ShowInfoType(type);
                                break;
                            default: break;
                        }
                    }
                    void ShowMenu()
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.Write("Методы типа: " + type + "\n" +
                                      "Название");
                        Console.SetCursorPosition(30, top);
                        Console.Write("Число перегрузок");
                        Console.SetCursorPosition(60, top);
                        Console.Write("Число параметров\n");
                        top++;
                        ShowStringMethods();
                        Console.Write("0 — для выхода в главное меню");
                        
                    }
                    void ShowStringMethods()
                    {
                        var tempArr = new int[2]{0,0};
                        var overloads = new Dictionary<string, int>();
                        var parametrs = new Dictionary<string, int[]>();
                        foreach (var method in type.GetMethods())
                        {
                            if (overloads.ContainsKey(method.Name))
                                overloads[method.Name]++;
                            else 
                                overloads.Add((method.Name), 1);
                        }

                        foreach (var method in type.GetMethods())
                        {
                            if (!parametrs.ContainsKey(method.Name))
                            {
                                parametrs.Add(method.Name, new int[2]);
                            }
                            foreach (var parameter in method.GetParameters())
                            {
                                tempArr[1]++;
                                if(parameter.IsOptional)  tempArr[0]++;
                            }

                            if (tempArr[0] < parametrs[method.Name][0]) parametrs[method.Name][0] = tempArr[0];
                            if (tempArr[1] > parametrs[method.Name][1]) parametrs[method.Name][1] = tempArr[1];
                            tempArr[0] = 0;
                            tempArr[1] = 0;
                        }

                        foreach (var item in overloads)
                        {
                            Console.Write(item.Key);
                            Console.SetCursorPosition(30, top);
                            Console.Write(item.Value);
                            Console.SetCursorPosition(60, top);
                            Console.Write(parametrs[item.Key][0] == parametrs[item.Key][1]
                                ? parametrs[item.Key][0] + "\n"
                                : parametrs[item.Key][0] + ".." + parametrs[item.Key][1] + "\n");
                            top++;
                        }
                    }
                }
            }
            // return typeof(int);
        }
    }
}
