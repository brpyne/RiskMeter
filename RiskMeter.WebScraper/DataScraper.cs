using System;
using HtmlAgilityPack;

namespace RiskMeter.WebScraper
{
    public abstract class DataScraper
    {
        protected DataScraper(string documentPath)
        {
            Document = new HtmlDocument();
            Document.Load(Environment.CurrentDirectory + documentPath);
        }

        protected HtmlDocument Document { get; set; }
    }
}