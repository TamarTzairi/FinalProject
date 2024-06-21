using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    public class Edge
    {
        //[BsonRepresentation(BsonType.ObjectId)]
       // [BsonElement("source")]
       // public Node Source { get; set; }//מקור

        [BsonElement("target")]
        public Node nodeNeighbor { get; set; }//הנוד עצמו ולא רק השכן

        [BsonElement("weight")]
        public double Weight { get; set; }//משקל

        public Edge(/*Node source,*/ Node NodeNeighbor, double weight)
        {
            //Source = source;
            nodeNeighbor = NodeNeighbor;
            Weight = weight; 
        }
    }
}
//---------------------------------------------אין-צורך----------------------------------------------