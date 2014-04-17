using System.Collections.Generic;

namespace RiskMeter.Core.Services
{
    public interface ILocationsService
    {
        List<string> GetStateCodes();
        List<string> GetCityNames(string stateCode);
    }

    public class LocationsService : BaseService, ILocationsService
    {
        public List<string> GetStateCodes()
        {
            return new List<string> { "MI", "IN", "OH" };
        }

        public List<string> GetCityNames(string stateCode)
        {
            if (stateCode.Equals("MI"))
            {
                return new List<string>() {"Sterling Heights", "Detroit"};
            }

            if (stateCode.Equals("IN"))
            {
                return new List<string>() { "Indianapolis", "Fort Wayne" }; 
            }
            
            if (stateCode.Equals("OH"))
            {
                return new List<string>() { "Cleveland", "Dayton" }; 
            }

            return new List<string>();
        }
    }
}