using FinalProject.DTO;

namespace FinalProject.Store
{
    public class WayCalculation
    {
        public double Calculation(Room room1, Room room2, Node graph)
        {
            double num = 0;
            Node nodeSource =null;
            Node nodeTarget=null;
            Node nextCorridor;

            //מציאת שתי החדרים בגרף
            foreach (var item in graph.Neighbors)
            {
                nodeSource = item.nodeNeighbor.Neighbors.Find(x => x.nodeNeighbor.NodeId == room1.RoomId).nodeNeighbor;
                nodeTarget = item.nodeNeighbor.Neighbors.Find(x => x.nodeNeighbor.NodeId == room2.RoomId).nodeNeighbor;
            }

           
            foreach (var item in nodeSource.Previous.Neighbors)
            {
                //אם שתי החדרים הם באותו מסדרון
                if (item.nodeNeighbor.NodeId == nodeTarget.NodeId)
                {
                    num = WeightCalculation(item.nodeNeighbor.Data.Y, nodeTarget.Data.Y, item.nodeNeighbor.Data.X, nodeTarget.Data.X);
                    num += WeightCalculation(item.nodeNeighbor.Data.Y, nodeSource.Data.Y, item.nodeNeighbor.Data.X, nodeSource.Data.X);
                    return num;
                }
                else
                {
                    //אם יש סה"כ שתי מסדרונות ולא יותר  
                    if (item.nodeNeighbor.NodeId==nodeTarget.Previous.NodeId)
                    {
                        num = WeightCalculation(item.nodeNeighbor.Data.Y, nodeSource.Data.Y, item.nodeNeighbor.Data.X, nodeSource.Data.X);
                        num += WeightCalculation(nodeTarget.Data.X, nodeTarget.Previous.Data.X, nodeTarget.Data.Y, nodeTarget.Previous.Data.Y);
                        num += item.nodeNeighbor.Data.Amount + nodeTarget.Previous.Data.Amount;
                        return num;
                    }
                }  
               
            }
            


            


            return num;
        }
        public double WeightCalculation(double x1, double x2, double y1, double y2)
        {
            double weight = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return weight;
        }
    }
}
