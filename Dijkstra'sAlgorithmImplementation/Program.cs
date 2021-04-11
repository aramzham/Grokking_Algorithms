using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_sAlgorithmImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Node("start");
            var a = new Node("a");
            var b = new Node("b");
            var c = new Node("c");
            var d = new Node("d");
            var fin = new Node("fin");

            start.AddEdge(a, 5);
            start.AddEdge(b, 2);

            a.AddEdge(c, 4);
            a.AddEdge(d, 2);

            b.AddEdge(a, 8);
            b.AddEdge(d, 7);

            c.AddEdge(d, 6);
            c.AddEdge(fin, 3);

            d.AddEdge(fin, 1);

            var graph = new List<Node>() { start, a, b, c, d, fin };
            var shortestPath = FindShortestPath(graph);
            Console.WriteLine($"Shortest path from 'start' to 'fin' is {shortestPath} by Dijkstra's algorithm for directed acyclic graphs");

            Console.ReadLine();
        }

        private static float FindShortestPath(IEnumerable<Node> graph)
        {
            var start = graph.FirstOrDefault(x => x.Name == "start");
            var fin = graph.FirstOrDefault(x => x.Name == "fin");

            var costs = InitCosts(graph, start, fin);
            var parents = InitParents(graph, start, fin);
            var processed = new HashSet<Node>();

            var node = FindLowestCostNode(costs, processed);
            while (node != null)
            {
                var cost = costs[node];
                var edges = node.Edges;
                foreach (var edge in edges)
                {
                    var newCost = cost + edge.Distance;
                    if (!costs.ContainsKey(edge.Node) || costs[edge.Node] > newCost)
                    {
                        costs[edge.Node] = newCost;
                        parents[edge.Node] = node;
                    }
                }

                processed.Add(node);
                node = FindLowestCostNode(costs, processed);
            }

            //var path = GetPath(parents, start, fin);
            //Console.WriteLine(path.Reverse().Stringify());
            return costs[fin];
        }

        private static IEnumerable<Node> GetPath(Dictionary<Node, Node> parents, Node start, Node fin)
        {
            var path = new List<Node>() { fin };
            var finPath = parents[fin];
            path.Add(finPath);
            while (!Equals(finPath, start))
            {
                finPath = parents[finPath];
                path.Add(finPath);
            }

            return path;
        }

        private static Node FindLowestCostNode(Dictionary<Node, float> costs, IReadOnlySet<Node> processed)
        {
            var notProcessed = costs.Where(x => !processed.Contains(x.Key));
            return notProcessed.Any() ? notProcessed.Aggregate((x, y) => x.Value < y.Value ? x : y).Key : null;
        }

        private static Dictionary<Node, Node> InitParents(IEnumerable<Node> graph, Node start, Node fin)
        {
            var parents = new Dictionary<Node, Node>();
            foreach (var edge in start.Edges)
            {
                parents[edge.Node] = start;
            }

            if (!parents.ContainsKey(fin))
                parents[fin] = null;

            return parents;
        }

        private static Dictionary<Node, float> InitCosts(IEnumerable<Node> graph, Node start, Node fin)
        {
            var costs = new Dictionary<Node, float>();
            foreach (var edge in start.Edges)
            {
                costs[edge.Node] = edge.Distance;
            }

            if (!costs.ContainsKey(fin))
                costs[fin] = float.PositiveInfinity;

            return costs;
        }
    }
}
