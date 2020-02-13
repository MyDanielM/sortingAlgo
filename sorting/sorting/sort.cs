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
    }
}
