using System;
using System.Json;
using System.Net;
using System.Text;

namespace KaraMakerTools
{
    class SheetFetcher : ISheetFetcher
    {
        public IConfig Config { get; }

        public SheetFetcher(IConfig config)
        {
            Config = config;
        }

        private static string GetUrl(string key, string sheet)
        {
            sheet = WebUtility.UrlEncode(sheet);
            return $"https://docs.google.com/spreadsheets/d/{key}/gviz/tq?tqx=out:json&sheet={sheet}";
        }

        public string GetSheetJson(string sheet)
        {
            var client = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            var url = GetUrl(Config.GoogleSheetsKey, sheet);
            var str = client.DownloadString(url);
            var first = str.IndexOf("{", StringComparison.Ordinal);
            var last = str.LastIndexOf("}", StringComparison.Ordinal);
            var json = str.Substring(first, last - first + 1);
            return json;
        }
    }
}
