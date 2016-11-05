using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161105_BitOperations
{
    class Program
    {
        const ushort cryptMask = 0xc5e8;        // Маска для шифрования
        static StringBuilder sbPass = new StringBuilder("Password");
        static byte schedule = 0;
        static string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        static void Main(string[] args)
        {
            Console.Title = "Расписание";
            byte choise = 0;
            bool isEnd = false;

            for (int i = 0; i < sbPass.Length; ++i)
            {
                sbPass.Replace(sbPass[i], (char)(sbPass[i] ^ cryptMask), i, 1);
            }
            string password = sbPass.ToString();

            do
            {
                Console.WriteLine("Введите цифру с нужным действием:");
                Console.WriteLine("  1. Просмотреть расписание.");
                Console.WriteLine("  2. Изменить расписание.");
                Console.WriteLine("  3. Выйти из приложения.");

                if (Byte.TryParse(Console.ReadLine(), out choise))
                {
                    switch (choise)
                    {
                        case 1:
                            Console.Clear();
                            ViewSchedule();     // Вызов метода просмотра расписания
                            break;
                        case 2:
                            Console.Clear();
                            if (PasswordCheck(password))
                            {
                                Console.Clear();
                                ChangeSchedule();   // Вызов метода изменения расписания
                            }
                            else
                            {
                                Console.WriteLine("Введенный пароль не верен. Доступ запрещён.");
                                Console.WriteLine("Для продолжения нажмите любую кнопку...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            return;             // Завершение программы
                        default:
                            Console.Write("Вы ввели не корректное значение. Нажмите любую кнопку и повторите ввод!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                    }
                }
                Console.Clear();
            } while (!isEnd);

            Console.ReadLine();
        }

        // Вывод расписания в консоль
        private static void ViewSchedule()
        {
            sbPass.Clear();
            byte mask = 1;
            for (int i = 0; i < 7; ++i)
            {
                if ((schedule & mask) == mask)
                {
                    sbPass.Append(days[i]);
                    sbPass.Append(":  \tесть занятия.\n");
                }
                else
                {
                    sbPass.Append(days[i]);
                    sbPass.Append(":  \tнет занятий.\n");
                }
                mask <<= 1;
            }
            Console.WriteLine(sbPass.ToString());
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }

        // Изменение расписания
        private static void ChangeSchedule()
        {
            Console.WriteLine("Введите цифрами через пробел дни недели, в которые есть занятия (Понедельник - 1, Вторник - 2 и т.д.): ");
            string sChoise = Console.ReadLine();
            string[] sDays = sChoise.Split(' ');
            byte tmp;
            for (int i = 0; i < sDays.Length; i++)
            {
                if (byte.TryParse(sDays[i], out tmp))
                {
                    if (tmp > 0 && tmp < 8)
                    {
                        schedule = (byte)(schedule | (byte)(Math.Pow(2, tmp - 1)));
                    }
                }
            }

            Console.WriteLine("Введите цифрами через пробел дни недели, в которые нет занятий (Понедельник - 1, Вторник - 2 и т.д.): ");
            sChoise = Console.ReadLine();
            sDays = sChoise.Split(' ');
            for (int i = 0; i < sDays.Length; i++)
            {
                if (byte.TryParse(sDays[i], out tmp))
                {
                    if (tmp > 0 && tmp < 8)
                    {
                        schedule = (byte)(schedule & ~(byte)(Math.Pow(2, tmp - 1)));
                    }
                }
            }
        }

        private static bool PasswordCheck(string password)
        {
            Console.WriteLine("Введите пароль: ");
            sbPass.Clear();
            sbPass.Append(Console.ReadLine());
            for (int i = 0; i < sbPass.Length; ++i)
            {
                sbPass.Replace(sbPass[i], (char)(sbPass[i] ^ cryptMask), i, 1);
            }
            if (sbPass.ToString().Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}