using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FinalProject.DTO
{
    //נקודת ציון
    //IdLandmarkRoom הראשון זה מאיזה סוג והשני זה איפה הוא נמצא
    [BsonIgnoreExtraElements]
    public class Landmark
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LandmarkId { get; set; }
        public List<Corridor> Corridors { get; set; }=new List<Corridor>();
    }
}
