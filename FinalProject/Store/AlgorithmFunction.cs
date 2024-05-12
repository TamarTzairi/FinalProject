//using FinalProject.DTO;
//using System.IO;
//namespace FinalProject.Store
//{
//    public class AlgorithmFunction
//    {
//        int i, j = 0;
//        public bool FinalyFunction(Class[] normalRooms, ProtectedSpaceRoom[] safeRoom, int i, int j)
//        {
//            if (j>normalRooms.Length)
//            {
//                return false;//כשל
//            }

//            if (normalRooms[i].Amount <= safeRoom[j].Amount)
//            {
//                i++;
//                safeRoom[j].Amount -= normalRooms[i].Amount;

//            }
//            else
//            {
//                j++;
//            }
//            FinalyFunction(normalRooms, safeRoom, i, j);
//            return true;
//        }

//        public int[,] FillRoutesMatrix(/*Dictionary<int, Dictionary<int, int>> graph,*/ ProtectedSpaceRoom[] safeRoom, Class[] normalRooms)
//        {
//            // Get the number of nodes in the graph
//            //int numNodes = graph.Count;
            
//            // Initialize the routes matrix with all distances as infinity
//            int[,] routesMatrix = new int[ normalRooms.Length,safeRoom.Length];
//            for (int i = 0; i < normalRooms.Length; i++)
//            {
//                for (int j = 0; j < safeRoom.Length; j++)
//                {
//                    routesMatrix[i, j] = Dijkstra.DijkstraF(normalRooms[i].IdRoomClass, safeRoom[j].IdRoomPsr);
//                }
//            }

//            //// Compute shortest routes between all pairs of nodes using Dijkstra's algorithm
//            //for (int i = 0; i < normalRooms.Length; i++)
//            //{
//            //    Dictionary<int, int> distances = Dijkstra.DijkstraF(graph, i);

//            //    foreach (var kvp in distances)
//            //    {
//            //        routesMatrix[i, kvp.Key] = kvp.Value;
//            //    }
//            //}

//            return routesMatrix;
//        }
//        public static void Main(string[] args)
//        {
//            ProtectedSpaceRoom[] safeRoom = new ProtectedSpaceRoom[5];
//            Class[] normalRooms = new Class[5];
//            safeRoom[0].Amount = 10;
//            safeRoom[1].Amount = 20;
//            safeRoom[2].Amount = 25;
//            safeRoom[3].Amount = 30;
//            safeRoom[4].Amount = 45;
//            normalRooms[0].Amount = 10;
//            normalRooms[1].Amount = 16;
//            normalRooms[2].Amount = 25;
//            normalRooms[3].Amount = 29;
//            normalRooms[4].Amount = 43;
//        }
//    }
//}
