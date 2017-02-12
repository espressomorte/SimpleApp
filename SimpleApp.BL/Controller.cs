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
    public class Controller
    {
        Repository repo = new Repository();

        public static Positions getValueSet()
        {
            string url = @"http://openrates.in.ua/rates";
            var ratesString = new WebClient().DownloadString(url);
            var valueSet = JsonConvert.DeserializeObject<OpenratesResponse>(ratesString).Dollar;
            return valueSet;
        }


        private List<RateModel> getRatesByDate(DateTime date)
        {
            StringBuilder url = new StringBuilder();
            url.Append(@"http://openrates.in.ua/rates?date=").
                    Append(date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day);
            return ResponseToModel(ReadJson(url.ToString()));
        }

        public void UpdateTrends()
        {
            RetrieveLastDay();
        }

        public Dictionary<string, Positions> ReadJson()
        {
            string url = @"http://openrates.in.ua/rates";
            return ReadJson(url);
        }

        private Dictionary<string,Positions> ReadJson(string url)
        {
            var ratesString = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<Dictionary<string, Positions>>(ratesString);
            return result;
        }

        private void RetrieveLastDay()
        {
            //getting previous day rates
            DateTime datetime = DateTime.Now;
            datetime = datetime.AddDays(-1);
            var previous = getRatesByDate(datetime);
            repo.AddRates(previous);
        }

        public void RetrieveCurrent()
        {
            var data = ReadJson();
            List<RateModel> list = ResponseToModel(data);
            repo.AddRates(list);
        }

        private static List<RateModel> ResponseToModel(Dictionary<string, Positions> data)
        {
            var list = new List<RateModel>();
            foreach (KeyValuePair<string, Positions> pair in data)
            {
                RateModel rm = new RateModel
                {
                    CurrencyName = pair.Key,
                    BuyRate = pair.Value.interbankRateValues.Buy,
                    SellRate = pair.Value.interbankRateValues.Sell,
                    SellTrend = null,
                    BuyTrend = null,
                    CreationDate = DateTime.Now
                };
                list.Add(rm);
            }

            return list;
        }

        public List<RateModel> Rates
        {
            get
            {
                return repo.GetRates();
            }
        }

    }
}
