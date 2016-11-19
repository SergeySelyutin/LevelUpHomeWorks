using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161119_ArrayMinMaxSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Поиск Min/Max с их индексами";
            Console.WriteLine("Введите необходимое количество элементов массива:");
            int count = int.Parse(Console.ReadLine());
            int[] arr = new int[count];
            Random rnd = new Random();
            //int[] arr = { -5, 5, 6, -8, 5, -8, 10, 4, 10 };
            Console.WriteLine("Исходный массив:");

            //Заполнение массива случайными числами от -100 до  100 с последующим выводом в консоль
            for (int i = 0; i < count; ++i)
            {
                arr[i] = rnd.Next(-50, 50);
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

            ArrayList minPositions;
            ArrayList maxPositions;
            int min;
            int max;
            MinMax(arr, out min, out minPositions, out max, out maxPositions);

            //Вывод MAX/MIN с позициями
            Console.WriteLine("\nMax = {0}", max);
            Console.WriteLine("Позиции:");
            foreach (int number in maxPositions)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nMin = {0}", min);
            Console.WriteLine("Позиции:");
            foreach (int number in minPositions)
            {
                Console.WriteLine(number);
            }

            Swap(arr, (int)minPositions[0], (int)maxPositions[0]);
            Console.WriteLine("\nМассив после Swap():");
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }
        }

        #region MinMax
        static void MinMax(int[] array, out int min, out ArrayList minPositions, out int max, out ArrayList maxPositions)
        {
            minPositions = new ArrayList();
            maxPositions = new ArrayList();
            min = int.MaxValue;
            max = int.MinValue;
            for (int i = 0; i < array.Length; ++i)
            {
                //Ищем MIN
                if (min > array[i])
                {
                    minPositions.Clear();
                    minPositions.Add(i);
                    min = array[i];
                }
                else
                {
                    if (min == array[i])
                    {
                        minPositions.Add(i);
                    }
                }

                //Ищем MAX
                if (max < array[i])
                {
                    maxPositions.Clear();
                    maxPositions.Add(i);
                    max = array[i];
                }
                else
                {
                    if (max == array[i])
                    {
                        maxPositions.Add(i);
                    }
                }
            }
        }
        #endregion

        #region Swap
        static void Swap(int[] array, int minPos, int maxPos)
        {
            int tmp = array[minPos];
            array[minPos] = array[maxPos];
            array[maxPos] = tmp;
        }
        #endregion
    }
}
