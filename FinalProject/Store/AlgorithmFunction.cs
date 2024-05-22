using FinalProject.DTO;
using System.IO;
namespace FinalProject.Store
{
    public class AlgorithmFunction : IAlgorithmFunction
    {
        int i, j = 0;
        public bool FinalyFunction(Class[] normalRooms, ProtectedSpaceRoom[] safeRoom, int i, int j)
        {
            if (j > normalRooms.Length)
            {
                return false;//כשל
            }

            if (normalRooms[i].ClassRoom.Amount <= safeRoom[j].PsrRoom.Amount)
            {
                i++;
                safeRoom[j].PsrRoom.Amount -= normalRooms[i].ClassRoom.Amount;

            }
            else
            {
                j++;
            }
            FinalyFunction(normalRooms, safeRoom, i, j);
            return true;
        }

        public int[,] FillRoutesMatrix(Landmark landmark1, ProtectedSpaceRoom[] safeRoom, Class[] normalRooms)
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
        }
        public static void Main(string[] args)
        {
            ProtectedSpaceRoom[] safeRoom = new ProtectedSpaceRoom[5];
            Class[] normalRooms = new Class[5];

        }
    }
}
