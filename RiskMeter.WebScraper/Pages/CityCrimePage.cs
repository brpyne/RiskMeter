using System;
using HtmlAgilityPack;
using RiskMeter.Data;
using RiskMeter.WebScraper.Pages.Nodes;
using RiskMeter.WebScraper.Repositories;

namespace RiskMeter.WebScraper.Pages
{
    public class CityCrimePage : CityDataPage
    {
        public CityCrimePage(string path)
            : base(path)
        {
        }

        public void GetData()
        {
            int cityId;
            if (SaveCity(Document.GetElementbyId("top"), out cityId))
            {
                var crimeTable = new CrimeTable(Document.GetElementbyId("crimeTab"), 0);

                for (int row = 1; row < crimeTable.RowCount - 1; row++)
                {
                    for (int col = 2; col < crimeTable.ColumnCount - 1; col++)
                    {
                        try
                        {
                            string logMessage = string.Format(
                                "In {0} there were {1} crimes of type \"{2}\" ({3} per 100,000)",
                                crimeTable.GetColumnValue(col),
                                crimeTable.GetCellValue(row, col),
                                crimeTable.GetRowName(row),
                                crimeTable.GetCellSubValue(row, col));
                            Logger.Log(logMessage);
                        }
                        catch (ArgumentNullException)
                        {
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private bool SaveCity(HtmlNode topNode, out int cityId)
        {
            try
            {
                string title = topNode.InnerText;
                title = title.Remove(0, 14);

                string cityName = title.Substring(0, title.IndexOf(','));
                string stateCode = title.Substring(title.IndexOf('(') + 1, 2);

                CitiesRepository.AddCity(cityName, stateCode);

                cityId = 0;
                //cityId = CitiesRepository.GetCity(cityName, stateCode).CityId;

                return true;
            }
            catch (Exception e)
            {
                Logger.Log("Failed to save crime data location for path: " + Path);

                cityId = 0;

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
}