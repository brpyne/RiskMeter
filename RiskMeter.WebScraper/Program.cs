using System;

namespace RiskMeter.WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Retrieve listing of state directories
            // http://www.city-data.com/crime/

            // 2. Iterate through each state directory and retrieve listing of their respective city directory
            // http://www.city-data.com/crime/crime-Alabama.html
            
            // 3. Retrieve crime data from each city for storage
            var scraper = new CrimeDataScraper("/Data/detroit-data.htm");
            scraper.GetData();

            Console.ReadLine();
        }
    }
}
