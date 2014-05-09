using System;
using RiskMeter.Data;

namespace RiskMeter.WebScraper.Repositories
{
    public class CitiesRepository
    {
        public static void AddCity(string cityName, string stateCode)
        {
            try
            {
                string logMessage = string.Format("Saving {0}, {1}", cityName, stateCode);
                Logger.Log(logMessage);

                using (var db = new RiskMeterEntities())
                {
                    db.Cities.Add(new City
                    {
                        Name = cityName,
                        StateCode = stateCode
                    });

                    //db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                string logMessage = string.Format("Failed to save city: {0}, {1}", cityName, stateCode);
                Logger.Log(logMessage);
            }
        }
    }
}