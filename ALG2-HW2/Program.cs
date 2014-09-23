using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW2
{
    class SpelObject
    {
        public const int DIMENSION = 2;
        public double[] Position { get; set; }

        public SpelObject()
        {
            Position = new double[DIMENSION];
        }
    }

    class Program
    {
        static int nr = 0;
        static void FillArray(SpelObject[] array, int index, double x, double y)
        {
            array[index] = new SpelObject();
            array[index].Position[0] = x;
            array[index].Position[1] = y;
        }

        static void WriteArray(SpelObject[] array)
        {
            foreach (SpelObject so in array)
            {
                Console.WriteLine("[" + so.Position[0] + ", " + so.Position[1] +  "]");
            }
            Console.WriteLine("\n");
        }

        static SpelObject[] array;

        static void Main(string[] args)
        {
            array = new SpelObject[8];

            FillArray(array, 0, 900, 100);
            FillArray(array, 1, 100, 100);
            FillArray(array, 2, 50, 750);
            FillArray(array, 3, 110, 90);
            FillArray(array, 4, 950, 50);
            FillArray(array, 5, 60, 800);
            FillArray(array, 6, 40, 800);
            FillArray(array, 7, 700, 850);

            WriteArray(array);

            QuickSort(nr, 0, array.Length - 1);

            WriteArray(array);

            Console.ReadLine();
        }

        private static double MedianOfThree(int index, int left, int right)
        {
            int center = (left + right) / 2;

            if (array[left].Position[index] > array[center].Position[index])
                Swap(left, center);
            if (array[left].Position[index] > array[right].Position[index])
                Swap(left, right);
            if (array[center].Position[index] > array[right].Position[index])
                Swap( center, right );

            Swap(center, right-1);

            return array[right-1].Position[index];
        }

        private static void Swap(int i, int j)
        {
            SpelObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void QuickSort(int index, int first, int last)
        {
            int size = last - first + 1;
            if (size == 2)
            {
                if (array[first].Position[index] > array[last].Position[index])
                    Swap(first, last);
                return;
            }
            if (last - first <= 0) 
                return;
            else
            {
                double pivot = MedianOfThree(index, first, last);
                int partition = Partition(index, first, last, pivot);

                index++;
                QuickSort(index % 2, first, partition);
                QuickSort(index % 2, partition + 1, last);
            }
        }

        private static int Partition(int index, int left, int right, double pivot)
        {
            int leftMark = left;
            int rightMark = right - 1;

            while (true)
            {
                while (array[++leftMark].Position[index] < pivot);
                while (rightMark > 0 && array[--rightMark].Position[index] > pivot);

                if (leftMark >= rightMark)
                    break;
                else
                    Swap(leftMark, rightMark);
            }

            Swap(leftMark, right - 1);

            return leftMark;
        }
    }
}

