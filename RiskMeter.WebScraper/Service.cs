using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Data;

namespace RiskMeter.WebScraper
{
    public class Service
    {
        public void Start()
        {
            try
            {
                Logger.Log("Starting Service...");

                foreach (State state in GetStates())
                {
                    Logger.Log("State: " + state.Name);
                    var stateListingsScraper = new CityListingsScraper(state);
                    stateListingsScraper.GetData();
                }


            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public List<State> GetStates()
        {
            using (var db = new RiskMeterEntities())
            {
                return db.States.ToList();
            }
        }
    }
}
