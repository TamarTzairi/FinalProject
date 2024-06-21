using FinalProject.DTO;
using FinalProject.Interfaces;
using MongoDB.Driver;

namespace FinalProject.Store
{
    public class CorridorFunction:ICorridorFunction
    {
        private readonly IMongoCollection<Corridor> _corridor;
        public CorridorFunction(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Building");
            _corridor = database.GetCollection<Corridor>("Corridor");
        }
        public Corridor Create(Corridor corridor)
        {
            _corridor.InsertOne(corridor);
            return corridor;
        }
        public List<Corridor> Get()
        {
            return _corridor.Find(corridor => true).ToList();
        }
        public Corridor Get(string id)
        {
            return _corridor.Find(corridor => corridor.CorridorId == id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _corridor.DeleteOne(corridor => corridor.CorridorId == id);
        }
        public void Update(string id, Corridor corridor)
        {
            _corridor.ReplaceOne(corridor => corridor.CorridorId == id, corridor);
        }
    }
}
