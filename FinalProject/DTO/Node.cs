using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject.DTO
{
    public class Node<T>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string NodeId { get; set; }

        [BsonElement]
        public Room Data { get; set; }//מידע - דאטא
        [BsonElement]
        public List<Edge<T>> Edges { get; set; } = new List<Edge<T>>();//קשתות שכנות

        public Node(Room data)
        {
            Data = data;
        }

        public void AddEdge(Node<T> target, double weight)
        {
            Edges.Add(new Edge<T>(this, target, weight));
        }
    }

}
