using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    //מסדרון
    public class Corridor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CorridorId { get; set; }
        [BsonElement("StartPoint")]
        public int StartPoint { get; set; }
        [BsonElement("EndPoint")]
        public int EndPoint { get; set; }
        public int Floor { get; set; }
        public Room CorridorLandmark { get; set; }
        public List<Class> ClassList { get; set; }=new List<Class>();
        public List<ProtectedSpaceRoom> ProtectedSpaceRoomList { get; set; } = new List<ProtectedSpaceRoom>(); 

        //public List<ProtectedSpaceRoom> ProtectedSpaceRoomList { get;} = new List<ProtectedSpaceRoom>();
    }
}
