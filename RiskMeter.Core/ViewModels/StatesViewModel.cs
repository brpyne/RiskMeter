using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class StatesViewModel : MvxViewModel
    {
        private List<StateMenuItem> _stateItems;

        public StatesViewModel(ILocationsService locationsService)
        {
            StateItems = locationsService.GetStates().Select(x => new StateMenuItem(x, this))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public List<StateMenuItem> StateItems
        {
            get { return _stateItems; }
            set
            {
                _stateItems = value;
                RaisePropertyChanged(() => StateItems);
            }
        }

        public class StateMenuItem
        {
            public StateMenuItem(string name, StatesViewModel parent)
            {
                Name = name;
                ShowCommand = new MvxCommand(() => parent.ShowViewModel<CitiesViewModel>(name));
            }

            public string Name { get; set; }

            public ICommand ShowCommand { get; private set; }
        }
    }
}