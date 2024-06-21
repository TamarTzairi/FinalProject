using FinalProject.DTO;
using FinalProject.Interfaces;
using MongoDB.Driver;

namespace FinalProject.Store
{
    public class RoomFunction:IRoomFunction
    {

        private readonly IMongoCollection<Room> _room;
        public RoomFunction(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Building");
            _room = database.GetCollection<Room>("room");
        }
        public Room Create(Room room)
        {
            _room.InsertOne(room);
            return room;
        }
        public List<Room> Get()
        {
            return _room.Find(room => true).ToList();
        }
        public Room Get(string id)
        {
            return _room.Find(room => room.RoomId == id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _room.DeleteOne(room => room.RoomId == id);
        }
        public void Update(string id, Room room)
        {
            _room.ReplaceOne(room => room.RoomId == id, room);
        }

    }
}
