using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
   public class rateValues
    {
        [JsonProperty("buy")]
        public decimal Buy { get; set; }
        [JsonProperty("sell")]
        public decimal Sell { get; set; }
    }
}
