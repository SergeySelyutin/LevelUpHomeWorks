using System;

namespace _20161119_RecursionPositiveNegative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Рекурсивный вывод положительных и остальных чисел :)";
            Console.WriteLine("Введите необходимое количество элементов массива:");
            int count = int.Parse(Console.ReadLine());
            int[] arr = new int[count];
            Random rnd = new Random();
            Console.WriteLine("Исходный массив:");

            //Заполнение массива случайными числами от -100 до  100 с последующим выводом в консоль
            for (int i = 0; i < count; ++i)
            {
                arr[i] = rnd.Next(-100, 100);
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

            recur(arr, 0);
        }

        static void recur(int[] array, int index)
        {
            if (index < array.Length)
            {
                if (array[index] <= 0)
                {
                    recur(array, index + 1);
                }
                else
                {
                    Console.WriteLine(array[index]);
                    recur(array, index + 1);
                    return;
                }
                Console.WriteLine(array[index]);
            }
        }
    }
}
