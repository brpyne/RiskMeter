using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class StatesViewModel : MvxViewModel
    {
        //IObservableCollection
        private List<State> _states;

        public StatesViewModel(ILocationsService locationsService)
        {
            _states = locationsService.GetStates();
        }

        public List<State> States
        {
            get { return _states; }
            set { _states = value; RaisePropertyChanged(() => States); }
        }

        public ICommand SelectStateCommand(string stateCode)
        {
            return new MvxCommand(() => ShowViewModel<CitiesViewModel>(stateCode));
        }
    }
}