using System.Collections.Generic;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper.PageScrapers
{
    public class ListingsScraper : DataScraper
    {
        public ListingsScraper()
        {
        }

        public ListingsScraper(string url) : base(url)
        {
        }

        public List<HtmlNode> GetCrimeDocumentAnchors()
        {
            var anchorList = new List<HtmlNode>();
            HtmlNodeCollection anchors = Document.DocumentNode.SelectNodes("//a[@href]");

            foreach (HtmlNode link in anchors)
            {
                HtmlAttribute attribute = link.Attributes["href"];
                string anchorLocation = attribute.Value;

                if (anchorLocation.Contains("crime-"))
                {
                    anchorList.Add(link);

                    Logger.Log(anchorLocation);
                }
            }

            return anchorList;
        }
    }
}