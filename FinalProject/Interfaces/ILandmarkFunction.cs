using FinalProject.DTO;

namespace FinalProject.Interfaces
{

    public interface ILandmarkFunction
    {
        List<Landmark> Get();
        Landmark Get(string id);
        //Landmark Create(Landmark landmark);
        string Create(Landmark landmark);

        void Update(string id, Landmark landmark);
        void Remove(string id);
    }

}
