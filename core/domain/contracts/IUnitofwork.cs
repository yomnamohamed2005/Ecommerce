using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.entities;
namespace domain.contracts
{
    public  interface IUnitofwork
    {
        public Task<int> SavechangesAsync();
        IGenericRepository<TEntity, Tkey>GetRepository<TEntity, Tkey> ()where TEntity : BaseEntity<Tkey> ;
    } 
}
