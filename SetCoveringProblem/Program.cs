using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace SetCoveringProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var statesNeeded = new HashSet<string>()
            {
                "mt", "wa", "or", "id", "nv", "ut",
                "ca", "az"
            };

            var stations = new Dictionary<string, HashSet<string>>
            {
                ["kone"] = new() {"ca", "az"},
                ["ktwo"] = new() {"wa", "id", "mt"},
                ["kthree"] = new() {"nv", "ut"},
                ["kfour"] = new() {"or", "nv", "ca"},
                ["kfive"] = new() {"id", "nv", "ut"}
            };

            var finalStations = GreedyAlgorithm(statesNeeded, stations);
            Console.WriteLine(finalStations.Stringify());

            Console.ReadKey();
        }

        private static IEnumerable<string> GreedyAlgorithm(ISet<string> statesNeeded, IDictionary<string, HashSet<string>> stations)
        {
            while (statesNeeded.Any())
            {
                var bestStation = default(string);
                var statesCovered = new HashSet<string>();

                foreach (var (station, statesForStation) in stations)
                {
                    var covered = new HashSet<string>(statesNeeded.Intersect(statesForStation));
                    if (covered.Count > statesCovered.Count)
                    {
                        bestStation = station;
                        statesCovered = covered;
                    }
                }

                statesNeeded.ExceptWith(statesCovered);
                yield return bestStation;
            }
        }
    }
}
