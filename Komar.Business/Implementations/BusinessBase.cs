using AutoMapper;
using Komar.DataAccess;
using Komar.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal abstract class BusinessBase<T> where T: class
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;
        protected readonly DbSet<T> Set;
        protected readonly string EntityName;

        protected BusinessBase(ApplicationDbContext context, IMapper mapper, string entityName)
        {
            Context = context;
            Mapper = mapper;
            Set = context.Set<T>();
            EntityName = entityName;
        }

        public async Task<R> AddAsync<R>(object obj)
        {
            var entity = Mapper.Map<T>(obj);
            Set.Add(entity);
            await Context.SaveChangesAsync();
            return Mapper.Map<R>(entity);
        }

        public async Task<R> UpdateAsync<R>(int id, object obj)
        {
            var entity = await FindAsync(id);
            Mapper.Map(obj, entity);
            await Context.SaveChangesAsync();
            return Mapper.Map<R>(entity);
        }

        public async Task RemoveAsync(T obj) {

            Context.Attach(obj);
            Context.Remove(obj);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await FindAsync(id);
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<R> FindAsync<R>(int id)
        {
            var entity = await FindAsync(id);
            return Mapper.Map<R>(entity);
        }

        public async Task<T> FindAsync(int id)
        {
            var entity = await Set.FindAsync(id);
            CheckNotFound(entity, id);
            return entity;
        }

        public void CheckNotFound(object obj, int id)
        {
            if(obj == null)
                throw new NotFoundException(EntityName, id);
        }
    }
}
