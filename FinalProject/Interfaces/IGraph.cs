using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IGraph
    {
        Node buildGraph(Landmark landmark);
        double WeightCalculation(Room room1, Room room2);
        double WeightCalculation2(double x1, double x2, double y1, double y2)

    }
}