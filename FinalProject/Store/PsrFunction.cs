using FinalProject.DTO;
using MongoDB.Driver;

namespace FinalProject.Store
{
    public class PsrFunction
    {

        private readonly IMongoCollection<ProtectedSpaceRoom> _psr;
        public PsrFunction(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Building");
            _psr = database.GetCollection<ProtectedSpaceRoom>("ProtectedSpaceRoom");
        }
        public ProtectedSpaceRoom Create(ProtectedSpaceRoom psr)
        {
            _psr.InsertOne(psr);
            return psr;
        }
        public List<ProtectedSpaceRoom> Get()
        {
            return _psr.Find(psr => true).ToList();
        }
        public ProtectedSpaceRoom Get(string id)
        {
            return _psr.Find(psr => psr.PsrId == id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _psr.DeleteOne(psr => psr.PsrId == id);
        }
        public void Update(string id, ProtectedSpaceRoom psr)
        {
            _psr.ReplaceOne(psr => psr.PsrId == id, psr);
        }

    }
}



