using MagicVilla_VillaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
       public interface IVillaRepository : IRepository<Villa>
       {
      
           Task<Villa> UpdateAsync(Villa entity);
        
       }
}
