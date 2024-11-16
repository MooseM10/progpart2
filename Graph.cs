using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    public class Graph
    {
        private Dictionary<string, List<(string destination, int weight)>> adjacencyList = new Dictionary<string, List<(string, int)>>();

        public void AddEdge(string source, string destination, int weight)
        {
            if (!adjacencyList.ContainsKey(source))
                adjacencyList[source] = new List<(string, int)>();

            adjacencyList[source].Add((destination, weight));
        }

        public void DisplayGraph()
        {
            foreach (var node in adjacencyList)
            {
                Console.WriteLine($"{node.Key}:");
                foreach (var edge in node.Value)
                {
                    Console.WriteLine($"  -> {edge.destination} (Weight: {edge.weight})");
                }
            }
        }

        public void PerformDFS(string start)
        {
            HashSet<string> visited = new HashSet<string>();
            DFS(start, visited);
        }

        private void DFS(string node, HashSet<string> visited)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                Console.WriteLine(node);

                if (adjacencyList.ContainsKey(node))
                {
                    foreach (var edge in adjacencyList[node])
                    {
                        DFS(edge.destination, visited);
                    }
                }
            }
        }
    }
}
