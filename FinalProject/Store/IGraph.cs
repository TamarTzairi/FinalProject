using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface IGraph
    {
        string buildGraph(Landmark landmark);
        double WeightCalculation(Room room1, Room room2);
    }
}