using MongoDB.Driver;
using Service.Api.Librery.Core.ContextMongoDB;
using Service.Api.Librery.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Api.Librery.Repository
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
