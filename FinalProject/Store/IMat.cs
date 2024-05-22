using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface IMat
    {
        Node<Room>[,] buildMat(SortedSet<(double Distance, string NodeId)> priorityQueue);
    }
}