using System;

namespace Sort
{
    class Program
    {
        static void Main()
        {
            int[] test = {16,7,10,1,5,11,3,8,14,4,2,12,6,13,9,15};
            int[] test1 = { 16, 7, 10, 1, 5, 11, 3, 8, 14, 4, 2, 12, 6, 13, 9, 15 };

            var result = new Program().MergeSort(test1,0,test1.Length-1);
            foreach (var i in result)
            { Console.Write(i + ","); }

            Console.ReadKey();
        }

        /// <summary>
        /// Сортировка вставками.
        /// Вход: целочисленный список, длина списка
        /// Сложность худшего случая O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="N"></param>
        /// <returns>"list"</returns>
        int[] InsertSort(int[] list, int N)
        {
            for(int i = 1; i< N;i++)
            {
                int newElem = list[i];
                int location = i-1;
                while(location >= 0 && list[location]>newElem)
                {
                    list[location + 1] = list[location];
                    location--;
                }
                list[location+1] = newElem;
            }
            return list;
        }

        /// <summary>
        /// Пузырьковая сортировка.
        /// Вход: целочисленный список, длина списка.
        /// В лучшем случае O(N)
        /// В худшем случае O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        int[] BubbleSort(int[] list, int N)
        {
            int COUNT = 0;
            bool swapElems = true;
            while (swapElems)
            {
                swapElems = false; N -= 1;
                for (int i = 0; i < N; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        var t = list[i];
                        var t1 = list[i + 1];
                        list[i + 1] = t;
                        list[i] = t1;
                        swapElems = true;
                        COUNT++;
                    }
                }
            }
            Console.WriteLine(COUNT);
            return list;
        }

        /// <summary>
        /// Пузырьковая сортировка.
        /// Вход: целочисленный список, длина списка.
        /// Запоминается последний обмен элементов, и при
        /// следующем проходе алгоритм не заходит за это место
        /// </summary>
        /// <param name="list"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        int[] BubbleSortMod1(int[] list, int N)
        {
            int k;
            int COUNT = 0;
            while (N>1)
            {
                k = 0;
                for (int i = 1; i < N; ++i)
                {
                    if (list[i-1] > list[i])
                    {
                        var t = list[i];
                        var t1 = list[i - 1];
                        list[i - 1] = t;
                        list[i] = t1;
                        COUNT++;
                        k = i;
                    }
                }
                N = k;
            }
            Console.WriteLine(COUNT);
            return list;
        }
        /// <summary>
        /// Пузырьковая сортировка (Нечетные и четные проходы)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        int[] BubbleSortMod2(int[] list, int N)
        { 
            int COUNT = 0;
            for (int i = 1; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < (N/2); j++)
                    {
                        if (list[2*j] > list[2*j+1])
                        {
                            var t = list[2*j];
                            list[2*j] = list[2*j + 1];
                            list[2*j + 1] = t;
                            COUNT++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < N/2 -1 ; j++)
                    {
                        if (list[2*j + 1] > list[2*j + 2 ])
                        {
                            var t = list[2*j+1];
                            list[2*j+1]= list[2*j + 2];
                            list[2*j +2] = t;
                            COUNT++;
                        }
                    }
                }
            }
            Console.WriteLine(COUNT);
            return list;
        }

        /// <summary>
        /// Худшее время O(n^2)
        /// Лучшее время 	O(nlog^2(n))
        /// </summary>
        /// <param name="list"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        int[] ShellSort(int[] list, int N)
        {
            int step = N / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < N; i++)
                {
                    int value = list[i];
                    for (j = i - step; (j >= 0) && (list[j] > value); j -= step)
                        list[j + step] = list[j];
                    list[j + step] = value;
                }
                step /= 2;
            }
            return list;
        }

        int AddElem2Pyramid(int[] list,int i,int N)
        {
            int imax;
            int root;
            if ((2 * i + 2) < N)
            {
                if (list[2 * i + 1] < list[2 * i + 2])
                    imax = 2 * i + 2;
                else
                    imax = 2 * i + 1;
            }
            else
                imax = 2 * i + 1;
            if (imax >= N)
                return i;
            if(list[i] < list[imax])
            {
                root = list[i];
                list[i] = list[imax];
                list[imax] = root;
                if (imax < N / 2)
                    i = imax;
            }
            return i;
        }

        /// <summary>
        /// Построение пирамиды O(N)
        /// Работа алгоритма O(N log2(N))
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int[] HeapSort(int[] list)
        {
            //step:1 building the pyramid
            int len = list.Length;
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                int prev_i = i;
                i = AddElem2Pyramid(list, i, len);
                if (prev_i != i)
                    ++i;
            }
            //step:2 sorting
            int root;
            for (int k = len - 1; k > 0; --k)
            {
                root = list[0];
                list[0] = list[k];
                list[k] = root;
                int i = 0, prev_i = -1;
                while(i!= prev_i)
                {
                    prev_i = i;
                    i = AddElem2Pyramid(list,i,k);
                }
            }
            return list;
        }

        /// <summary>
        /// Merge sort is a Divide and Conquer algorithm. It divides input array in two halves, calls itself for the two halves and then merges the two sorted halves.
        /// </summary>
        /// <param name="list">сортируемый список элементов</param>
        /// <param name="first">номер первого элемента в сортируемой части списка</param>
        /// <param name="last">номер последнего элемента в сортируемой части списка</param>
        /// <returns></returns>
        int[] MergeSort(int[] list,int first,int last)
        {
            if (first < last)
            {
                int middle = (first + last) / 2;
                MergeSort(list, first, middle);
                MergeSort(list, middle+1,last);
                Merge(list, first, middle,  last);
            }
            return list;
        }

        /// <summary>
        /// Предполагается, что элементы списков A и B
        /// следуют в списке list друг за другом.
        /// | arr[l..m] arr[m+1..r] 
        /// </summary>
        /// <param name="input">упорядочиваемый список элементов</param>
        /// <param name="low">начало списка А</param>
        /// <param name="middle">конец списка А</param>
        /// <param name="high">конец списка Б</param>
        /// <returns></returns>
        int[] Merge(int[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left += 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right += 1;
                }
                tmpIndex += 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left += 1;
                    tmpIndex += 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right += 1;
                    tmpIndex += 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
            return input;
        }
    }
}

