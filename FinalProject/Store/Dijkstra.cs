using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Store
{
    using global::FinalProject.DTO;
    using System.Collections.Generic;
    public class Dijkstra<T>
    {
        //3333333333333333
        public Dictionary<Node<T>, int> ShortestPath(Node<T> start, Dictionary<Node<T>, List<Edge<T>>> graph)
        {
            // Initialize distances from start to all other nodes as infinity
            var distances = new Dictionary<Node<T>, int>();
            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
            }

            // Distance from start to start is 0
            distances[start] = 0;

            // Initialize priority queue (heap) with start node and its distance
            var priorityQueue = new SortedSet<(int distance, Node<T> node)>();
            priorityQueue.Add((0, start));

            while (priorityQueue.Any())
            {
                // Get node with the smallest distance from the priority queue
                var (currentDistance, currentNode) = priorityQueue.First();
                priorityQueue.Remove((currentDistance, currentNode));

                // Visit each neighbor of the current node
                foreach (var edge in graph[currentNode])
                {
                    var neighbor = edge.Target;
                    var weight = edge.Weight;
                    var distanceToNeighbor = currentDistance + weight;

                    // If the new distance is shorter, update the distance and add the neighbor to the priority queue
                    if (distanceToNeighbor < distances[neighbor])
                    {
                        distances[neighbor] = distanceToNeighbor;
                        priorityQueue.Add((distanceToNeighbor, neighbor));
                    }
                }
            }

            return distances;
        }


    }


    //1111111111111111111
    ////public static Dictionary<string, string> DijkstraF(Dictionary<string, Dictionary<string, string>> graph, string startNode)
    //public static Dictionary<int, int> DijkstraF(Dictionary<int, Dictionary<int, int>> graph, int startNode)
    //{
    //    // Create a dictionary to hold the distances from the start node to each node in the graph
    //    Dictionary<int, int> distances = new Dictionary<int, int>();

    //    // Create a set to keep track of visited nodes
    //    HashSet<int> visited = new HashSet<int>();

    //    // Initialize distances to all nodes as infinity except the start node
    //    foreach (var node in graph.Keys)
    //    {
    //        distances[node] = int.MaxValue;
    //    }
    //    distances[startNode] = 0;

    //    // Loop until all nodes have been visited
    //    while (visited.Count < graph.Count)
    //    {
    //        // Find the node with the smallest distance from the start node
    //        int minNode = -1;
    //        int minDistance = int.MaxValue;
    //        foreach (var node in graph.Keys)
    //        {
    //            if (!visited.Contains(node) && distances[node] < minDistance)
    //            {
    //                minNode = node;
    //                minDistance = distances[node];
    //            }
    //        }

    //        // If there is no reachable node, break out of the loop
    //        if (minNode == -1)
    //            break;

    //        // Mark the current node as visited
    //        visited.Add(minNode);

    //        // Update the distances to neighboring nodes
    //        foreach (var neighbor in graph[minNode])
    //        {
    //            int distance = distances[minNode] + neighbor.Value;
    //            if (distance < distances[neighbor.Key])
    //            {
    //                distances[neighbor.Key] = distance;
    //            }
    //        }
    //    }

    //    // Return the computed distances
    //    return distances;
    //}
    //public static Dictionary<string, string> DijkstraF(Dictionary<string, Dictionary<string, string>> graph, string startNode)
    //22222222222222222222222222222222222222222
    //public static Dictionary<string, string> DijkstraF(string destination, string source)
    //{
    //    // Dictionary to store distances from startNode to each node
    //    Dictionary<string, int> distances = new Dictionary<string, int>();
    //    // Dictionary to store previous node in the shortest path
    //    Dictionary<string, string> previous = new Dictionary<string, string>();
    //    // Initialize distances and previous nodes
    //    foreach (var node in graph.Keys)
    //    {
    //        distances[node] = int.MaxValue;
    //        previous[node] = null;
    //    }

    //    // Distance from startNode to itself is 0
    //    distances[startNode] = 0;

    //    // Priority queue to store nodes ordered by distance
    //    var queue = new SortedSet<Tuple<int, string>>();
    //    queue.Add(new Tuple<int, string>(0, startNode));

    //    while (queue.Count > 0)
    //    {
    //        // Extract node with minimum distance
    //        string currentNode = queue.Min.Item2;
    //        queue.Remove(queue.Min);

    //        // Explore neighbors of current node
    //        foreach (var neighbor in graph[currentNode])
    //        {
    //            int alt = distances[currentNode] + int.Parse(neighbor.Value); // Assuming the values in the graph are string representations of integers
    //            if (alt < distances[neighbor.Key])
    //            {
    //                distances[neighbor.Key] = alt;
    //                previous[neighbor.Key] = currentNode;
    //                queue.Add(new Tuple<int, string>(alt, neighbor.Key));
    //            }
    //        }
    //    }

    //    return previous;
    //}
    //public static void Main(string[] args)
    //{
    //    // Example graph representation (node, (neighbor node, weight))
    //    Dictionary<string, Dictionary<string, string>> graph = new Dictionary<string, Dictionary<string, string>>
    //{
    //    {"0", new Dictionary<string, string>{{"1", "4" }, {"2", "8"}}},
    //    {"1", new Dictionary<string, string>{{"2", "2"}, {"3","5" }}},
    //    {"2", new Dictionary<string, string>{{"4", "3"}}},
    //    {"3", new Dictionary<string, string>{{"4","7"}}},
    //    {"4", new Dictionary<string, string>()}
    //};
    //    string example = "example";

    //    // Calculate distances from node 0
    //    Dictionary<int, int> distances = DijkstraF(graph, example);

    //    // Output distances
    //    foreach (var kvp in distances)
    //    {
    //        Console.WriteLine($"Distance to node {kvp.Key}: {kvp.Value}");
    //    }
    //}
}

