using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    public class Edge<T>
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("source")]
        public Node<T> Source { get; set; }//מקור

        [BsonElement("target")]
        public Node<T> Target { get; set; }//יעד

        [BsonElement("weight")]
        public double Weight { get; set; }//משקל

        public Edge(Node<T> source, Node<T> target, double weight)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }
    }
}
