using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ManageCourses_ms.Resources
{
    public class CursosResource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int grado { get; set; }
        public string letra { get; set; }
    }
}