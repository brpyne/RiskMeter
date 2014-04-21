using System.Collections.Generic;
using System.Linq;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Services
{
    public interface ILocationsService
    {
        List<Location> GetLocations();
    }

    public class LocationsService : BaseService, ILocationsService
    {
        public List<Location> GetLocations()
        {
            return new List<Location>
            {
                new Location {City = "Detroit", State = "MI"},
                new Location {City = "Sterling Heights", State = "MI"},
                new Location {City = "Columbus", State = "OH"}
            };
        }

        public IEnumerable<Location> GetLocations(string state)
        {
            return GetLocations().Where(x => x.State == state);
        }
    }
}