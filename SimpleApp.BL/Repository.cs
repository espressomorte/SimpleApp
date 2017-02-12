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
        private HashSet<DateTime> dates = new HashSet<DateTime>();


        public void AddRates(List<RateModel> list) {
            rates.AddRange(list);
            foreach(RateModel rate in list)
            {
                dates.Add(rate.CreationDate);
                UpdateTrends();
            }
        }

        protected void UpdateTrends()
        {
           
        }

        // TODO: rates are exposed, so incapsulation is basically screwed.
        internal List<RateModel> GetRates()
        {
            return rates;
        }
    }
}
