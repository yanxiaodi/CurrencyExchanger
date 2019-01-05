using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Utils;

namespace YanSoft.CurrencyExchanger.Core.Data
{
    public class CurrencyDataContext : DbContext
    {
        public DbSet<CurrencyExchangeItem> CurrencyExchangeItems { get; set; }
        private const string DatabaseName = "sqlite.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=sqlite.db");
            var databasePath = PlatformHelper.GetDbFilePath(DatabaseName);
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyExchangeItem>(
                c =>
                {
                    //c.Ignore(x => x.SourceCurrency);
                    //c.Ignore(x => x.TargetCurrency);
                    c.HasKey(x => x.Id);
                });
        }


    }
}
