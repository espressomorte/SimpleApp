using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SimpleApp.BL
{
    public class Controller
    {
        Repository repo = new Repository();
        
        private DateTime TimeStamp()
        {
            return DateTime.Now;
        }

        private List<RateModel> GetRatesByDate(DateTime date)
        {
            StringBuilder url = new StringBuilder();
            url.Append(@"http://openrates.in.ua/rates?date=").
                    Append(date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day);
            return ResponseToModel(ReadJson(url.ToString()),date);
        }

        public void UpdateTrends()
        {
            RetrieveLastDay();
            
        }

        private Dictionary<string, Positions> ReadJson()
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
            DateTime datetime = TimeStamp();
            datetime = datetime.AddDays(-4);
            var previous = GetRatesByDate(datetime);
            repo.AddRates(previous);
        }

        public void RetrieveCurrent()
        {
            var data = ReadJson();
            List<RateModel> list = ResponseToModel(data,TimeStamp());
            repo.AddRates(list);
        }

        private static List<RateModel> ResponseToModel(Dictionary<string, Positions> data,DateTime date)
        {
            return data.AsParallel().Select(pair => new RateModel
                {
                    CurrencyName = pair.Key,
                    BuyRate = pair.Value.interbankRateValues.Buy,
                    SellRate = pair.Value.interbankRateValues.Sell,
                    SellTrend = null,
                    BuyTrend = null,
                    TradeDate = date
                })
                .ToList();
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
