using System;

namespace Dijkstra_sAlgorithmImplementation
{
    public class Edge
    {
        public Node Node { get; }
        public float Distance { get; }

        public Edge(Node node, float distance)
        {
            Node = node;
            Distance = distance;
        }

        public override int GetHashCode()
        {
            return Node.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Edge that)
                return false;

            return (this.Node == that.Node)
                   && (Math.Abs(this.Distance - that.Distance) < float.Epsilon);
        }

        public override string ToString()
        {
            return $"{Distance} -> {Node}";
        }
    }
}