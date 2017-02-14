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
                 var previousRates = rates.Where(r => r.TradeDate == dates.ElementAt(0)).ToList();
                 foreach (var item in previousRates)
                 {
                     var current = rates.First(r => r.CurrencyName == item.CurrencyName);
                        
                     current.SellTrend = current.SellRate - item.SellRate;
                     current.BuyTrend = current.BuyRate - item.BuyRate;
             
                 }
            }
     
        }

        internal List<RateModel> GetRates()
        {
            return new List<RateModel>(rates.Where(r => r.TradeDate == dates.Last()).ToList());
            //return rates;
        }
    }
}
