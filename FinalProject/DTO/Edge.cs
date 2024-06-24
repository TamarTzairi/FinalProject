using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    public class Edge
    {       
        [BsonElement("nodeNeighbor")]
        public Node nodeNeighbor { get; set; }//הנוד עצמו ולא רק השכן
        [BsonElement("weight")]
        public double Weight { get; set; }//משקל
        public Edge( Node NodeNeighbor, double weight)
        {         
            nodeNeighbor = NodeNeighbor;
            Weight = weight; 
        }
    }
}
