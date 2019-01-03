using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Data;
using YanSoft.CurrencyExchanger.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace YanSoft.CurrencyExchanger.Core.Services
{
    public class DataService : IDataService<CurrencyExchangeItem>
    {
        public async Task InitializeDatabaseAsync()
        {
            using (var db = new CurrencyDataContext())
            {
                db.Database.EnsureCreated();
                // Add some default currencies for the first time.
                var count = await db.CurrencyExchangeItems.CountAsync();
                if(count == 0)
                {
                    var targetCodes = new List<string> { "USD", "EUR", "CNY", "NZD" };
                    var targets = new List<CurrencyExchangeItem>();
                    targetCodes.ForEach(x =>
                    {
                        var item = new CurrencyExchangeItem(new CurrencyItem { Code = "USD" }, new CurrencyItem { Code = x }, ++count);
                        targets.Add(item);
                    });
                    await db.CurrencyExchangeItems.AddRangeAsync(targets);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task AddAsync(CurrencyExchangeItem entity)
        {
            using (var db = new CurrencyDataContext())
            {
                await db.CurrencyExchangeItems.AddAsync(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<CurrencyExchangeItem> entities)
        {
            using (var db = new CurrencyDataContext())
            {
                await db.CurrencyExchangeItems.AddRangeAsync(entities);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(object id)
        {
            using (var db = new CurrencyDataContext())
            {
                var item = await db.CurrencyExchangeItems.SingleOrDefaultAsync(x => x.Id == (Guid)id);
                if (item != null)
                {
                    db.CurrencyExchangeItems.Remove(item);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<List<CurrencyExchangeItem>> GetAllAsync()
        {
            using (var db = new CurrencyDataContext())
            {
                return await db.CurrencyExchangeItems.ToListAsync();
            }
        }

        public async Task<CurrencyExchangeItem> GetAsync(object id)
        {
            using (var db = new CurrencyDataContext())
            {
                return await db.CurrencyExchangeItems.SingleOrDefaultAsync(x => x.Id == (Guid)id);
            }
        }

        public async Task UpdateAsync(CurrencyExchangeItem entity)
        {
            using (var db = new CurrencyDataContext())
            {
                db.CurrencyExchangeItems.Update(entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
