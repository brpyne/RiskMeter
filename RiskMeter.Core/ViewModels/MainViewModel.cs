using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
	public class MainViewModel : MvxViewModel
	{
		public MainViewModel ()
		{
			_currentLocation = "Detroit, MI";
		}

		private string _currentLocation;

		public string CurrentLocation
		{
			get { return _currentLocation; }
			set { _currentLocation = value; RaisePropertyChanged(() => CurrentLocation); }
		}
	}
}

