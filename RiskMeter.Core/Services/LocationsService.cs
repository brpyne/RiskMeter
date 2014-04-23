using System.Collections.Generic;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Services
{
    public interface ILocationsService
    {
        List<State> GetStates();
        List<string> GetCities(string stateCode);
    }

    public class LocationsService : BaseService, ILocationsService
    {
        public List<State> GetStates()
        {
            var states = new List<State> { new State() { Name = "Michigan", Code = "MI" }, new State() { Name = "Ohio", Code = "OH" } };

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