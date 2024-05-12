using Amazon.Runtime;
using FinalProject.DTO;
using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace FinalProject.Store
{
    public class Graph
    {
        //public Dictionary<object, int> objectToIndex;
        //public Dictionary<int, object> indexToObject;

        public void buildGraph(Landmark landmark)
        {
            //objectToIndex = new Dictionary<object, int>();
            //indexToObject = new Dictionary<int, object>();
            //int index = 0;
            
            for (int i = 0; i < landmark.Corridors.GetLength(0); i++)
            {
                Node<Corridor> corridor = null;
                corridor.NodeId = landmark.Corridors[i].CorridorId;
                corridor.Edges = new List<Edge<Corridor>>();
                corridor.Data = landmark.Corridors[i].CorridorLandmark;

                for (int j = 0; j < landmark.Corridors[i].ClassList.GetLength(1); j++)
                {
                    Node<Class> nodeClass = null;
                    nodeClass.NodeId = landmark.Corridors[i].ClassList[j].ClassRoom.RoomId;
                    nodeClass.Edges = new List<Edge<Class>>();//כי אין לחדר שכנים
                    nodeClass.Data = landmark.Corridors[i].ClassList[j].ClassRoom;
                    Edge<Class> edgeClass = null;
                    edgeClass.Source = nodeClass; //מקור
                    edgeClass.Target = corridor;//יעד
                    edgeClass.Weight = WeightCalculation(corridor.Data, nodeClass.Data);//------------------------------------------------------------------------
                    nodeClass.AddEdge(corridor,edgeClass.Weight);
                    corridor.AddEdge(nodeClass, edgeClass.Weight);
                    //objectToIndex[nodeClass] = index;
                    //indexToObject[index] = nodeClass;
                    //index++;
                }
                for (int j = 0; j < landmark.Corridors[i].ProtectedSpaceRoomList.GetLength(1); j++)
                {
                    Node<ProtectedSpaceRoom> nodePsr = null;
                    nodePsr.NodeId = landmark.Corridors[i].ProtectedSpaceRoomList[j].PsrRoom.RoomId;
                    nodePsr.Edges = new List<Edge<ProtectedSpaceRoom>>();//כי אין לחדר שכנים
                    Edge<ProtectedSpaceRoom> edgePsr = null;
                    edgePsr.Target = nodePsr;//יעד
                    edgePsr.Source = corridor;//מקור
                    edgePsr.Weight = 0;//---------------------------------------------------------------------------
                    nodePsr.AddEdge(corridor, edgePsr.Weight);
                    corridor.AddEdge(nodePsr, edgePsr.Weight);
                    //objectToIndex[nodePsr] = index;
                    //indexToObject[index] = nodePsr;
                    //index++;
                }
            }

        }
        public double WeightCalculation(Room room1, Room room2)
        {
            double weight = Math.Sqrt(Math.Pow(room1.X - room2.X, 2) + Math.Pow(room1.Y - room2.Y, 2));
            return weight;
        }
    }
}
