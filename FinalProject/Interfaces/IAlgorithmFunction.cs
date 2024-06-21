using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IAlgorithmFunction
    {
        // int[,] FillRoutesMatrix(Landmark landmark1, ProtectedSpaceRoom[] safeRoom, Class[] normalRooms);
        List<ResultDto> FinalyFunction(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j);
        // List<ResultDto> FinalyFunction(Node<Room>[,] nodes);
    }
}