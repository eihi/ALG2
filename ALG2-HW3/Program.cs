using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW3
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
        public Node LinkerKind { get; set; }
        public Node RechterKind { get; set; }
    }

    public class Tree
    {
        private Node root;

        public Node find(double key) 
        {
            return null;
        }

        public void Insert(int id, double dd)
        {
        }
        public void Delete(int id)
        {
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
