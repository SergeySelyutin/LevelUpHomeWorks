using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161119_QuickSortAndBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Быстрая сортировка и Бинарный поиск";
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

            //QuickSort и вывод отсортированного массива
            Quicksort(arr, 0, count - 1);

            Console.WriteLine("\nОтсортированый массив:");
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

            //Поиск элемента в массиве
            Console.WriteLine("Введите число для поиска в массиве:");
            int number = int.Parse(Console.ReadLine());
            int index = BinarySearch(arr, 0, arr.Length - 1, number);
            if (index == -1)
            {
                Console.WriteLine("Число {0} отсутствует в массиве!", number);
            }
            else
            {
                Console.WriteLine("Число {0} найдено в массиве на {1} позиции", number, index + 1);
            }

        }

        #region QuickSort
        public static void Quicksort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int fringe = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i] < fringe)
                {
                    i++;
                }

                while (array[j] > fringe)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(array, left, j);
            }

            if (i < right)
            {
                Quicksort(array, i, right);
            }
        }
        #endregion

        #region BinarySearch
        static int BinarySearch(int[] array, int left, int right, int number)
        {
            while (right >= left)
            {
                int middle = (left + right) / 2;

                if (array[middle] > number)
                {
                    right = middle - 1;
                }
                else
                {
                    if (array[middle] < number)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        return middle;
                    }
                }
            }
            return -1;
        }
        #endregion
    }
}
