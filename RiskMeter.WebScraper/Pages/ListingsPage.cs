using System.Collections.Generic;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper.Pages
{
    public class ListingsPage : CityDataPage
    {
        public ListingsPage()
        {
        }

        public ListingsPage(string path) : base(path)
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

                if (!anchorLocation.Contains("crime-")) continue;

                anchorList.Add(link);
            }

            return anchorList;
        }
    }
}