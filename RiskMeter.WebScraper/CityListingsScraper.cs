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
        public CityListingsScraper(State state) : base("crime-"+state.Name+".html")
        {
            State = state;
        }

        public State State { get; set; }

        public void GetData()
        {
            Logger.Log(Document.ToString());
            // Loop through each city
            // AddCity(name)
            // new CrimeDataScraper(name, state)
        }

        public List<string> GetCities()
        {
            return new List<string>();
        }

        public void AddCity(string cityName)
        {
            try
            {
                var logMessage = string.Format("Saving {0}, {1}", cityName, State.StateCode);
                Logger.Log(logMessage);

                using (var db = new RiskMeterEntities())
                {
                    db.Cities.Add(new City()
                    {
                        Name = cityName,
                        StateCode = State.StateCode
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var logMessage = string.Format("Failed to save city: {0}, {1}", cityName, State.Name);
                Logger.Log(logMessage);
            }
        }
    }
}
