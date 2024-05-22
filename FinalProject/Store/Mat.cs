using FinalProject.DTO;
using System.Numerics;

namespace FinalProject.Store
{
    public class Mat : IMat
    {
        public Node<Room>[,] buildMat(SortedSet<(double Distance, string NodeId)> priorityQueue)
        {
            var Matrix = new Node<Room>[10, 10];
            return Matrix;
        }
    }
}
