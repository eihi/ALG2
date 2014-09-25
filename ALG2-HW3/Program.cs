using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW3
{
    public class SpelObject
    {
        public const int DIMENSION = 2;
        public double[] Position { get; set; }

        public SpelObject()
        {
            Position = new double[DIMENSION];
        }
    }

    public class Node
    {
        public Node Ouder { get; set; }
        public Node(Node ouder)
        {
            Ouder = ouder;
        }
    }

    public class EndNode : Node
    {
        public SpelObject SpelObject { get; set; }

        public EndNode(Node ouder, SpelObject spelObject) : base(ouder)
        {
            SpelObject  = spelObject;
        }
    }

    public class SplitNode : Node
    {
        public SplitNode(Node ouder)
            : base(ouder)
        { }

        public Node LinkerKind { get; set; }
        public Node RechterKind { get; set; }
    }

    //public class Tree
    //{
    //    private Node root;

    //    public Node find(double key) 
    //    {
    //        return null;
    //    }

    //    public void Insert(int id, double dd)
    //    {
    //    }
    //    public void Delete(int id)
    //    {
    //    }
    //} 

    class Program
    {
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

            QuickSort(0, 0, array.Length - 1, null);

            WriteArray(array);

            Console.ReadLine();
        }




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
                Console.WriteLine("[" + so.Position[0] + ", " + so.Position[1] + "]");
            }
            Console.WriteLine("\n");
        }

        static SpelObject[] array;

        private static double MedianOfThree(int index, int left, int right)
        {
            int center = (left + right) / 2;

            if (array[left].Position[index] > array[center].Position[index])
                Swap(left, center);
            if (array[left].Position[index] > array[right].Position[index])
                Swap(left, right);
            if (array[center].Position[index] > array[right].Position[index])
                Swap(center, right);

            Swap(center, right - 1);

            return array[right - 1].Position[index];
        }

        private static void Swap(int i, int j)
        {
            SpelObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static Node QuickSort(int index, int first, int last, Node parent)
        {
            int size = last - first + 1;
            if (size == 2)
            {
                if (array[first].Position[index] > array[last].Position[index])
                    Swap(first, last);
                SplitNode sNode = new SplitNode(parent);
                Console.WriteLine("----------------- New SplitNode ----------------");
                sNode.LinkerKind = new EndNode(sNode, array[first]);
                Console.WriteLine("---------------- New Endnode ----------------");
                sNode.RechterKind = new EndNode(sNode, array[last]);
                Console.WriteLine("---------------- New Endnode ----------------");
                return sNode;
            }
            if (last - first <= 0)
            {
                Console.WriteLine("---------------- New Endnode ----------------");
                return new EndNode(parent, array[last]);
            }
            else
            {
                double pivot = MedianOfThree(index, first, last);
                int partition = Partition(index, first, last, pivot);

                index++;
                SplitNode sNode = new SplitNode(parent);
                Console.WriteLine("---------------- New SplitNode ----------------");
                sNode.LinkerKind = QuickSort(index % 2, first, partition, sNode);
                sNode.RechterKind = QuickSort(index % 2, partition + 1, last, sNode);
                return sNode;
            }
        }

        private static int Partition(int index, int left, int right, double pivot)
        {
            int leftMark = left;
            int rightMark = right - 1;

            while (true)
            {
                while (array[++leftMark].Position[index] < pivot) ;
                while (rightMark > 0 && array[--rightMark].Position[index] > pivot) ;

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
