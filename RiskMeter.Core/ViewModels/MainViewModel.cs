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
		}

        private string _currentState;
        private string _currentCity;

        public string CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; RaisePropertyChanged(() => CurrentState); }
        }

        public string CurrentCity
        {
            get { return _currentCity; }
            set { _currentCity = value; RaisePropertyChanged(() => CurrentCity); }
        }

        public ICommand CustomLocationCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<StatesViewModel>());
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

