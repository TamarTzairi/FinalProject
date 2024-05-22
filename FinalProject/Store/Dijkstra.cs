using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Store;
namespace FinalProject.Store
{
    using global::FinalProject.DTO;
    using System.Collections.Generic;


    public class Dijkstra
    {
        public static Dictionary<string, double> Distances { get; private set; }//מרחק
        public static Dictionary<string, string> Previous { get; private set; }//האבא הקודם

        public static int Execute(Landmark landmark, string startId)
        {
            // Initialize the distances and previous dictionaries
            Distances = new Dictionary<string, double>();//איתחול
            Previous = new Dictionary<string, string>();//איתחול
            var priorityQueue = new SortedSet<(double Distance, string NodeId)>();//תור קדימויות-ממוין לפי מרחק מנקודת התחלה


            foreach (var corridor in landmark.Corridors)
            {
                Distances[corridor.CorridorId] = double.MaxValue;//איתחול לאינסוף
                Previous[corridor.CorridorId] = null;//איתחול האבא ל נאל
                priorityQueue.Add((double.MaxValue, corridor.CorridorId));

                foreach (var cls in corridor.ClassList)
                {
                    var roomId = cls.ClassRoom.RoomId;
                    Distances[roomId] = double.MaxValue;
                    Previous[roomId] = null;
                    priorityQueue.Add((double.MaxValue, roomId));
                }

                foreach (var psr in corridor.ProtectedSpaceRoomList)
                {
                    var roomId = psr.PsrRoom.RoomId;
                    Distances[roomId] = double.MaxValue;
                    Previous[roomId] = null;
                    priorityQueue.Add((double.MaxValue, roomId));
                }
            }

            // Set the distance for the start node to 0-צומת התחלה מוגדרת ל
            Distances[startId] = 0;
            priorityQueue.Add((0, startId));

            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentNode) = priorityQueue.First();//מרחק-צומת
                priorityQueue.Remove(priorityQueue.First());

                // Get the current node's neighbors
                var neighbors = GetNeighbors(landmark, currentNode);

                foreach (var (neighborId, weight) in neighbors)
                {
                    //בודק האם המרחק החדש הוא קטן יותר ואם כן עושה הקלה
                    var newDistance = currentDistance + weight;
                    if (newDistance < Distances[neighborId])
                    {
                        priorityQueue.Remove((Distances[neighborId], neighborId));
                        Distances[neighborId] = newDistance;
                        Previous[neighborId] = currentNode;
                        priorityQueue.Add((newDistance, neighborId));
                    }
                }
            }
            return 0;
        }

        private static List<(string NeighborId, double Weight)> GetNeighbors(Landmark landmark, string nodeId)
        {
            var neighbors = new List<(string NeighborId, double Weight)>();

            foreach (var corridor in landmark.Corridors)
            {
                if (corridor.CorridorId == nodeId)
                {
                    foreach (var cls in corridor.ClassList)
                    {
                        neighbors.Add((cls.ClassRoom.RoomId, WeightCalculation(corridor.CorridorLandmark, cls.ClassRoom)));
                    }
                    foreach (var psr in corridor.ProtectedSpaceRoomList)
                    {
                        neighbors.Add((psr.PsrRoom.RoomId, WeightCalculation(corridor.CorridorLandmark, psr.PsrRoom)));
                    }
                }
                else
                {
                    foreach (var cls in corridor.ClassList)
                    {
                        if (cls.ClassRoom.RoomId == nodeId)
                        {
                            neighbors.Add((corridor.CorridorId, WeightCalculation(cls.ClassRoom, corridor.CorridorLandmark)));
                        }
                    }
                    foreach (var psr in corridor.ProtectedSpaceRoomList)
                    {
                        if (psr.PsrRoom.RoomId == nodeId)
                        {
                            neighbors.Add((corridor.CorridorId, WeightCalculation(psr.PsrRoom, corridor.CorridorLandmark)));
                        }
                    }
                }
            }

            return neighbors;
        }

        private static double WeightCalculation(Room room1, Room room2)
        {
            double weight = Math.Sqrt(Math.Pow(room1.X - room2.X, 2) + Math.Pow(room1.Y - room2.Y, 2));
            return weight;
        }
    }
}



