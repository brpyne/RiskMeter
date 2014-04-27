using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Data;

namespace RiskMeter.WebScraper
{
    public class Service
    {
        public void Start()
        {
            foreach (string state in GetStates())
            {
                var stateListingsScraper = new CityListingsScraper(state);


            }

            // 3. Retrieve crime data from each city for storage
            // /data/detroit-data.htm
            var scraper = new CrimeDataScraper("/Data/detroit-data.htm");
            scraper.GetData();

            Console.ReadLine();
        }

        public List<string> GetStates()
        {
            using (var db = new RiskMeterEntities())
            {
                return db.States.Select(x => x.Name).ToList();
            }
        }
    }
}
