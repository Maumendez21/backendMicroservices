using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Api.Librery.Core.Entities
{
    [BsonCollection("Autor")]
    public class AutorEntity : Document
    {
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("lastname")]
        public string lastname { get; set; }
        [BsonElement("degreeAcademic")]
        public string degreeAcademic { get; set; }

        [BsonElement("nameComplet")]
        public string nameComplet { get; set; }
    }
}
