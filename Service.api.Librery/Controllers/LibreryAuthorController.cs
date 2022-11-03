using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Api.Librery.Core.Entities;
using Service.Api.Librery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Api.Librery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreryAuthorController : ControllerBase
    {
        private readonly IMongoRepository<AutorEntity> _autormongoRepository;

        public LibreryAuthorController(IMongoRepository<AutorEntity> mongoRepository)
        {
            this._autormongoRepository = mongoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorEntity>>> Get()
        {
            var autores = await _autormongoRepository.GetAll();
            return Ok(autores);
        }
        
        // pagination
        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<AutorEntity>>> PostPagination(PaginationEntity<AutorEntity> pagination)
        {
            var result = await _autormongoRepository.paginationEntityByFilter(
                pagination
            );

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorEntity>> GetById(string id)
        {
            var autor = await _autormongoRepository.GetById(id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task Post(AutorEntity autor)
        {
            await _autormongoRepository.InsertDocument(autor);
        }
        
        [HttpPut("{id}")]
        public async Task Put(string id, AutorEntity autor)
        {
            autor.Id = id;
            await _autormongoRepository.UpdateDocument(autor);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _autormongoRepository.DeleteById(id);
        }

    }
}
