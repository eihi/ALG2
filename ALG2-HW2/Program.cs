using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW2
{
    class SpelObject
    {
        private const int DIMENSION = 2;
        public double[] Position { get; set; }

        public SpelObject()
        {
            Position = new double[DIMENSION];
        }
    }

    class Program
    {
        private static Random rnd = new Random();
        static void FillArray(SpelObject[] array, int index, double x, double y)
        {
            array[index] = new SpelObject();
            array[index].Position[0] = x;
            array[index].Position[1] = y;
        }

        static void WriteArray(SpelObject[] array)
        {
            foreach (SpelObject so in objectArray)
            {
                Console.WriteLine(so.Position[0] + " - " + so.Position[1]);
            }
            Console.WriteLine("=====================================");
        }

        static SpelObject[] objectArray;

        static void Main(string[] args)
        {
            objectArray = new SpelObject[8];

            FillArray(objectArray, 0, 900, 100);
            FillArray(objectArray, 1, 100, 100);
            FillArray(objectArray, 2, 950, 50);
            FillArray(objectArray, 3, 50, 750);
            FillArray(objectArray, 4, 110, 90);
            FillArray(objectArray, 5, 60, 800);
            FillArray(objectArray, 6, 40, 800);
            FillArray(objectArray, 7, 700, 850);

            WriteArray(objectArray);

            Partition(0, objectArray, 0, objectArray.Length - 1);
            //Partition(1, objectArray, 0, objectArray.Length - 1);

            WriteArray(objectArray);

            Console.ReadLine();
        }

        static void QuickSort(int index, int first, int last)
        {



            //if ((last - first) <= 0)
            //{
            //    return;
            //}
            //else
            //{
            //    double pivot = objectArray[last].Position[index];
            //    int part = Partition(index, first, last);
            //    QuickSort(index, first, part - 1);
            //    QuickSort(index, part + 1, last);
            //}
        }

        private static void Partition(int index, SpelObject[] array, int left, int right)
        {
            int i = left;
            int j = right;
            double pivot = array[(left + right) / 2].Position[index];

            while (i <= j)
            {
                while (array[i].Position[index] < pivot)
                    i++;
                while (array[j].Position[index] > pivot)
                    j--;
                if (i <= j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }
            if (left < j)
                Partition(index, array, left, j);
            if (i < right)
                Partition(index, array, i, right);
        }

        private static void Swap(SpelObject[] array, int i, int j)
        {
            SpelObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

