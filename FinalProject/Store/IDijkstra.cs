using FinalProject.DTO;
using Microsoft.VisualBasic;

namespace FinalProject.Store
{
    public interface IDijkstra
    {
        SortedSet<(double Distance, string NodeId)> InitailGraph(Landmark landmark, string startId);
    }
}