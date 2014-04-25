using System.Collections.Generic;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Services
{
    public interface ILocationsService
    {
        List<string> GetStates();
        List<string> GetCities(string stateCode);
    }

    public class LocationsService : BaseService, ILocationsService
    {
        public List<string> GetStates()
        {
            var states = new List<string> { "Michigan", "Ohio" };

            return states;
        }

        public List<string> GetCities(string stateCode)
        {
            if (stateCode.ToUpper() == "MI")
            {
                return new List<string> {"Detroit", "Sterling Heights"};
            }

            if (stateCode.ToUpper() == "OH")
            {
                return new List<string> {"Cleveland", "Columbus"};
            }

            return new List<string>();
        }
    }
}