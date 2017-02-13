using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.BL
{
    class Repository
    {
        private List<RateModel> rates = new List<RateModel>();
        private SortedSet<DateTime> dates = new SortedSet<DateTime>();

        public decimal trend(decimal actual, decimal old) => actual - old;

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
                //for (int i = 0; i < dates.Count; i++)
                //{
                    var PreviousRates = rates.Where(r => r.TradeDate == dates.ElementAt(0)).ToList();
                    foreach (var item in PreviousRates)
                    {
                        var Current = rates.First(r => r.CurrencyName == item.CurrencyName);
                        //rates.Find(x=>x.TradeDate==Current.TradeDate&&x.CurrencyName==Current.CurrencyName).SellTrend = trend(Current.SellRate, item.SellRate);
                        Current.SellTrend = Current.SellRate - item.SellRate;
                    Current.BuyTrend = Current.BuyRate - item.BuyRate;
                    //}

                }
            }
     
        }

        // TODO: rates are exposed, so incapsulation is basically screwed.
        internal List<RateModel> GetRates()
        {
            return new List<RateModel>(rates.Where(r => r.TradeDate == dates.Last()).ToList());
            //return rates;
        }
    }
}
