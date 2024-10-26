using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace domain.contracts
{
  public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<TEntity?> GetAsync(Tkey key);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange);
        Task AddAsync(TEntity entity);
       void Update(TEntity entity);
     void Delete(TEntity entity);
    }
}
