using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

namespace SimpleApp.BL
{
    public class RateObject
    {

       public RateValues Values { get; set; }
        public decimal SellTrend { get; set; }
        public decimal BuyTrend { get; set; }

        public RateObject()
        {
            Values = RateRepository.getValueSet().interbankRateValues;
            getTrends();
        }

        static decimal trend(decimal actual, decimal old) => actual - old;

        private void getTrends()
        {
            //getting previous day rates
            DateTime datetime = DateTime.Now;
            datetime = datetime.AddDays(-1);
            var previousValues = RateRepository.getUsdByDate(datetime.Date).interbankRateValues;
            
            SellTrend = trend(Values.Sell, previousValues.Sell);
            BuyTrend = trend(Values.Buy, previousValues.Buy);
        }

    }
}
