using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RiskMeter.Data;
using RiskMeter.WebScraper.PageScrapers;

namespace RiskMeter.WebScraper
{
    public class Service
    {
        public void Start()
        {
            try
            {
                Logger.Log("Starting Service...");


            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private List<string> GetCityListingUrls()
        {
            var statesScraper = new ListingsScraper();
            var stateAnchors = statesScraper.GetCrimeDocumentAnchors();
            return stateAnchors.Select(link => link.Attributes["href"].Value).ToList();
        }
    }
}
