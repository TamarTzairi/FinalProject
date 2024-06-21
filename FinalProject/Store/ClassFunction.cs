using FinalProject.DTO;
using FinalProject.Interfaces;
using MongoDB.Driver;

namespace FinalProject.Store
{
    public class ClassFunction:IClassFunction
    {

        private readonly IMongoCollection<Class> _class;
        public ClassFunction(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Building");
            _class = database.GetCollection<Class>("Class");
        }
        public Class Create(Class classs)
        {
            _class.InsertOne(classs);
            return classs;
        }
        public List<Class> Get()
        {
            return _class.Find(classs => true).ToList();
        }
        public Class Get(string id)
        {
            return _class.Find(classs => classs.ClassId == id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _class.DeleteOne(classs => classs.ClassId == id);
        }
        public void Update(string id, Class classs)
        {
            _class.ReplaceOne(classs => classs.ClassId == id, classs);
        }
    }
}



