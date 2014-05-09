using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using RiskMeter.WebScraper.Repositories;

namespace RiskMeter.WebScraper.PageScrapers
{
    public class CrimeDataScraper : DataScraper
    {
        public CrimeDataScraper(string path)
            : base(path)
        {
        }

        public void GetData()
        {
            if (SaveLocation(Document.GetElementbyId("top")))
            {
                var crimeTable = new CrimeTable(Document.GetElementbyId("crimeTab"));

                string logMessage = string.Format(
                    "In {0} there were {1} crimes of type \"{2}\" ({3} per 100,000)",
                    crimeTable.GetColumnValue(3),
                    crimeTable.GetCellValue(3, 3),
                    crimeTable.GetRowName(3),
                    crimeTable.GetCellSubValue(3, 3));
                Logger.Log(logMessage);
            }
        }

        private bool SaveLocation(HtmlNode topNode)
        {
            try
            {
                string title = topNode.InnerText;
                title = title.Remove(0, 14);

                string cityName = title.Substring(0, title.IndexOf(','));
                string stateCode = title.Substring(title.IndexOf('(') + 1, 2);

                CitiesRepository.AddCity(cityName, stateCode);

                return true;
            }
            catch (Exception e)
            {
                Logger.Log("Failed to save crime data location for path: " + Path);

                return false;
            }
        }

        private bool SaveCityZipCodes(HtmlNode zipCodeNode)
        {
            // //*[@id="main_body"]/div[1]/table/tbody/tr/td[2]/p[3]
            // //*[@id="main_body"]/div[1]/table/tbody/tr/td[2]/p[2]
            // <p align="left"><b><b>Zip codes:</b></b> <a href="/zips/99660.html">99660</a>.</p>


            HtmlNodeCollection zipCodeAnchors = zipCodeNode.SelectNodes("//a[@href]");
            foreach (HtmlNode zipCodeAnchor in zipCodeAnchors)
            {
                Logger.Log(zipCodeAnchor.InnerHtml);
            }

            return true;
        }
    }

    public class CrimeTable
    {
        private readonly HtmlNode _crimeTable;

        public CrimeTable(HtmlNode crimeTable)
        {
            _crimeTable = crimeTable;
        }

        public int RowCount
        {
            get
            {
                HtmlNodeCollection rows = _crimeTable.SelectNodes("//tbody/tr");
                return rows.Count;
            }
        }

        public int ColumnCount
        {
            get
            {
                HtmlNodeCollection columns = _crimeTable.SelectNodes("//tbody/tr[1]/td");
                return columns.Count;
            }
        }

        public List<int> GetYears()
        {
            var years = new List<int>();
            HtmlNodeCollection headers = _crimeTable.SelectNodes("//thead/tr[2]/th");

            for (int i = 1; i < headers.Count; i++)
            {
                int newYear;
                HtmlNode header = headers[i];

                string year = header.InnerText;
                if (Int32.TryParse(year, out newYear))
                {
                    years.Add(newYear);
                }
            }

            return years;
        }


        public string GetRowName(int rowIndex)
        {
            HtmlNode firstColumn = GetCell(rowIndex, 1);
            if (firstColumn != null)
            {
                var row = firstColumn.SelectSingleNode("b");
                return row.InnerText;
            }

            return string.Empty;
        }

        public int GetColumnValue(int columnIndex)
        {
            HtmlNode headerNode = _crimeTable.SelectSingleNode("//thead/tr[2]");
            var columnNode = headerNode.SelectSingleNode(string.Format("//th[{0}]/h4", columnIndex));
            int columnValue;

            if (Int32.TryParse(columnNode.InnerText, out columnValue))
            {
                return columnValue;
            }

            return 0;
        }

        public int? GetCellValue(int rowIndex, int columnIndex)
        {
            string cellHtml = GetCell(rowIndex, columnIndex).InnerHtml;
            if (!string.IsNullOrEmpty(cellHtml) && cellHtml.Contains("<br>"))
            {
                string value = cellHtml.Substring(0, cellHtml.IndexOf("<br>", StringComparison.OrdinalIgnoreCase));

                int cellValue;
                if (Int32.TryParse(value, out cellValue))
                {
                    return cellValue;
                }
            }

            return null;
        }

        public decimal? GetCellSubValue(int rowIndex, int columnIndex)
        {
            // Retrieving value via XPath was not worth it due to weird issues with the HTMlAgilityPack, just parsing HTML instead

            string cellHtml = GetCell(rowIndex, columnIndex).InnerHtml;
            string subValue = cellHtml.Substring(
                cellHtml.IndexOf('(') + 1,
                cellHtml.IndexOf(')') - cellHtml.IndexOf('(') - 1);

            decimal cellSubValue;
            if (Decimal.TryParse(subValue, out cellSubValue))
            {
                return cellSubValue;
            }

            return null;
        }

        private HtmlNode GetCell(int rowIndex, int columnIndex)
        {
            HtmlNode row = _crimeTable.SelectSingleNode(string.Format("//tbody/tr[{0}]/td[{1}]", rowIndex, columnIndex));
            return row;
        }
    }
}