using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    //חדר מרחב מוגן - ממ"ד
    public class ProtectedSpaceRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PsrId { get; set; }
        public Room PsrRoom { get; set; }
        
    }
}
