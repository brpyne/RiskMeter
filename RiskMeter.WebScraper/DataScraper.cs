using System;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper
{
    public abstract class DataScraper
    {
        protected DataScraper(string path)
        {
            Document = new HtmlDocument();
            Document.Load("http://www.city-data.com/crime/" + path);
        }

        protected HtmlDocument Document { get; set; }
    }
}