using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.ViewModels
{
    public class LocationsViewModel : MvxViewModel
    {
        private IEnumerable<Location> _locations;

        public IEnumerable<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged(() => Locations);
            }
        }
    }
}