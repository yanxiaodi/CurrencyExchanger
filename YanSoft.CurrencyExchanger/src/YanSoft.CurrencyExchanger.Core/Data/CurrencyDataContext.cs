using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using YanSoft.CurrencyExchanger.Core.Models;

namespace YanSoft.CurrencyExchanger.Core.Data
{
    public class CurrencyDataContext : DbContext
    {
        public DbSet<CurrencyExchangeItem> CurrencyExchangeItems { get; set; }
        private const string DatabaseName = "sqlite.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=sqlite.db");
            string databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    //iOS complains on startup, if you don’t add the following line.
                    //I add it just before the Xamarin.Forms.Init(), in the AppDelegate.cs
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;
                case Device.UWP:
                    //databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DatabaseName);
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseName);

                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
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
