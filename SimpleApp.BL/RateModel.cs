using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.BL
{
   public class RateModel
    {
        public string CurrencyName { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public decimal? BuyTrend { get; set; }
        public decimal? SellTrend { get; set; }
        public DateTime CreationDate { get; set; }
        
    }
}
