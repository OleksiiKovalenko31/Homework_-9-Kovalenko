using System.Collections;
using System.Text;

namespace Homework__9_Kovalenko
{
    internal class Program
    {
        static void Main()
        {
           
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            

            Random rndArray = new Random();
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

            BubbleSort(tempArray);

            int tempIndex = 0;
            foreach (var item in multiArray)
            {
                tempArray[tempIndex] = item;
                tempIndex++;
            }

            tempArray = BubbleSort(tempArray);

            //Повернення в двовиміний масив
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
           foreach (var item in maxArray)
           {
               //Console.Write($"{indexDelete}");
               Console.Write($"{indexDelete}-[{item}] ");
               indexDelete++;
           }
           Console.WriteLine();
           indexDelete = 0;
           Console.Write($"\nВведіть номер елемента для видалення _ ");


           if(int.TryParse(Console.ReadLine() , out indexDelete))
           {
                tempArray = new int[maxArray.Length - 1];

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

               foreach (var item in maxArray)
               {
                   Console.Write($"{indexDelete}-[{item}] ");
                   indexDelete++;
               }
               Console.WriteLine("\n");
           }
           Console.WriteLine("-----------------------------");

            //4.Написати програму, що буде знаходити суму елементів по діагоналі у двовимірному масиві.

            Console.WriteLine("4.Написати програму, що буде знаходити суму елементів по діагоналі у двовимірному масиві.\n");
            Console.WriteLine("!!! Використано сортований масив із завдвння 2.");
            StringBuilder strBuilder = new StringBuilder();
            strBuilder = strBuilder.Append("Сума елементів ");
            int sumElemnt = 0;
            for (int i = 0, j = 0;i < multiArray.GetLength(0) ;i++ ,j++)
            {
                sumElemnt += multiArray[i,j];
                strBuilder = strBuilder.Append($"+ {multiArray[i,j]} ");

            }
            strBuilder = strBuilder.Append($" = {sumElemnt}");
            Console.WriteLine(strBuilder);
        }//Кінець Main

        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        } // Кінець Swap

        static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {

                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }// Кінець BubbleSort
    }
}
