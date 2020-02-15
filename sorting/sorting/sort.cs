using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    public class sort
    {
        /// <summary>
        /// This method sorting array of integer value by selection sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] selectionSort(int[] toSort)
        {
            //Сортировка выбором

            int min, temp;
            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива

            for (int i = 0; i < sorted.Length; i++)
            {
                min = i;//Установка минимального значения

                for (int j = i; j < sorted.Length; j++)
                {
                    //идём по массиву от "минимального" до правого края, если есть меньше - меняяем местами
                    if (sorted[j] < sorted[min])
                        min = j;
                }
                temp = sorted[i];
                sorted[i] = sorted[min];
                sorted[min] = temp;
            }


            return sorted;
        }

        /// <summary>
        /// This method sorting array of integer value by D.Shell sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] shellSort(int[] toSort)
        {
            //Сортировка Шелла

            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива

            int step = sorted.Length / 2;    //Шаг прохода по массиву
            while (step > 0)
            {
                int i, j;
                for (i = step; i < sorted.Length; i++) //идем по массиву с шагом step
                {
                    int value = sorted[i];   //Принимаем за минимальное
                    for (j = i - step; j >= 0 && sorted[j] > value; j -= step)   //Сравниваем все элементы массива с шагом step
                                                                                 //Если первый на промежутке меньше минимального(value), сдвигаем его влево
                                                                                 //Если оно больше - идём к следующему
                    {
                        sorted[j + step] = sorted[j];
                    }
                    sorted[j + step] = value; //большее значение двигаем вправо
                }
                step /= 2; //уменьшаем шаг в два раза

            }


            return sorted;
        }
        /// <summary>
        /// This method sorting array of integer value by insertion sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] insertionSort(int[] toSort)
        {
            //Сортировка вставками

            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива


            for (int i = 1; i < sorted.Length; i++)
            {
                int key = sorted[i];    //Берём значение начиная со второго элемента в массиве
                int j = i--;            //Берём индекс предыдущего
                while (j >= 0 && sorted[j] > key) //Пока не проверим весь отрезок от начала до sorted[i]
                {
                    sorted[j + 1] = sorted[j]; //Если предыдущий элемент больше, смещаем его правее
                    j--;                       //Идём к следующему (смещаемся влево)
                }
                sorted[j + 1] = key;    //Ставим рассматриваемое значение на место по возрастанию
            }

            return sorted;
        }
        /// <summary>
        /// This method sorting array of integer value by bubble sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] bubbleSort(int[] toSort)
        {
            //Сортировка пузырьком

            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива

            for (int i = 0; i < sorted.Length; i++) 
            {
                for (int j = sorted.Length - 2; j >= i; j--)  //Идём справа на лево по массиву и сравниваем в цикле два рядом стоящих значения
                {
                    if (sorted[j] > sorted[j + 1])
                    {
                        int temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp; 
                    }
                }
            }

            return sorted;
        }
        //-----------------------------------------------------Метод слияния--------------------------------------------------------------------------------
        /// <summary>
        /// This method sorting array of integer value by merge sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] mergeSort(int[] toSort)
        {
            //Сортировка методом слияния

            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива


            return MergeSort(sorted, 0, sorted.Length - 1);
        }

        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }

        }
        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }
        //-----------------------------------------------------Метод слияния--------------------------------------------------------------------------------


        //-----------------------------------------------------Метод быстрой сортировки---------------------------------------------------------------------

        /// <summary>
        /// This method sorting array of integer value by quick sorting
        /// </summary>
        /// <param name="toSort">Array to sort</param>
        /// <returns>Sorted array</returns>
        public int[] quickSort(int[] toSort)
        {
            int[] sorted = new int[toSort.Length];
            Array.Copy(toSort, sorted, toSort.Length);//Создаём копию исходного массива


            return QuickSort(sorted, 0, sorted.Length - 1);

        }

        //метод для обмена элементов массива
        static void swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        //-----------------------------------------------------Метод быстрой сортировки---------------------------------------------------------------------

    }
}
