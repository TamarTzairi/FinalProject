using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    //חדר
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }
        [BsonElement("x")]
        public double X { get; set; }
        [BsonElement("y")]
        public double Y { get; set; }
        [BsonElement("Amount")]
        public int Amount { get; set; }

    }
}
