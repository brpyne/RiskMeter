using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
	public class MainViewModel : MvxViewModel
	{
		public MainViewModel ()
		{
		    _currentLocation = new Location()
		    {
		        City = "Detroit",
		        State = "MI"
		    };
		}

		private Location _currentLocation;

        public Location CurrentLocation
		{
			get { return _currentLocation; }
			set { _currentLocation = value; RaisePropertyChanged(() => CurrentLocation); }
		}

        public ICommand CustomLocationCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocationsViewModel>());
            }
        }

        public ICommand CurrentLocationCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RiskViewModel>());
            }
        }
	}
}

