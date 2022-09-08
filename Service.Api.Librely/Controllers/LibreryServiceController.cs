using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Api.Librely.Core.Entities;
using Service.Api.Librely.Repository;

namespace Service.Api.Librely.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreryServiceController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public LibreryServiceController(IAutorRepository autorRepository)
        {
            this._autorRepository = autorRepository;
        }



        [HttpGet("authors")]
        public async Task<ActionResult<IEnumerable<Autor>>> Authors()
        {
            var authors = await _autorRepository.GetAuthors();
            return Ok(authors);
        }
    }
}
