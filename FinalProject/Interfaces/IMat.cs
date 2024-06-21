using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IMat
    {
        (Dictionary<string, double>, Dictionary<string, string>)[] buildMat(Node startNode);
    }
}