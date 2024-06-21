using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using global::FinalProject.DTO;
using MongoDB.Driver;
using FinalProject.Interfaces;

namespace FinalProject.Store
{
    public class Dijkstra : IDijkstra
    {



        // public Dictionary<string, Dictionary<string, int>> AdjacencyList { get; } = new Dictionary<string, Dictionary<string, int>>();

        //public void AddEdge(string source, string target, int weight)
        //{
        //    if (!AdjacencyList.ContainsKey(source))
        //        AdjacencyList[source] = new Dictionary<string, int>();

        //    AdjacencyList[source][target] = weight;

        //    if (!AdjacencyList.ContainsKey(target))
        //        AdjacencyList[target] = new Dictionary<string, int>();
        //}



        public (Dictionary<string, double> distances, Dictionary<string, string> previous) DijkstraAlgorithm(Node graph, string source)
        {
            var distances = new Dictionary<string, double>();// מכיל את האידי של הנוד ואת המרחק
            var previous = new Dictionary<string, string>();// מכיל את האידי של הנוד ואת אבא שלו
            var priorityQueue = new SortedSet<(double distance, string node)>();

            foreach (var node in graph.Neighbors)
            {
                distances[node.nodeNeighbor.NodeId] = int.MaxValue;
                previous[node.nodeNeighbor.NodeId] = null;
                priorityQueue.Add((double.MaxValue, node.nodeNeighbor.NodeId));
            }

            distances[source] = 0;
            priorityQueue.Add((0, source));

            while (priorityQueue.Count > 0)
            {
                var u = priorityQueue.Min;
                priorityQueue.Remove(u);

                foreach (var neighbor in graph.Neighbors)
                {
                    var v = neighbor.nodeNeighbor.NodeId;
                    var length = neighbor.Weight;
                    var tempDist = distances[u.node] + length;

                    if (tempDist < distances[v])
                    {
                        priorityQueue.Remove((distances[v], v));
                        distances[v] = tempDist;
                        previous[v] = u.node;
                        priorityQueue.Add((distances[v], v));
                    }
                }
            }

            return (distances, previous);
        }


    }
    //טוב טוב טוב
    /* public static Dictionary<string, double> Distances { get; private set; }//מרחק
     public static Dictionary<string, string> Previous { get; private set; }//האבא הקודם

     public SortedSet<(double Distance, Node NodeId)> InitailGraph(Landmark landmark, Node startNode)
     {

         // Initialize the distances and previous dictionaries
         Distances = new Dictionary<string, double>();//איתחול
         Previous = new Dictionary<string, string>();//איתחול
         var priorityQueue = new SortedSet<(double Distance, Node node)>();//עץ חיפוש בינארי -ממוין לפי מרחק מנקודת התחלה
         //איתחול הגרף
         foreach (var corridor in startNode.Neighbors)
         {
             Distances[corridor.Target.NodeId] = double.MaxValue;//איתחול לאינסוף
             Previous[corridor.Target.NodeId] = null;//איתחול האבא ל- נאל
             priorityQueue.Add((double.MaxValue, corridor.Target));

             foreach (var cls in corridor.Target.Neighbors)
             {
                 var roomId = cls.Target.NodeId;
                 Distances[roomId] = double.MaxValue;
                 Previous[roomId] = null;
                 priorityQueue.Add((double.MaxValue, cls.Target));
             }

             /*foreach (var psr in corridor.ProtectedSpaceRoomList)
             {
                 var roomId = psr.PsrRoom.RoomId;
                 Distances[roomId] = double.MaxValue;
                 Previous[roomId] = null;
                 priorityQueue.Add((double.MaxValue, roomId));
             }
         }

         // Set the distance for the start node to 0-צומת התחלה מוגדרת ל
         Distances[startNode.NodeId] = 0;
         priorityQueue.Add((0, startNode));

         while (priorityQueue.Count > 0)
         {
             var (currentDistance, currentNode) = priorityQueue.First();//מרחק-צומת
             priorityQueue.Remove(priorityQueue.First()); //מוחק את האיבר הראשון

             // Get the current node's neighbors
             //var neighbors = GetNeighbors(landmark, currentNode);

             foreach (var node in startNode.Neighbors)
             {
                 //בודק האם המרחק החדש הוא קטן יותר ואם כן עושה הקלה
                 var newDistance = currentDistance + node.Weight;
                 if (newDistance < Distances[node.Target.NodeId])
                 {
                     priorityQueue.Remove((Distances[node.Target.NodeId], node.Target));
                     Distances[node.Target.NodeId] = newDistance;
                     Previous[node.Target.NodeId] = currentNode.NodeId;
                     priorityQueue.Add((newDistance, node.Target));
                 }
             }
         }
         return priorityQueue;
     }*/
    //עד כאן טוב טוב טוב

    /*  private List<(string NeighborId, double Weight)> GetNeighbors(Landmark landmark, Node node)
      {
          var neighbors = new List<(string NeighborId, double Weight)>();

          foreach (var item in node.Neighbors)
          {
              neighbors.Add(item.Target.NodeId, item.Weight);

          }

         /* // עובר על כל המסדרונות
          foreach (var corridor in landmark.Corridors)
          {
              //אם הנוד הוא מסדרון
              if (corridor.CorridorId == nodeId)
              {
                  //תכניס את כל החדרים המוגנים והרגילים שלו בתור שכנים
                  foreach (var cls in corridor.ClassList)
                  {
                      neighbors.Add((cls.ClassRoom.RoomId, WeightCalculation(corridor.CorridorLandmark, cls.ClassRoom)));
                  }
                  foreach (var psr in corridor.ProtectedSpaceRoomList)
                  {
                      neighbors.Add((psr.PsrRoom.RoomId, WeightCalculation(corridor.CorridorLandmark, psr.PsrRoom)));
                  }
              }
              //אם הנוד לא מסדרון
              else
              {
                  //עובר על הכיתות הרגילות
                  foreach (var cls in corridor.ClassList)
                  {
                      //אם הנוד כיתה רגילה תכניס את המסדרון בתור שכן שלו
                      if (cls.ClassRoom.RoomId == nodeId)
                      {
                          neighbors.Add((corridor.CorridorId, WeightCalculation(cls.ClassRoom, corridor.CorridorLandmark)));
                      }
                  }
                  //עובר על החרים המוגנים
                  foreach (var psr in corridor.ProtectedSpaceRoomList)
                  {
                      //אם הנוד הוא חדר מוגן תכניס את המסדרון בתור שכן שלו
                      if (psr.PsrRoom.RoomId == nodeId)
                      {
                          neighbors.Add((corridor.CorridorId, WeightCalculation(psr.PsrRoom, corridor.CorridorLandmark)));
                      }
                  }
              }
          }

          return neighbors;
      }*/

    /*private double WeightCalculation(Room room1, Room room2)
    {
        double weight = Math.Sqrt(Math.Pow(room1.X - room2.X, 2) + Math.Pow(room1.Y - room2.Y, 2));
        return weight;
    }*/
}



