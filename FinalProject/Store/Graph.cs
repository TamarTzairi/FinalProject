using Amazon.Runtime;
using FinalProject.DTO;
using FinalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
namespace FinalProject.Store
{
    public class Graph : IGraph
    {
        public Node buildGraph(Landmark landmark)
        {
            Node graph = new Node(null); ;
            Global.Global.count++;
            graph.NodeId = landmark.LandmarkId;
            graph.type = "Landmark";
            graph.indexMat = -1;
            graph.Previous = null;
            graph.Neighbors = new List<Edge>();
            Room data = new Room();
            data.Amount = 0;
            data.X = 0;
            data.Y = 0;
            data.RoomId = landmark.LandmarkId;
            graph.Data = data;
            graph.floor = -500;

            foreach (var item1 in landmark.Corridors)
            {
                Node corridor = new Node(null);
                Global.Global.count++;
                corridor.NodeId = item1.CorridorId;
                corridor.type = "Corridor";
                corridor.indexMat = -1;
                corridor.Previous = graph;
                corridor.Neighbors = new List<Edge>();
                item1.CorridorLandmark.Amount = (int)WeightCalculation2(item1.StartPointX, item1.EndPointX, item1.StartPointY, item1.EndPointY);
                corridor.Data = item1.CorridorLandmark;
                corridor.floor = item1.Floor;
                Edge neighborL = new Edge(corridor, 0);
                graph.Neighbors.Add(neighborL);

                foreach (var item in item1.ClassList)
                {
                    Node nodeClass = new Node(null);
                    Global.Global.count++;
                    nodeClass.NodeId = item.ClassRoom.RoomId;
                    nodeClass.type = "Class";
                    nodeClass.indexMat = -1;
                    nodeClass.Previous = corridor;
                    nodeClass.Neighbors = new List<Edge>();//כי אין לחדר שכנים
                    nodeClass.Data = item.ClassRoom;
                    nodeClass.floor = item1.Floor;
                    Edge neighborC = new Edge(nodeClass, WeightCalculation(item.ClassRoom, item1.CorridorLandmark));
                    corridor.Neighbors.Add(neighborC);
                }
                foreach (var item in item1.ProtectedSpaceRoomList)
                {
                    Node nodePsr = new Node(null);
                    Global.Global.count++;
                    nodePsr.NodeId = item.PsrRoom.RoomId;
                    nodePsr.type = "ProtectedSpaceRoom";
                    nodePsr.indexMat = -1;
                    nodePsr.Previous = corridor;
                    nodePsr.Neighbors = new List<Edge>();//כי אין לחדר שכנים
                    nodePsr.Data = item.PsrRoom;
                    nodePsr.floor = item1.Floor;
                    Edge neighborC = new Edge(nodePsr, WeightCalculation(item.PsrRoom, item1.CorridorLandmark));
                    corridor.Neighbors.Add(neighborC);
                }
            }
            //מחבר בין המסדרונות השכנים
            foreach (var item in landmark.Corridors)
            {
                foreach (var item1 in landmark.Corridors)
                {
                    if (((item.EndPointX == item1.EndPointX) && (item.EndPointY == item1.EndPointY)) ||
                        ((item.StartPointX == item1.StartPointX) && (item.StartPointY == item1.StartPointY)) ||
                        ((item.StartPointX == item1.EndPointX) && (item.StartPointY == item1.EndPointY)) ||
                        ((item.EndPointX == item1.StartPointX) && (item.EndPointY == item1.StartPointY)))
                    {
                        int number = Math.Abs(item.Floor - item1.Floor)+1;                       
                        Edge edge = graph.Neighbors.Find(x => x.nodeNeighbor.NodeId == item1.CorridorId);
                        edge.Weight = WeightCalculation(item.CorridorLandmark, item1.CorridorLandmark)*number;
                        graph.Neighbors.Find(x => x.nodeNeighbor.NodeId == item.CorridorId).nodeNeighbor.Neighbors.Add(edge);
                    }
                }
            }
            return graph;
        }
        public double WeightCalculation(Room room1, Room room2)
        {
            double weight = Math.Sqrt(Math.Pow(room1.X - room2.X, 2) + Math.Pow(room1.Y - room2.Y, 2));
            return weight;
        }
        public double WeightCalculation2(double x1, double x2, double y1, double y2)
        {
            double weight = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return weight;
        }
    }
}
//זה טוב ועובד
/*for (int i = 0; i < landmark.Corridors.Length; i++)
{

     for (int j = 0; j < landmark.Corridors[i].ClassList.Length; j++)
     {
         Node<Class> nodeClass = null;
         nodeClass.NodeId = landmark.Corridors[i].ClassList[j].ClassRoom.RoomId;
         nodeClass.Edges = new List<Edge<Class>>();//כי אין לחדר שכנים
         nodeClass.Data = landmark.Corridors[i].ClassList[j].ClassRoom;
         //Edge<Class> edgeClass = null;
         //edgeClass.Source = nodeClass; //מקור
         //edgeClass.Target = corridor;//יעד
         //edgeClass.Weight = WeightCalculation(corridor.Data, nodeClass.Data);//------------------------------------------------------------------------
         //nodeClass.AddEdge(corridor, edgeClass.Weight);
         //corridor.AddEdge(nodeClass, edgeClass.Weight);
         //objectToIndex[nodeClass] = index;
         //indexToObject[index] = nodeClass;
         //index++;
     }
     for (int j = 0; j < landmark.Corridors[i].ProtectedSpaceRoomList.Length; j++)
     {
         Node<ProtectedSpaceRoom> nodePsr = null;
         nodePsr.NodeId = landmark.Corridors[i].ProtectedSpaceRoomList[j].PsrRoom.RoomId;
         nodePsr.Edges = new List<Edge<ProtectedSpaceRoom>>();//כי אין לחדר שכנים
         //Edge<ProtectedSpaceRoom> edgePsr = null;
         //edgePsr.Target = nodePsr;//יעד
         //edgePsr.Source = corridor;//מקור
         //edgePsr.Weight = 0;//---------------------------------------------------------------------------
         //nodePsr.AddEdge(corridor, edgePsr.Weight);
         //corridor.AddEdge(nodePsr, edgePsr.Weight);
         //objectToIndex[nodePsr] = index;
         //indexToObject[index] = nodePsr;
         //index++;
     }
}*/