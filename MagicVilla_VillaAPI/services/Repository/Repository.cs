using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter = null, bool Tracked = true)
        {
            IQueryable<T> Query = dbSet;

            if (!Tracked)
            {
                Query = Query.AsNoTracking();
            }
            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }

            return await Query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? Filter = null)
        {
            IQueryable<T> Query =dbSet;

            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }
            return await Query.ToListAsync();
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    _db.VillaDb.Update(entity);
        //    await SaveAsync();
        //}


        public async Task RemoveAsync(T entity)
        {
           dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
