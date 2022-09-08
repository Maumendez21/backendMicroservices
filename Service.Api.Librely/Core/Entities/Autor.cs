using MongoDB.Bson.Serialization.Attributes;

namespace Service.Api.Librely.Core.Entities
{
    public class Autor
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? id { get; set; }

        [BsonElement("name")]
        public string? name { get; set; }
        
        [BsonElement("lastname")]
        public string? lastname { get; set; }

        [BsonElement("degreeAcademic")]
        public string? degreeAcademic { get; set; }
    }
}
