using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Dictionary<string, List<string>>
            {
                ["you"] = new List<string>() {"Alice", "Bob", "Claire"},
                ["Bob"] = new List<string>() {"Anuj", "Peggy"},
                ["Alice"] = new List<string>() {"Peggy"},
                ["Claire"] = new List<string>() {"Thom", "Jonny"},
                ["Anuj"] = new List<string>(),
                ["Peggy"] = new List<string>(),
                ["Thom"] = new List<string>(),
                ["Jonny"] = new List<string>()
            };

            var mangoSeller = Search(graph);
            Console.WriteLine($"Mango seller name is {mangoSeller}");

            Console.ReadKey();
        }

        private static string Search(Dictionary<string, List<string>> graph)
        {
            var queue = new Queue<string>();
            var checkedList = new List<string>();
            AddListToQueue(graph["you"], queue);
            while (queue.Count != 0)
            {
                var name = queue.Dequeue();
                if (checkedList.Contains(name)) 
                    continue;

                if (IsMangoSeller(name))
                    return name;

                AddListToQueue(graph[name], queue);
                checkedList.Add(name);
            }

            return null;
        }

        private static void AddListToQueue(List<string> list, Queue<string> queue) => list.ForEach(queue.Enqueue);

        private static bool IsMangoSeller(string name) => name[^1] == 'm';
    }
}
