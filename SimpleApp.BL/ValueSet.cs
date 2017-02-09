using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class ValueSet
    {
        [JsonProperty("interbank")]
        public rateValues interbankRateValues { get; set; }
        [JsonProperty("nbu")]
        public rateValues nbuRateValues { get; set; }
    }
}
