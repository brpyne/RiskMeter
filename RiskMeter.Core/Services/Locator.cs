using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskMeter.Core.Services
{
    public interface ILocator
    {
        string NearestCity(double longitude, double latitude);
    }

    public class Locator : ILocator
    {
        public string NearestCity(double longitude, double latitude)
        {
            return "Detroit";
        }
    }
}
