using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ManageCourses_ms.Domain.Models
{
    public class Cursos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonRequired]
        public int grado { get; set; }
        [BsonRequired]
        public string letra { get; set; }
        public IList<string> id_estudiante { get; set; } = new List<string>();
    }
}