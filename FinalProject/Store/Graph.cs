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
            Room data= new Room();
            data.Amount = 0;
            data.X = 0;
            data.Y = 0;
            data.RoomId= landmark.LandmarkId;
            graph.Data = data;

            foreach (var item1 in landmark.Corridors)
            {
                Node corridor = new Node(null);
                Global.Global.count++;
                corridor.NodeId = item1.CorridorId;
                corridor.type = "Corridor";
                corridor.indexMat = -1;
                corridor.Previous = graph;
                corridor.Neighbors = new List<Edge>();
                corridor.Data = item1.CorridorLandmark;
                Edge neighborL = new Edge( corridor, 0);
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
                    Edge neighborC = new Edge( nodeClass, WeightCalculation(item.ClassRoom, item1.CorridorLandmark));
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
                    Edge neighborC = new Edge(nodePsr, WeightCalculation(item.PsrRoom, item1.CorridorLandmark));
                    corridor.Neighbors.Add(neighborC);
                }
            }

            return graph;

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

        }
        public double WeightCalculation(Room room1, Room room2)
        {
            double weight = Math.Sqrt(Math.Pow(room1.X - room2.X, 2) + Math.Pow(room1.Y - room2.Y, 2));
            return weight;
        }
    }


}
