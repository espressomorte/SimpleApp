using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SimpleApp
{

    public class OpenratesResponse
    {
        [JsonProperty("USD")]
        public Positions Dollar { get; set; }
        [JsonProperty("EUR")]
        public Positions Euro { get; set; }
    }

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
