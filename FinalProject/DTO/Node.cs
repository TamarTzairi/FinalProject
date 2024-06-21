﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject.DTO
{
    public class Node
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string NodeId { get; set; }//id

        [BsonElement]
        public Room Data { get; set; }//מידע - דאטא

        [BsonElement]
        public string type { get; set; } = string.Empty;//סוג
        [BsonElement]
        public int indexMat { get; set; } = Global.Global.count;//מיקום במטריצת המסלולים
        [BsonElement]
        public Node Previous { get; set; }//הקודם
        [BsonElement]
        public List<Edge> Neighbors { get; set; } = new List<Edge>();// שכנים

        public Node(Room data)
        {
            Data = data;
        }


        //[BsonElement]
        //public double Weight { get; set; }//משקל

        //public Node(string nodeId, double weight)
        //{
        //    NodeId = nodeId;
        //    Weight = weight;
        //}


        //public void AddEdge(string id, double weight)
        //{
        //    Neighbors.Add(new Neighbor(id, weight));
        //}
    }

}
