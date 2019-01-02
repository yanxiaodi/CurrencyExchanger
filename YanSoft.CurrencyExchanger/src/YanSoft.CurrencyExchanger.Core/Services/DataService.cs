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

        public async Task InsertAsync(CurrencyExchangeItem entity)
        {
            using (var db = new CurrencyDataContext())
            {
                await db.CurrencyExchangeItems.AddAsync(entity);
                await db.SaveChangesAsync();
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
