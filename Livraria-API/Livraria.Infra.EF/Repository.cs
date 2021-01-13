using Livraria.Infra.Data;
using Livraria.Infra.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.EF
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {

        protected DataContext Context { get; }

        protected Repository(DataContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByAsync(int id)
        {
            var entity = Context.Set<T>().Local.SingleOrDefault(x => x.Id == id);

            if (entity.IsNull())
            {
                entity = await Context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            }

            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
