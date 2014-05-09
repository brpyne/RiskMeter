using System;
using System.Linq;
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

        public static City GetCity(string cityName, string stateCode)
        {
            try
            {
                using (var db = new RiskMeterEntities())
                {
                    return
                        db.Cities.FirstOrDefault(
                            x => x.Name.ToLower() == cityName.ToLower() &&
                                 x.StateCode.ToLower() == stateCode.ToLower());
                }
            }
            catch (Exception e)
            {
                string logMessage = string.Format("Failed to get city: {0}, {1}", cityName, stateCode);
                Logger.Log(logMessage);

                throw;
            }
        }
    }
}