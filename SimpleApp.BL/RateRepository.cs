using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static SimpleApp.OpenratesResponse;

namespace SimpleApp.BL
{
    public class RateRepository
    {

        public static Positions getValueSet()
        {
            string url = @"http://openrates.in.ua/rates";
            var ratesString = new WebClient().DownloadString(url);
            var valueSet = JsonConvert.DeserializeObject<OpenratesResponse>(ratesString).Dollar;
            return valueSet;
        }

        static public Positions getUSD(string url)
        {
            var resultString = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<OpenratesResponse>(resultString).Dollar;
            return result;
        }

        static public Positions getUsdByDate(DateTime date)
        {
            StringBuilder url = new StringBuilder();
        url.Append(@"http://openrates.in.ua/rates?date=").
                Append(date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day);
            var result = getUSD(url.ToString());
            return result;
        }

        public static Dictionary<string, Positions> ReadJson()
        {
            string uri = @"http://openrates.in.ua/rates";
            var ratesString = new WebClient().DownloadString(uri);
            //var ratesString = File.ReadAllText("json.txt");
            var result = JsonConvert.DeserializeObject<Dictionary<string, Positions>>(ratesString);
            //var result = JsonConvert.DeserializeObject<OpenratesResponse>(ratesString);
            return result;
        }


        public static List<RateModel> Retrieve()
        {
            var data = ReadJson();

            var list = new List<RateModel>();
            foreach (KeyValuePair<string, Positions> pair in data)
            {
                RateModel rm = new RateModel
                    { CurrencyName = pair.Key,
                    BuyRate = pair.Value.interbankRateValues.Buy,
                    SellRate = pair.Value.interbankRateValues.Sell,
                    SellTrend = 0.02m,
                    BuyTrend = 0.02m,
                    CreationDate = DateTime.Now };
                list.Add(rm);
            }
            return list;
        }
}
}
