using Service.Api.Librely.Core.Entities;

namespace Service.Api.Librely.Repository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAuthors();
    }
}
