using System;
using SimpleApp.BL;

namespace SimpleApp.CLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var c = new Controller();
           // c.RetrieveCurrent();
           // c.UpdateTrends();
           c.
            foreach (var rate in c.Rates)
            {
                Console.WriteLine(rate.ToString());
            }
            Console.ReadKey();
        }
    }
}