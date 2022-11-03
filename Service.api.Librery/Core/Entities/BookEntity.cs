using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Api.Librery.Core.Entities
{
    [BsonCollection("Book")]
    public class BookEntity : Document
    {
        [BsonElement("title")]
        public string Title { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonElement("price")]
        public int Price { get; set; }
        
        [BsonElement("publicationDate")]
        public DateTime? PublicationDate { get; set; }

        [BsonElement("autor")]
        public AutorEntity Autor { get; set; }



    }
}
