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
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetAsync(object id);

        Task<List<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(object id);

    }
}
