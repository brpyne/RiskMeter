using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using RiskMeter.Data;

namespace RiskMeter.WebScraper.PageScrapers
{
    public class CityListingsScraper : ListingsScraper
    {
        public CityListingsScraper(State state) : base("crime-"+state.Name+".html")
        {
            State = state;
        }

        public State State { get; set; }

        public void GetData()
        {
            Logger.Log(Url);
            var cityAnchors = GetCrimeDocumentAnchors();
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
