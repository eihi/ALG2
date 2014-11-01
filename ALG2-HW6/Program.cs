using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG2_HW6
{
    public class Node
    {
        public string Name;
        public List<Edge> Edges = new List<Edge>();
        public bool Visited;

        public Node(string name)
        {
            Name = name;
        }

        
        public Node AddEdge(Node child, int w)
        {
            Edges.Add(new Edge
            {
                Parent = this,
                Child = child,
                Weigth = w
            });

            if (!child.Edges.Exists(a => a.Parent == child && a.Child == this))
            {
                child.AddEdge(this, w);
            }

            return this;
        }
    }

    public class Edge
    {
        public int Weigth;
        public Node Parent;
        public Node Child;
    }

    public class Graph
    {
        public Node Root;
        public List<Node> AllNodes = new List<Node>();

        public Node CreateRoot(string name)
        {
            Root = CreateNode(name);
            return Root;
        }

        public Node CreateNode(string name)
        {
            var n = new Node(name);
            AllNodes.Add(n);
            return n;
        }

        private Node GetUnvisitedChildNode(Node n)
        {
            foreach (Edge e in n.Edges)
            {
                if (!e.Child.Visited)
                    return e.Child;
            }
            return null;
        }

        private void ClearNodes()
        {
            AllNodes.ForEach(node => node.Visited = false);
        }

        public void DepthFirstSearch(string name)
        {
            Stack stack = new Stack();
            stack.Push(this.Root);
            Root.Visited = true;
            Console.WriteLine(Root);
            while (stack.Count != 0)
            {
                Node n = (Node)stack.Peek();
                Node child = GetUnvisitedChildNode(n);
                if (child != null)
                {
                    child.Visited = true;
                    Console.WriteLine(child);
                    stack.Push(child);
                }
                else
                {
                    stack.Pop();
                }
            }
            ClearNodes();
        }

        public void Change(string name)
        {

        }

        public void Insert(string name)
        {

        }

        public void Remove(string name)
        {

        }

        public int?[,] CreateAdjMatrix()
        {
            int?[,] adj = new int?[AllNodes.Count, AllNodes.Count];

            for (int i = 0; i < AllNodes.Count; i++)
            {
                Node n1 = AllNodes[i];

                for (int j = 0; j < AllNodes.Count; j++)
                {
                    Node n2 = AllNodes[j];

                    var arc = n1.Edges.FirstOrDefault(a => a.Child == n2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weigth;
                    }
                }
            }
            return adj;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
