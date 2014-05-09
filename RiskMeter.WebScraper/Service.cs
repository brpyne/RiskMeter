using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RiskMeter.Data;
using RiskMeter.WebScraper.Pages;

namespace RiskMeter.WebScraper
{
    public class Service
    {
        public void Start()
        {
            try
            {
                Logger.Log("Starting Service...");

                var cityUrls = GetCityListingUrls();
                foreach (string url in cityUrls)
                {
                    var cityListingScraper = new CityListingsPage(url);
                    cityListingScraper.GetData();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private IEnumerable<string> GetCityListingUrls()
        {
            var statesScraper = new ListingsPage();
            var stateAnchors = statesScraper.GetCrimeDocumentAnchors();
            return stateAnchors.Select(link => link.Attributes["href"].Value).ToList();
        }
    }
}
