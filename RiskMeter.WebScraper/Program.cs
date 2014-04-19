using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new CrimeDataScraper();
            scraper.GetData();
            Console.ReadLine();
            /*
             table#crimeTab.sortable 
             */
        }
    }
}
