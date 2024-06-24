using FinalProject.DTO;
using Microsoft.VisualBasic;

namespace FinalProject.Interfaces
{
    public interface IDijkstra
    {
        (Dictionary<string, double> distances, Dictionary<string, string> previous) DijkstraAlgorithm(Node graph, string source);
    }
}