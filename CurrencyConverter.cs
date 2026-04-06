// api docs: https://github.com/fawazahmed0/exchange-api
// use curl to test in terminal and do not pip it, it will break your system again

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace ileapy
{
    internal class CurrencyConverter
    {
        public CurrencyConverter() { }
        public static double CoinDiff(string from, string to)
        {
            string url ="https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies/"+from+".json";
            //Console.WriteLine(url);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    string[] data = content.Split(new char[] { ':', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
                        .Select(item => item.Trim())
                        .ToArray();
                    var match = data.Select((item, index) => new { item, index })
                            .FirstOrDefault(x => x.item.Contains("\"" + to + "\""));
                    if (match != null)
                    {
                        int index = match.index;
                        try
                        {
                            return Convert.ToDouble(data[index + 1]);
                        }
                        catch {
                            return -1;
                        }
                    }
                    throw new ArgumentException("Wrong conversion rate");
                }
            }
            throw new ArgumentException("failed to fetch the api");
        }
        public static string LoadCurrencys()
        {
            string url = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies.json";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage respsons = client.GetAsync(url).Result;
                if (respsons.IsSuccessStatusCode)
                {
                    return respsons.Content.ReadAsStringAsync().Result;
                }
            }
            throw new ArgumentException("failed to fetch the api");
        }
    }
}
