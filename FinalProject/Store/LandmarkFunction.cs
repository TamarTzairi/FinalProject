    using FinalProject.Controllers;
using FinalProject.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FinalProject.Store
{
    public class LandmarkFunction : ILandmarkFunction
    {
        private readonly IMongoCollection<Landmark> _landmark;
        public LandmarkFunction(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Building");
            _landmark = database.GetCollection<Landmark>("Landmark");
        }
        public Landmark Create(Landmark landmark)
        {
            _landmark.InsertOne(landmark);
            return landmark;
        }
        public List<Landmark> Get()
        {
            return _landmark.Find(landmark => true).ToList();
        }
        public Landmark Get(string id)
        {
            return _landmark.Find(landmark => landmark.LandmarkId == id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _landmark.DeleteOne(landmark => landmark.LandmarkId == id);
        }
        public void Update(string id, Landmark landmark)
        {
            _landmark.ReplaceOne(landmark => landmark.LandmarkId == id, landmark);
        }
    }
}
