using Newtonsoft.Json;

namespace SimpleApp.BL
{
    public class Positions
    {
        [JsonProperty("interbank")]
        public RateValues interbankRateValues { get; set; }
        [JsonProperty("nbu")]
        public RateValues nbuRateValues { get; set; }
    }

    public class RateValues
    {
        [JsonProperty("buy")]
        public decimal Buy { get; set; }
        [JsonProperty("sell")]
        public decimal Sell { get; set; }
    }
}
