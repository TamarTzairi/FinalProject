using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface IAlgorithmFunction
    {
        int[,] FillRoutesMatrix(Landmark landmark1, ProtectedSpaceRoom[] safeRoom, Class[] normalRooms);
        bool FinalyFunction(Class[] normalRooms, ProtectedSpaceRoom[] safeRoom, int i, int j);
        List<ResultDto> FinalyFunction(Node<Room>[,] nodes);
    }
}