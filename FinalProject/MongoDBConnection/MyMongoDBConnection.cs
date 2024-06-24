using FinalProject.DTO;
using MongoDB.Driver;
using System.Xml.Linq;

namespace FinalProject.MongoDBConnection
{
    public class MyMongoDBConnection
    {
        public class MongoDBContext
        {
            private readonly IMongoDatabase _database;

            public MongoDBContext()
            {
                string ConnectionString = "mongodb+srv://tamartz3112:<TZ3112TZ>@cluster0.ml3ivym.mongodb.net/?retryWrites=true&w=majority", DatabaseName = "Building";
                var client = new MongoClient(ConnectionString);
                _database = client.GetDatabase(DatabaseName);
            }

            public IMongoCollection<Landmark> LandmarkGraph => _database.GetCollection<Landmark>("Landmark");
            public IMongoCollection<Corridor> Corridor => _database.GetCollection<Corridor>("Corridor");
            public IMongoCollection<Class> Class => _database.GetCollection<Class>("Class");
            public IMongoCollection<ProtectedSpaceRoom> PSR => _database.GetCollection<ProtectedSpaceRoom>("ProtectedSpaceRoom");
            public IMongoCollection<Room> Room => _database.GetCollection<Room>("Room");
            
        }
    }
}
