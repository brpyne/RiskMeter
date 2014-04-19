using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScrape
{
    public class CrimeDataScraper
    {
        protected const string DataSourcePath = "/Data/detroit-data.htm";

        protected HtmlDocument dataSourceHtml;

        public CrimeDataScraper()
        {
            dataSourceHtml = new HtmlDocument();
            dataSourceHtml.Load(Environment.CurrentDirectory + DataSourcePath);
        }

        public void GetData()
        {
            var crimeTableNode = dataSourceHtml.GetElementbyId("crimeTab");


            Console.WriteLine(crimeTableNode.WriteContentTo());
        }
    }
}
