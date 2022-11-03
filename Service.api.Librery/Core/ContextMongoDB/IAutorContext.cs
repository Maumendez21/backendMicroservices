using MongoDB.Driver;
using Service.Api.Librery.Core.Entities;

namespace Service.Api.Librery.Core.ContextMongoDB
{
    public interface IAutorContext
    {

        IMongoCollection<Autor> Autores { get; }
    }
}
