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
    public class VillaRepository : Repository<Villa>,IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db; 
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.VillaDb.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }


        //public async Task CreateAsync(Villa entity)
        //{
        //   await _db.VillaDb.AddAsync(entity);
        //    await SaveAsync();
        //}

        //public async Task<Villa> GetAsync(Expression<Func<Villa,bool>> Filter = null, bool Tracked = true)
        //{
        //    IQueryable<Villa> Query = _db.VillaDb;

        //    if (!Tracked)
        //    {
        //        Query = Query.AsNoTracking();
        //    }
        //    if (Filter != null)
        //    {
        //        Query = Query.Where(Filter);
        //    }

        //    return await Query.FirstOrDefaultAsync();
        //}

        //public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa,bool>> Filter = null)
        //{
        //    IQueryable<Villa> Query = _db.VillaDb;

        //    if (Filter != null)
        //    {
        //        Query = Query.Where(Filter);
        //    }
        //    return await Query.ToListAsync();
        //}


        //public async Task RemoveAsync(Villa entity)
        //{
        //    _db.VillaDb.Remove(entity);
        //    await SaveAsync();
        //}

        //public async Task SaveAsync()
        //{
        //   await _db.SaveChangesAsync();
        //}


    }
}
