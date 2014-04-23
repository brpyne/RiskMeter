using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class CitiesViewModel : MvxViewModel
    {
        public CitiesViewModel(string stateCode)
        {
            _cities = new LocationsService().GetCities(stateCode);
        }

        private List<string> _cities;

        public List<string> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }
    }
}