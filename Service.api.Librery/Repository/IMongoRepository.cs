using Service.Api.Librery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Api.Librery.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {

        Task<IEnumerable<TDocument>> GetAll();
        Task<TDocument> GetById(string Id);
        Task InsertDocument(TDocument document);
        Task UpdateDocument(TDocument document);
        Task DeleteById(string Id);
        Task<PaginationEntity<TDocument>> paginationEntityBy(
            Expression<Func<TDocument,bool>> filterExpression,
            PaginationEntity<TDocument> pagination
        );

        Task<PaginationEntity<TDocument>> paginationEntityByFilter(
            PaginationEntity<TDocument> pagination
        );



    }
}
