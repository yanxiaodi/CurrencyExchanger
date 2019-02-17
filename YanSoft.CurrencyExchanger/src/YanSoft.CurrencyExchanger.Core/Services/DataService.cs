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
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    db.Database.EnsureCreated();
                    // Add some default currencies for the first time.
                    var count = await db.CurrencyExchangeItems.CountAsync();
                    if (count == 0)
                    {
                        var targetCodes = new List<string> { "USD", "CNY", "NZD", "AUD" };
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
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
            }
        }

        public async Task<bool> AddAsync(CurrencyExchangeItem entity)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    var tracking = await db.CurrencyExchangeItems.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return tracking.State == EntityState.Added;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<CurrencyExchangeItem> entities)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    await db.CurrencyExchangeItems.AddRangeAsync(entities);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return false;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    var item = await db.CurrencyExchangeItems.FindAsync((Guid)id);
                    if (item != null)
                    {
                        var tracking = db.CurrencyExchangeItems.Remove(item);
                        await db.SaveChangesAsync();
                        return tracking.State == EntityState.Deleted;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return false;
            }
        }

        public async Task<List<CurrencyExchangeItem>> GetAllAsync()
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    return await db.CurrencyExchangeItems.OrderBy(x => x.SortOrder).ToListAsync();
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return null;
            }
        }

        public async Task<CurrencyExchangeItem> GetAsync(object id)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    return await db.CurrencyExchangeItems.FindAsync((Guid)id);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return null;
            }
        }

        public async Task<IEnumerable<CurrencyExchangeItem>> QueryAsync(Func<CurrencyExchangeItem, bool> predicate)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    return await db.CurrencyExchangeItems.Where(predicate).AsQueryable().ToListAsync();
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return null;
            }
        }

        public async Task<bool> UpdateAsync(CurrencyExchangeItem entity)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    var tracking = db.CurrencyExchangeItems.Update(entity);
                    await db.SaveChangesAsync();
                    return tracking.State == EntityState.Modified;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return false;
            }
        }

        public async Task<bool> UpdateRangeAsync(IEnumerable<CurrencyExchangeItem> entities)
        {
            try
            {
                using (var db = new CurrencyDataContext())
                {
                    db.CurrencyExchangeItems.UpdateRange(entities);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(e);
#endif
                return false;
            }
        }
    }
}
