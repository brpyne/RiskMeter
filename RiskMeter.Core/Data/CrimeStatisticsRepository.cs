﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Data
{
    public interface ICrimeStatisticsRepository
    {
        CrimeStatisticsModel GetCrimeStatistics(string cityName, string stateCode, int year);
    }

    public class CrimeStatisticsRepository : ICrimeStatisticsRepository
    {
        public CrimeStatisticsRepository()
        {
            
        }

        public CrimeStatisticsModel GetCrimeStatistics(string cityName, string stateCode, int year)
        {
            var crimeStatistics = new CrimeStatisticsModel()
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
