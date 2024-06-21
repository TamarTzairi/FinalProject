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

        [BsonElement("StartPointX")]
        public double StartPointX { get; set; }
        [BsonElement("StartPointY")]
        public double StartPointY { get; set; }
        [BsonElement("EndPointX")]
        public double EndPointX { get; set; }
        [BsonElement("EndPointY")]
        public double EndPointY { get; set; }
        public int Floor { get; set; }
        public Room CorridorLandmark { get; set; }//כדי שהמסדרון יהיה עם נקודת ציון
        public List<Class> ClassList { get; set; }=new List<Class>();
        public List<ProtectedSpaceRoom> ProtectedSpaceRoomList { get; set; } = new List<ProtectedSpaceRoom>(); 

        //public List<ProtectedSpaceRoom> ProtectedSpaceRoomList { get;} = new List<ProtectedSpaceRoom>();
    }
}
