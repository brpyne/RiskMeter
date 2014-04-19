using System;

namespace RiskMeter.WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Retrieve listing of state directories
            // Source: http://www.city-data.com/crime/
            // /data/state-directory.htm

            // 2. Iterate through each state directory and retrieve listing of their respective city directory
            // Source http://www.city-data.com/crime/crime-Michigan.html
            // /data/michigan-directory.htm
            
            // 3. Retrieve crime data from each city for storage
            // /data/detroit-data.htm
            var scraper = new CrimeDataScraper("/Data/detroit-data.htm");
            scraper.GetData();

            Console.ReadLine();
        }
    }
}
