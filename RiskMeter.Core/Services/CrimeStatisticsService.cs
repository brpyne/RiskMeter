using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Services
{
    public interface ICrimeStatisticsService
    {
        CrimeStatistics GetCrimeStatistics(string cityName, string stateCode, int year);
    }

    public class CrimeStatisticsService : BaseService, ICrimeStatisticsService
    {
        public CrimeStatisticsService()
        {
            
        }

        public CrimeStatistics GetCrimeStatistics(string cityName, string stateCode, int year)
        {
            var crimeStatistics = new CrimeStatistics()
            {
                City = cityName,
                State = stateCode,
                Year = year,
                ArsonCount = 9,
                AssaultCount = 182,
                AutoTheftCount = 162,
                BurglaryCount = 357,
                MurderCount = 4,
                RapeCount = 16,
                RobberyCount = 30
            };

            return crimeStatistics;
        }
    }
}
