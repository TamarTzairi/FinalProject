using FinalProject.DTO;
using FinalProject.Interfaces;
using System.Numerics;

namespace FinalProject.Store
{
    public class Mat : IMat
    {
        //public Dictionary<object, int> objectToIndex;
        //public Dictionary<int, object> indexToObject;
        //public SortedSet<(object, int)> objectToIndex;
        //public SortedSet<(int, object)> indexToObject;

        public (Dictionary<string, double>, Dictionary<string, string>)[] buildMat(Node graph)
        {
            Landmark landmark = new Landmark();//----------------------------אמור להיות המבנה של הלקוח--------------------
            var matrix = new (Dictionary<string, double>, Dictionary<string, string>)[Global.Global.count];
            Dijkstra dijkstra = new Dijkstra();
            //var saveGraph = graph;

            for (int i = 0; i < Global.Global.count; i++)
            {
                graph.indexMat = i;
                //הוא מוצא את המסלול הכי קצר מנקודה
                //j לנקודה i
                var d = dijkstra.DijkstraAlgorithm(graph, graph.NodeId);
                matrix[i] = d;

                if (graph.Neighbors == null)
                {
                    graph = graph.Previous;
                }
                //בשביל לקדם את הגרף
                for (int j = 0; j < graph.Neighbors.Count; j++)
                {
                    if (graph.Neighbors[j].nodeNeighbor.indexMat == -1)
                    {
                        graph = graph.Neighbors[j].nodeNeighbor;
                        break;
                    }
                    if (j == graph.Neighbors.Count-1)
                    {
                       // graph = graph.Previous.Previous;
                        graph = graph.Previous.Previous;

                    }
                }
            }
            return matrix;

            //var nodeIds = priorityQueue.Select(p => p.NodeId).ToList();

            //int size = nodeIds.Count;
            //var matrix = new Room[size, size];
            //var nodeIndexMap = new Dictionary<string, int>();
            //for (int i = 0; i < size; i++)
            //{
            //    nodeIndexMap[nodeIds[i]] = i;
            //}
            //foreach (var nodeId in nodeIds)
            //{
            //    // Get the shortest paths from the current node
            //    var shortestPaths = Dijkstra.InitailGraph(landmark, nodeId);

            //    foreach (var kvp in shortestPaths)
            //    {
            //        string targetNodeId = kvp.Key;
            //        double distance = kvp.Value;

            //        int rowIndex = nodeIndexMap[nodeId];
            //        int colIndex = nodeIndexMap[targetNodeId];

            //        matrix[rowIndex, colIndex] = new Node<Room>
            //        {
            //            // Assuming Node<Room> has properties like Id and Distance
            //            Id = targetNodeId,
            //            Distance = distance,
            //            // Add additional properties as needed
            //        };
            //    }
            //}




            /*var protectedRooms = new List<string>();
            var normalRooms = new List<string>();

            foreach (var item in priorityQueue)
            {
                if (IsProtectedRoom(item.NodeId))
                {
                    protectedRooms.Add(item.NodeId);
                }
                else
                {
                    normalRooms.Add(item.NodeId);
                }
            }

            // Determine the size of the matrix
            int protectedRoomCount = protectedRooms.Count;
            int normalRoomCount = normalRooms.Count;

            // Initialize the matrix
            var matrix = new Node<Room>[protectedRoomCount, normalRoomCount];

            // Create mappings from NodeId to integer indices
            var nodeIdToIndex = new Dictionary<string, int>();
            int index = 0;
            foreach (var nodeId in protectedRooms)
            {
                nodeIdToIndex[nodeId] = index++;
            }
            index = 0;
            foreach (var nodeId in normalRooms)
            {
                nodeIdToIndex[nodeId] = index++;
            }

            // Fill the matrix with distances
            foreach (var (distance, nodeId) in priorityQueue)
            {
                if (IsProtectedRoom(nodeId))
                {
                    int i = nodeIdToIndex[nodeId];
                    for (int j = 0; j < normalRoomCount; j++)
                    {
                        string normalRoomId = normalRooms[j];
                        matrix[i, j] = new Node<Room> { Distance = distance, NodeId = normalRoomId };
                    }
                }
                else
                {
                    int j = nodeIdToIndex[nodeId];
                    for (int i = 0; i < protectedRoomCount; i++)
                    {
                        string protectedRoomId = protectedRooms[i];
                        matrix[i, j] = new Node<Room> { Distance = distance, NodeId = protectedRoomId };
                    }
                }
            }*/



            /*objectToIndex = new SortedSet<(object, int)>();
            indexToObject = new SortedSet<(int, object)>();
            int index = 0;
            objectToIndex[priorityQueue] = index;
            indexToObject[index] = priorityQueue;
            index++;*/

        }
        /*     public int[,] FillRoutesMatrix(Landmark landmark1, ProtectedSpaceRoom[] safeRoom, Class[] normalRooms)
             {
                 // Get the number of nodes in the graph
                 //int numNodes = graph.Count;

                 // Initialize the routes matrix with all distances as infinity
                 int[,] routesMatrix = new int[normalRooms.Length, safeRoom.Length];
                 for (int i = 0; i < normalRooms.Length; i++)
                 {
                     for (int j = 0; j < safeRoom.Length; j++)
                     {
                         routesMatrix[i, j] = Dijkstra.InitailGraph(landmark1, safeRoom[j].PsrRoom.RoomId);
                     }
                 }

                 //// Compute shortest routes between all pairs of nodes using Dijkstra's algorithm
                 //for (int i = 0; i < normalRooms.Length; i++)
                 //{
                 //    Dictionary<int, int> distances = Dijkstra.DijkstraF(graph, i);

                 //    foreach (var kvp in distances)
                 //    {
                 //        routesMatrix[i, kvp.Key] = kvp.Value;
                 //    }
                 //}

                 return routesMatrix;
             }*/

    }
}
