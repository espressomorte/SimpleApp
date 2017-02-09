using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SimpleApp
{

    public class UsdWrapper
    {
         [JsonProperty("USD")]
        public ValueSet ValueSet { get; set; }

    }

}
