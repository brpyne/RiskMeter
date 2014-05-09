namespace RiskMeter.WebScraper.Pages
{
    public class CityListingsPage : ListingsPage
    {
        public CityListingsPage(string path) : base(path)
        {
        }

        public void GetData()
        {
            var cityAnchors = GetCrimeDocumentAnchors();

            foreach (var cityAnchor in cityAnchors)
            {
                var crimeDataScraper = new CityCrimePage(cityAnchor.Attributes["href"].Value);
                crimeDataScraper.GetData();
            }
        }
    }
}
