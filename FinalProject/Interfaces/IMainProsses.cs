using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IMainProsses
    {
         List<ResultDto> FuncRun(string id,double time);
    }
}
