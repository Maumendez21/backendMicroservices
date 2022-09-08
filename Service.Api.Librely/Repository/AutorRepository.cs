using MongoDB.Driver;
using Service.Api.Librely.Core.ContextMongoDB;
using Service.Api.Librely.Core.Entities;

namespace Service.Api.Librely.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IAutorContext _dbAutors;

        public AutorRepository(IAutorContext dbAutors)
        {
            this._dbAutors = dbAutors;
        }
        public async Task<IEnumerable<Autor>> GetAuthors()
        {
            return await _dbAutors.Autores.Find(prop => true).ToListAsync();
        }
    }
}
