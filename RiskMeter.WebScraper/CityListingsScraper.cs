using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Data;

namespace RiskMeter.WebScraper
{
    public class CityListingsScraper : DataScraper
    {
        public CityListingsScraper(State state) : base("crime-"+state+".html")
        {
            State = state;
        }

        public State State { get; set; }

        public void GetData()
        {
            // Loop through each city
                // AddCity(name)
                // new CrimeDataScraper(name, state)
        }

        public List<string> GetCities()
        {
            return new List<string>();
        }

        public void AddCity(string city)
        {
            using (var db = new RiskMeterEntities())
            {
                db.Cities.Add(new City()
                {
                    Name = city,
                    StateCode = State.StateCode
                });

                var logMessage = string.Format("Saving {0}, {1}", city, State.StateCode);
                Logger.Log(logMessage);
                //db.SaveChanges();
            }
        }
    }
}
