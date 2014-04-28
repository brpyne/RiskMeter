using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
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
            Logger.Log(Url);
            var cityAnchors = GetCityAnchors();
        }

        private List<HtmlNode> GetCityAnchors()
        {
            var anchorList = new List<HtmlNode>();
            var anchors = Document.DocumentNode.SelectNodes("//a[@href]");

            foreach (HtmlNode link in anchors)
            {
                var attribute = link.Attributes["href"];
                var anchorLocation = attribute.Value;

                if (anchorLocation.Contains("crime-"))
                {
                    anchorList.Add(link);

                    Logger.Log(anchorLocation);
                }
            }

            return anchorList;
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
