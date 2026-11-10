using System;
using System.Collections.Generic;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// Complete these methods after the adjacency representation is working.
    /// Think in terms of:
    /// frontier + visited + neighbors.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(AdjacencyGraph graph, string start)
        {
            HashSet<string> visited = new HashSet<string>();
            visited.Add(start);
            
            Queue<string> frontier = new Queue<string>();
            frontier.Enqueue(start);
            
            List<string> result = new List<string>();

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                result.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        frontier.Enqueue(neighbor);
                    }
                }
            }
            
            return result;
        }

        public static IReadOnlyList<string> DepthFirstOrder(AdjacencyGraph graph, string start)
        {
            HashSet<string> visited = new HashSet<string>();
            visited.Add(start);
            
            Stack<string> frontier = new Stack<string>();
            frontier.Push(start);
            
            List<string> result = new List<string>();

            while (frontier.Count > 0)
            {
                string current = frontier.Pop();
                result.Add(current);

                List<string> neighbors = new List<string>(graph.GetNeighbors(current));

                for (int i = neighbors.Count - 1; i >= 0; i--)
                {
                    if (!visited.Contains(neighbors[i]))
                    {
                        visited.Add(neighbors[i]);
                        frontier.Push(neighbors[i]);
                    }
                }
            }
            
            return result;
        }

        public static bool IsReachableBfs(AdjacencyGraph graph, string start, string target)
        {
            HashSet<string> visited = new HashSet<string>();
            visited.Add(start);
            
            Queue<string> frontier = new Queue<string>();
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                List<string> neighbors = new List<string>(graph.GetNeighbors(current));

                if (current == target || neighbors.Contains(target))
                {
                    return true;
                }

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        frontier.Enqueue(neighbor);
                    }
                }
            }
            
            return false;
        }
    }
}
