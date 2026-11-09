using System;
using System.Collections.Generic;

namespace DSA.Lab05
{
    /// <summary>
    /// Iterative graph traversals.
    ///
    /// BFS changes the frontier to a Queue.
    /// DFS changes the frontier to a Stack.
    /// Both need a visited set because graphs may contain cycles and multiple paths.
    /// </summary>
    public static class GraphTraversal
    {
        public static IReadOnlyList<string> BreadthFirstOrder(
            AdjacencyGraph graph,
            string start)
        {
            EnsureStartExists(graph, start);

            var result = new List<string>();
            var frontier = new Queue<string>();
            var visited = new HashSet<string>();

            visited.Add(start);
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();
                result.Add(current);

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (visited.Add(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        public static IReadOnlyList<string> DepthFirstOrder(
            AdjacencyGraph graph,
            string start)
        {
            EnsureStartExists(graph, start);

            var result = new List<string>();
            var frontier = new Stack<string>();
            var visited = new HashSet<string>();

            visited.Add(start);
            frontier.Push(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Pop();
                result.Add(current);

                IReadOnlyList<string> neighbors = graph.GetNeighbors(current);

                // Push in reverse so the first authored neighbor is processed first.
                for (int i = neighbors.Count - 1; i >= 0; --i)
                {
                    string neighbor = neighbors[i];

                    if (visited.Add(neighbor))
                    {
                        frontier.Push(neighbor);
                    }
                }
            }

            return result;
        }

        public static bool IsReachableBfs(
            AdjacencyGraph graph,
            string start,
            string target)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(target))
            {
                return false;
            }

            var frontier = new Queue<string>();
            var visited = new HashSet<string>();

            visited.Add(start);
            frontier.Enqueue(start);

            while (frontier.Count > 0)
            {
                string current = frontier.Dequeue();

                if (current == target)
                {
                    return true;
                }

                foreach (string neighbor in graph.GetNeighbors(current))
                {
                    if (visited.Add(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                    }
                }
            }

            return false;
        }

        private static void EnsureStartExists(AdjacencyGraph graph, string start)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start))
            {
                throw new ArgumentException(
                    $"Unknown start node '{start}'.",
                    nameof(start));
            }
        }
    }
}
