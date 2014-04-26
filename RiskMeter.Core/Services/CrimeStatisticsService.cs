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
        int GetCrimeScore(string city, string state);
        List<CrimeStatistic> GetCrimeStatistics(string city, string state, int year);
    }

    public class CrimeStatisticsService : BaseService, ICrimeStatisticsService
    {
        public CrimeStatisticsService()
        {
        }

        public int GetCrimeScore(string city, string state)
        {
            return 100;
        }

        public List<CrimeStatistic> GetCrimeStatistics(string city, string state, int year)
        {
            var crimeStatistics = new List<CrimeStatistic>()
            {
                new CrimeStatistic()
                {
                    Count = 5,
                    Name = "Arson",
                    Population = 100100
                },
                new CrimeStatistic()
                {
                    Count = 8,
                    Name="Robbery",
                    Population=100100
                }
            };

            return crimeStatistics;
        }
    }
}
