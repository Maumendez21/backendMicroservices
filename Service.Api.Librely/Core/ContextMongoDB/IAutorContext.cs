using MongoDB.Driver;
using Service.Api.Librely.Core.Entities;

namespace Service.Api.Librely.Core.ContextMongoDB
{
    public interface IAutorContext
    {

        IMongoCollection<Autor> Autores { get; }
    }
}
