using FinalProject.DTO;

namespace FinalProject.Interfaces
{
    public interface IRoomFunction
    {
        List<Room> Get();
        Room Get(string id);
        Room Create(Room room);
        void Update(string id, Room room);
        void Remove(string id);
    }

}
