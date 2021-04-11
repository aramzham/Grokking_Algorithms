using System.Collections.Generic;

namespace Dijkstra_sAlgorithmImplementation
{
    public class Node
    {
        public string Name { get; }
        public HashSet<Edge> Edges { get; set; }

        public Node(string name)
        {
            Name = name;
            Edges = new HashSet<Edge>();
        }

        public void AddEdge(Node neighbor, float distance)
        {
            Edges.Add(new Edge(neighbor, distance));
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Node that)
                return false;

            return this.Name == that.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}