using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FinalProject.DTO
{
    public class Landmark
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LandmarkId { get; set; }
        [BsonElement]
        public List<Corridor> Corridors { get; set; }=new List<Corridor>();
    }
}
