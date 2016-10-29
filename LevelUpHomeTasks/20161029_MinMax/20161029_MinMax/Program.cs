using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161029_MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод пяти чисел из консоли
            Console.Write("Введите первое число: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Введите третье число: ");
            int third = int.Parse(Console.ReadLine());
            Console.Write("Введите четвертое число: ");
            int fourth = int.Parse(Console.ReadLine());
            Console.Write("Введите пятое число: ");
            int fifth = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //поиск max/min тупо влоб
            MinMax.minMaxBrute(first, second, third, fourth, fifth);

            //Поиск max/min с помощью доп метода без цикла
            MinMax.minMaxMethodWithoutLoops(first, second, third, fourth, fifth);

            //Поиск max/min с помощью цикла и массива
            MinMax.minMaxLoop();
            
        }
    }

    class MinMax
    {
        private static int max(int a, int b)
        {
            return (a > b) ? a : b;     //Помню, что не нужно использовать тернарный оператор, но тут простой пример :)
        }

        private static int min(int a, int b)
        {
            return (a < b) ? a : b;     //Помню, что не нужно использовать тернарный оператор, но тут простой пример :)
        }

        public static void minMaxBrute(int first, int second, int third, int fourth, int fifth)
        {
            //ввод чисел
            int max = first;
            int min = first;

            if (max < second)
            {
                max = second;
            }
            if (max < third)
            {
                max = third;
            }
            if (max < fourth)
            {
                max = fourth;
            }
            if (max < fifth)
            {
                max = fifth;
            }

            if (min > second)
            {
                min = second;
            }
            if (min > third)
            {
                min = third;
            }
            if (min > fourth)
            {
                min = fourth;
            }
            if (min > fifth)
            {
                min = fifth;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Min/Max влоб:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Max = {0}", max);
            Console.WriteLine("Min = {0}\n", min);
        }

        public static void minMaxMethodWithoutLoops(int first, int second, int third, int fourth, int fifth)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Min/Max с помощью метода без циклов:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Max = {0}", MinMax.max(MinMax.max(MinMax.max(first, second), MinMax.max(third, fourth)), fifth));
            Console.WriteLine("Min = {0}\n", MinMax.min(MinMax.min(MinMax.min(first, second), MinMax.min(third, fourth)), fifth));
        }

        public static void minMaxLoop()
        {
            const int n = 5;
            int i = 0;
            int[] arr = new int[n];
            int max = int.MinValue;
            int min = int.MaxValue;
            for (i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите {0} число: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Gray;
                arr[i] = int.Parse(Console.ReadLine());
                if (max < arr[i])
                {
                    max = arr[i];
                }
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("For Loop:");
            Console.WriteLine("Max = {0}", max);
            Console.WriteLine("Min = {0}\n", min);

            //Поиск max/min в цикле do..while
            max = int.MinValue;
            min = int.MaxValue;
            i = 0;
            do
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
                if (min > arr[i])
                {
                    min = arr[i];
                }
                ++i;
            } while (i < n);
            Console.WriteLine("do..while loop:");
            Console.WriteLine("Max = {0}", max);
            Console.WriteLine("Min = {0}\n", min);

            //Поиск max/min с помощью цикла while
            max = int.MinValue;
            min = int.MaxValue;
            i = 0;
            while (i < n)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
                if (min > arr[i])
                {
                    min = arr[i];
                }
                ++i;
            }
            Console.WriteLine("while loop:");
            Console.WriteLine("Max = {0}", max);
            Console.WriteLine("Min = {0}\n", min);

            //Поиск max/min с помощью цикла foreach
            max = int.MinValue;
            min = int.MaxValue;
            foreach (int tmp in arr)
            {
                if (max < tmp)
                {
                    max = tmp;
                }
                if (min > tmp)
                {
                    min = tmp;
                }
                ++i;
            }
            Console.WriteLine("foreach loop:");
            Console.WriteLine("Max = {0}", max);
            Console.WriteLine("Min = {0}\n", min);
        }
    }
}
