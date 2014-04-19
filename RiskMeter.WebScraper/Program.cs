using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.WebScraper;

namespace WebScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new CrimeDataScraper("/Data/detroit-data.htm");
            scraper.GetData();

            Console.ReadLine();
        }
    }
}
