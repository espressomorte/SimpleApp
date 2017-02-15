using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SimpleApp.BL
{
    public class Controller
    {
      //  Repository repo = new Repository();

        IRates onlineRates = new OnlineAdapter();


        //read file with json
        //public void RetrieveCurrent()
        //{
        //    var data = new StreamReader("Repo.txt", Encoding.UTF8).ReadLine();
        //    var list = JsonConvert.DeserializeObject<List<RateModel>>(data);
        //    repo.AddRates(list);
        //}

        public List<RateModel> Rates
        {
            get
            {
                //return repo.GetRates();
                return onlineRates.Load();
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
