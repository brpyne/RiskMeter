using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Data;

namespace RiskMeter.WebScraper
{
    public class CityListingsScraper : DataScraper
    {
        private string _state;
        private string _stateCode;

        public CityListingsScraper(string state) : base("crime-"+state+".html")
        {
            _state = state;
            _stateCode = GetStateCode(state);
        }

        public void GetData()
        {
            // Loop through each city
                // SaveCity(name)
                // new CrimeDataScraper(name, state)
        }

        public List<string> GetCities()
        {
            return new List<string>();
        }

        public void SaveCity(string city)
        {
            
        }

        private string GetStateCode(string state)
        {
            using (var db = new RiskMeterEntities())
            {
                return db.States.Where(x => x.Name == state).Select(x => x.StateCode).FirstOrDefault();
            }
        }
    }
}
