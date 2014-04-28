using System;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper
{
    public abstract class DataScraper
    {
        protected DataScraper(string url)
        {
            Web = new HtmlWeb();
            Document = new HtmlDocument();
            Document = Web.Load("http://www.city-data.com/crime/" + url);
        }

        protected HtmlWeb Web { get; set; }
        protected HtmlDocument Document { get; set; }
    }
}