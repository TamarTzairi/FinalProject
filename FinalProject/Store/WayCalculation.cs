using FinalProject.DTO;

namespace FinalProject.Store
{
    public class WayCalculation
    {
        public double Calculation(Room room1, Room room2,Node graph)
        {
            double num=0;
            Node nodeSource;
            Node nodeTarget;
            foreach (var item in graph.Neighbors)
            {
                //item.nodeNeighbor.Neighbors.Find();
                foreach (var item1 in item.nodeNeighbor.Neighbors)
                {

                    if (item1.nodeNeighbor.NodeId==room1.RoomId)
                    {
                        

                    }
                }
            }

            return num;
        }
    }
}
