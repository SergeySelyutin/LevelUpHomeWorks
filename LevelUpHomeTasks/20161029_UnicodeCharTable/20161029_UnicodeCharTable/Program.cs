using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharTable
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = false; //корректность ввода данных
            ushort limit1 = 0;      //граница диапазона выводимых символов
            ushort limit2 = 0;      //граница диапазона выводимых символов

            //ввод диапазона выводимых символов
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите диапазон вывода символов Юникод через enter: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                isCorrect = ushort.TryParse(Console.ReadLine(), out limit1);
                if (!isCorrect)
                {
                    isCorrect = false;
                    continue;
                }
                isCorrect = ushort.TryParse(Console.ReadLine(), out limit2);
            } while (!isCorrect);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество столбцов для вывода: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            byte columnCount = byte.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество строк в каждом блоке для вывода: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            byte rowCount = byte.Parse(Console.ReadLine());

            Console.Clear();

            //Если нижняя граница больше верхней - меняем местами
            if (limit1 > limit2)
            {
                ushort tmp = limit2;
                limit2 = limit1;
                limit1 = tmp;
            }

            //вывод символов в консоль
            ushort i = limit1;      //счетчик для вывода чаров
            Console.SetCursorPosition(2, 0);
            int curTopMax = 0;      //самая нижняя позиция курсора в консоли (для корректного вывода строки после таблицы)

            //Вывод таблицы
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (i <= limit2)     //Переходим на новую строку групп
            {
                for (int currentColumn = 0; (currentColumn < columnCount) && (i <= limit2); currentColumn++)    //переходим по столбцам внутри одной строки групп
                {
                    for (int currentRow = 0; (currentRow < rowCount) && (i <= limit2); currentRow++)            //Переходим по строкам внутри группы
                    {
                        Console.Write("{0} : {1}", i, (char)i++);
                        Console.SetCursorPosition(currentColumn * 11 + 2, Console.CursorTop + 1);
                    }
                    if (curTopMax < Console.CursorTop)      //запоминаем самую нижнюю позицию курсора
                    {
                        curTopMax = Console.CursorTop;
                    }
                    if (Console.CursorTop >= rowCount)
                    {                                                                                               //избавляемся от ошибки System.ArgumentOutOfRangeException.
                        Console.SetCursorPosition((currentColumn + 1) * 11 + 2, Console.CursorTop - rowCount);      //(Console.CursorTop - rowCount) может принимать отрицательные значения
                    }
                }
                Console.SetCursorPosition(2, Console.CursorTop + rowCount + 1);
            }
            Console.SetCursorPosition(0, curTopMax + 2);
        }
    }
}
