using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.BL
{
    class Repository
    {
        private List<RateModel> rates = new List<RateModel>();
        private SortedSet<DateTime> dates = new SortedSet<DateTime>();

        public decimal Trend(decimal actual, decimal old) => actual - old;

        public void AddRates(List<RateModel> list) {
            rates.AddRange(list);
            foreach(RateModel rate in list)
            {
                dates.Add(rate.TradeDate);
                UpdateTrends();
            }
        }

        protected void UpdateTrends()
        {
            if (dates.Count>1)
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    var previousRates = rates.Where(r => r.TradeDate == dates.ElementAt(i)).ToList();
                    foreach (var item in previousRates)
                    {
                        var current = rates.First(r => r.CurrencyName == item.CurrencyName);
                        rates.Find(x=>x.TradeDate==current.TradeDate&&x.CurrencyName==current.CurrencyName).SellTrend = Trend(current.SellRate, item.SellRate);
                    }

                }
            }
     
        }

        internal List<RateModel> GetRates()
        {
            UpdateTrends();
            return new List<RateModel>(rates.Where(r => r.TradeDate == dates.Last()).ToList());
            //return rates;
        }
    }
}
