using System;

namespace SimpleApp.BL
{
    public class RateModel
    {
        public string CurrencyName { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public decimal? BuyTrend { get; set; }
        public decimal? SellTrend { get; set; }
        public DateTime TradeDate { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {5}] Buy: {1}; {2} Sell: {3}; {4}",
                CurrencyName,
                BuyRate, BuyTrend,
                SellRate, SellTrend,
                TradeDate
            );
        }
    }
}