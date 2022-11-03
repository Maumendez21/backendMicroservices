using Service.Api.Librery.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Api.Librery.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAuthors();
    }
}
