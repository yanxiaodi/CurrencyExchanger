using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    interface IDataService<TEntity> where TEntity : class, new()
    {
        Task InitializeDatabaseAsync();
        Task<bool> AddAsync(TEntity entity);

        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetAsync(object id);
        Task<IEnumerable<TEntity>> QueryAsync(Func<TEntity, bool> predicate);

        Task<List<TEntity>> GetAllAsync();

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(object id);

    }
}
