using Newtonsoft.Json;
using System;

namespace SimpleApp.BL
{
    public class RateModel
    {
        [JsonProperty("CurrencyName")]
        public string CurrencyName { get; set; }
        [JsonProperty("BuyRate")]
        public decimal BuyRate { get; set; }
        [JsonProperty("SellRate")]
        public decimal SellRate { get; set; }
        [JsonProperty("BuyTrend")]
        public decimal? BuyTrend { get; set; }
        [JsonProperty("SellTrend")]
        public decimal? SellTrend { get; set; }
        [JsonProperty("TradeDate")]
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