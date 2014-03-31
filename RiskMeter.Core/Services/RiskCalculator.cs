using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskMeter.Core.Services
{
    public interface IRiskCalculator
    {
        string CalculateRisk(string cityName, string stateCode);
    }

    public class RiskCalculator : IRiskCalculator
    {
        public string CalculateRisk(string cityName, string stateCode)
        {
            return "Dangerous";
        }
    }
}
