using System.Collections;
using System.Text;

namespace Homework__9_Kovalenko
{
    internal class Program
    {
        static void Main()
        {
           
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            

            Random rndArray = new();
            int[] maxArray = new int[10];

            // 1.Написати програму, що знаходить другий найбільший елемент масиву.
            Console.WriteLine("1.Написати програму, що знаходить другий найбільший елемент масиву.\n");
            Console.WriteLine("Масив");
            int maxNumber = maxArray[0], afterMaxNumber = maxArray[0];
            for (int i = 0; i < maxArray.Length; i++)
            {
                maxArray[i] = rndArray.Next(0, 100);
                Console.Write($"{maxArray[i]} ");

                if (afterMaxNumber <= maxNumber && afterMaxNumber < maxArray[i] && maxArray[i] <= maxNumber)
                {
                    afterMaxNumber = maxArray[i];
                }
                else if (maxArray[i] > maxNumber)
                {
                    afterMaxNumber = maxNumber;
                }

                if (maxNumber <= maxArray[i])
                {
                    maxNumber = maxArray[i];
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Друге після максмального - {afterMaxNumber}");
            Console.WriteLine($"Максимальне значення - {maxNumber}");
            Console.WriteLine("-----------------------------");

           // 2.Написати програму, що буде сортувати за зростанням елементи двовимірного масиву.
            Console.WriteLine("\n2. Написати програму, що буде сортувати за зростанням елементи двовимірного масиву.");
            Console.WriteLine("Створений масив:");
            int[,] multiArray = new int[4, 4];
            int[] tempArray = new int[multiArray.Length];
            // створюємо масив
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    multiArray[i, j] = rndArray.Next(0, 100);
                    Console.Write($"{multiArray[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nСортований массив:");

            // переводимо в одномірний масив
            int tempIndex = 0;
            foreach (var item in multiArray)
            {
                tempArray[tempIndex] = item;
                tempIndex++;
            }
            //сортуємо
            tempArray = BubbleSort(tempArray);

            //Повертаємо в двовиміний масив
            tempIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    multiArray[i, j] = tempArray[tempIndex];
                    Console.Write($"{multiArray[i, j]}\t");
                    tempIndex++;
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------");
           // 3.Написати програму, що буде видаляти з масиву елемент за вказаним індексом.
           Console.WriteLine("3.Написати програму, що буде видаляти з масиву елемент за вказаним індексом.");
           int indexDelete = 0;
           Console.WriteLine("Масив:");
            // Беремо масив з першого завдання
           foreach (var item in maxArray)
           {
            
               Console.Write($"{indexDelete}-[{item}] ");
               indexDelete++;
           }
           Console.WriteLine();
           Console.Write($"\nВведіть номер елемента для видалення _ "); // вибераємо який елемент видалити


            if (int.TryParse(Console.ReadLine(), out indexDelete) && indexDelete < maxArray.Length - 1)
            {
                tempArray = new int[maxArray.Length - 1]; //створюємо тимчасовий масив і видаляємо вказаний елемент

                for (int i = 0, j = 0; i < tempArray.Length; i++)
                {
                    if (i != indexDelete)
                    {
                        tempArray[j] = maxArray[i];
                        j++;
                    }
                }

                Console.WriteLine($"\nВидалено: {indexDelete}-[{maxArray[indexDelete]}]");
                maxArray = tempArray;
                indexDelete = 0;
                Console.WriteLine();
                Console.WriteLine("Масив з видаленим елементом:");
                // тимчасовий масив перезаписуємо в наш.
                foreach (var item in maxArray)
                {
                    Console.Write($"{indexDelete}-[{item}] ");
                    indexDelete++;
                }
                Console.WriteLine("\n");
            }
            else if (indexDelete > maxArray.Length - 1 || indexDelete <0)
            {
                Console.WriteLine("Введене значення поза межами масиву.\n Елемент видалено не буде!");
            }
            else { Console.WriteLine("Введено некоректні дані.\n Елемент видалено не буде!"); }

           
           Console.WriteLine("-----------------------------");

            //4.Написати програму, що буде знаходити суму елементів по діагоналі у двовимірному масиві.

            Console.WriteLine("4.Написати програму, що буде знаходити суму елементів по діагоналі у двовимірному масиві.\n");
            Console.WriteLine("!!! Використано сортований масив із завдвння 2.");
            StringBuilder strBuilder = new();
            strBuilder = strBuilder.Append("Сума елементів ");
            int sumElemnt = 0;
            for (int i = 0, j = 0;i < multiArray.GetLength(0) ;i++ ,j++)
            {
                sumElemnt += multiArray[i,j];
                strBuilder = strBuilder.Append($"+ {multiArray[i,j]} ");

            }
            strBuilder = strBuilder.Append($" = {sumElemnt}");
            Console.WriteLine(strBuilder);
            Console.WriteLine("-----------------------------");
        }//Кінець Main

        static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                      
                    }
                }
            }

            return array;
        }// Кінець BubbleSort
    }
}
