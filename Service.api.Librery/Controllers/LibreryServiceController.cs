using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Api.Librery.Core.Entities;
using Service.Api.Librery.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Api.Librery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreryServiceController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMongoRepository<AutorEntity> _autorGenericRepository;

        public LibreryServiceController(IAutorRepository autorRepository, IMongoRepository<AutorEntity> autorGenericRepository)
        {
            this._autorRepository = autorRepository;
            this._autorGenericRepository = autorGenericRepository;
        }



        [HttpGet("authors")]
        public async Task<ActionResult<IEnumerable<Autor>>> Authors()
        {
            var authors = await _autorRepository.GetAuthors();
            return Ok(authors);
        }
        
        
        [HttpGet("authors2")]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Authors2()
        {
            var authors = await _autorGenericRepository.GetAll();
            return Ok(authors);
        }
    }
}
