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

        public Node DepthFirstSearch(string name)
        {
            Node node = null;

            Stack stack = new Stack();
            stack.Push(this.Root);
            Root.Visited = true;

            while (stack.Count != 0)
            {
                Node n = (Node)stack.Peek();

                if (n.Name == name)
                {
                    node = n;
                    break;
                }

                Node child = GetUnvisitedChildNode(n);
                if (child != null)
                {
                    child.Visited = true;
                    stack.Push(child);
                }
                else
                    stack.Pop();
            }

            ClearNodes();
            return node;
        }

        public void Change(string name)
        {

        }

        public void Insert(string name, Node newNode, int w)
        {
            lock (AllNodes)
            {
                Node node = DepthFirstSearch(name);
                List<Edge> edges = node.Edges;

                node.Edges.Clear();
                node.AddEdge(newNode, w);
                foreach (Edge e in edges)
                {
                    newNode.AddEdge(e.Child, e.Weigth);
                }
            }
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
