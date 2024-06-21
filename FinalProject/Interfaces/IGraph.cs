using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IGraph
    {
        Node buildGraph(Landmark landmark);
        double WeightCalculation(Room room1, Room room2);
    }
}