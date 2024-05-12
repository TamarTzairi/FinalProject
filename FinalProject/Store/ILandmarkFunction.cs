using FinalProject.DTO;

namespace FinalProject.Store
{

    public interface ILandmarkFunction
    {
        List<Landmark> Get();
        Landmark Get(string id);
        Landmark Create(Landmark landmark);
        void Update(string id, Landmark landmark);
        void Remove(string id);
    }

}
