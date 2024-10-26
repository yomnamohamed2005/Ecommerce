using persistence.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using domain.contracts;
namespace persistence.repositories
{

    internal class Unitofwork
    {
        private readonly Storecontext _storecontext;
        private readonly ConcurrentDictionary <string, object> _repostories;
        public Unitofwork (Storecontext storecontext)
        {
            _storecontext = storecontext;
            _repostories = new();

        }
        public async Task<int> SavechangesAsync() => await _storecontext.SaveChangesAsync();
        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
            => (IGenericRepository<TEntity, Tkey>)
            _repostories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, Tkey>(_storecontext));
    }
}
