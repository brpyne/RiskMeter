using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class CitiesViewModel : MvxViewModel
    {
        public CitiesViewModel()
        {
        }

        public void Init(string state)
        {
            State = state;
            Cities = new LocationsService().GetCities(state);
        }

        private string _state;
        private List<string> _cities;

        public string State
        {
            get { return _state; }
            set { _state = value; RaisePropertyChanged(() => State); }
        }

        public List<string> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        /*
         * https://github.com/MvvmCross/MvvmCross/wiki/ViewModel--to-ViewModel-navigation
         public ICommand BackCommand
    {
            get
            {
                    return new MvxRelayCommand(() => Close(this);
            }
    }
        */
    }
}