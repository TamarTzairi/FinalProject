﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject.DTO
{
    //חדר רגיל
    public class Class
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClassId { get; set; }
        public Room ClassRoom { get; set; }
    }
}
