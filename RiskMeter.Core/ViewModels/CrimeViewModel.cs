using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class CrimeViewModel : MvxViewModel
    {
        private readonly ICrimeStatisticsService _crimeStatistics;
        private List<CrimeStatistic> _statistics;
        private string _city;
        private string _state;
        private int _score;

        public CrimeViewModel(ICrimeStatisticsService crimeStatistics)
        {
            _crimeStatistics = crimeStatistics;
        }

        public void Init(string city, string state)
        {
            City = city;
            State = state;
            Statistics = _crimeStatistics.GetCrimeStatistics(City, State, DateTime.Now.Year);
            Score = _crimeStatistics.GetCrimeScore(City, State);
        }

        public List<CrimeStatistic> Statistics
        {
            get { return _statistics; }
            set
            {
                _statistics = value;
                RaisePropertyChanged(() => Statistics);
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged(() => Score);
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged(() => State);
            }
        }

        public string Location
        {
            get { return string.Format("{0}, {1}", City, State); }
        }
    }
}