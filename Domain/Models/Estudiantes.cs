using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ManageCourses_ms.Resources;

namespace ManageCourses_ms.Domain.Models
{
    public class Estudiantes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string id_estudiante { get; set; }
        public string id_curso { get; set; }
        public CursoNoIdResource curso { get; set; }
    }
}