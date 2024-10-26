using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.contracts;
using persistence.data;
namespace persistence.repositories
{
    internal class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
    {
        private readonly Storecontext _storecontext;
        public GenericRepository(Storecontext storecontext)
        {
            _storecontext = storecontext;
        }
        public async Task AddAsync(TEntity entity) => await _storecontext.Set<TEntity>().AddAsync(entity);
       

        public void Delete(TEntity entity)=> _storecontext.Set<TEntity>().Remove(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange)
      => trackchange ? await _storecontext.Set<TEntity>().ToListAsync()
            : await _storecontext.Set<TEntity>().AsNoTracking().ToListAsync();
        public  async Task<TEntity?> GetAsync(Tkey id)

         => await _storecontext.Set<TEntity>().FindAsync(id);
        public void Update(TEntity entity) => _storecontext.Set<TEntity>().Update(entity);

    }
}
