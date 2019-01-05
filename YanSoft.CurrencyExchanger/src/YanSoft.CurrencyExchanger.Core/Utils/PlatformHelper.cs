using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace YanSoft.CurrencyExchanger.Core.Utils
{
    public static class PlatformHelper
    {
        public static string GetDbFilePath(string databaseName)
        {
            var databasePath = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    //iOS complains on startup, if you don’t add the following line.
                    //I add it just before the Xamarin.Forms.Init(), in the AppDelegate.cs
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                case Device.UWP:
                    //databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DatabaseName);
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseName);

                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            return databasePath;
        }

        public static string GetImagePath(string fileName)
        {
            var filePath = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    filePath = fileName;
                    break;
                case Device.Android:
                    filePath = fileName;
                    break;
                case Device.UWP:
                    filePath = $"Assets/images/{fileName}";
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            return filePath;
        }
    }
}
