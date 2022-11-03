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
    public class LibreryBookController : ControllerBase
    {
        private readonly IMongoRepository<BookEntity> _bookRepository;

        public LibreryBookController(IMongoRepository<BookEntity> bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntity>>> Get()
        {
            var bookes = await _bookRepository.GetAll();
            return Ok(bookes);
        }

        // pagination
        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<BookEntity>>> PostPagination(PaginationEntity<BookEntity> pagination)
        {
            var result = await _bookRepository.paginationEntityByFilter(
                pagination
            );

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntity>> GetById(string id)
        {
            var book = await _bookRepository.GetById(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task Post(BookEntity book)
        {
            await _bookRepository.InsertDocument(book);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, BookEntity book)
        {
            book.Id = id;
            await _bookRepository.UpdateDocument(book);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _bookRepository.DeleteById(id);
        }


    }
}
