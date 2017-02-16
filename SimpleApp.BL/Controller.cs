using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.BL
{
    public class Controller
    {
      //  Repository repo = new Repository();

        IRates onlineRates = new OnlineAdapter();


        //read file with json
        public List<RateModel> RetrieveCurrent()
        {
            var data = new StreamReader("Repo.txt", Encoding.UTF8).ReadLine();
            return JsonConvert.DeserializeObject<List<RateModel>>(data);            
        }

        public List<RateModel> Rates
        {
            get
            {
                //return repo.GetRates();
                return GetRates();
            }
        }

        private List<RateModel> GetRates()
        {

            try
            {
               return onlineRates.Load();
               // WriteJson();
            }
            catch (WebException)
            {               
                return RetrieveCurrent();
            }

        }



        public void WriteJson()
        {
            FileStream file = new FileStream("Repo.txt", FileMode.Create);
            StreamWriter stream = new StreamWriter(file);
            stream.WriteAsync(JsonConvert.SerializeObject(Rates));
            stream.Flush();
            file.Close();
        }

    }
}
