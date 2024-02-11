using Application.Interface;
using Core.Specifications;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly DatabaseContext Context;

        public RepositoryAsync(DatabaseContext databaseContext)
        {
            Context = databaseContext;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            Context.Set<T>().Remove(entity);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByGuidAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return await Context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(Context.Set<T>().AsQueryable(), spec);
        }



        private List<T> ConvertToObjectList<T>(DbDataReader reader)
        {
            var result = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = reader.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        if (colMapping.ContainsKey(prop.Name.ToLower()) && colMapping[prop.Name.ToLower()].ColumnOrdinal != null)
                        {
                            var val = reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                            prop.SetValue(obj, val == DBNull.Value ? null : val);
                        }
                    }
                    result.Add(obj);
                }
            }
            return result;
        }
    }
}
