using Core.Specifications;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Interface
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(int id);

        Task<T> GetByGuidAsync(Guid id);

        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec);
    }
}
