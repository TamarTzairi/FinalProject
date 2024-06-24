using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IAlgorithmFunction
    {
        List<ResultDto> FinalyFunction(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat, int i, int j, double time, Landmark l);
        bool IsCan(List<Room> normalRooms, List<Room> safeRoom, (Dictionary<string, double>, Dictionary<string, string>)[] mat ,int i, int j, Landmark l);

    }
}