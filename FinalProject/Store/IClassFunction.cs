using FinalProject.DTO;

namespace FinalProject.Store
{
    public interface IClassFunction
    {
        List<Class> Get();
        Class Get(string id);
        Class Create(Class classs);
        void Update(string id, Class classs);
        void Remove(string id);
    }
}
