using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class CitiesViewModel : MvxViewModel
    {
        public CitiesViewModel(ILocationsService locationsService)
        {
            _locationsService = locationsService;
        }

        public void Init(string state)
        {
            State = state;
            CityItems = _locationsService.GetCities(state)
                .Select(x => new CityMenuItem(x, state, this))
                .OrderBy(x => x.Name)
                .ToList();
        }

        private readonly ILocationsService _locationsService;
        private string _state;
        private List<CityMenuItem> _cityItems;

        public string State
        {
            get { return _state; }
            set { _state = value; RaisePropertyChanged(() => State); }
        }

        public List<CityMenuItem> CityItems
        {
            get { return _cityItems; }
            set
            {
                _cityItems = value;
                RaisePropertyChanged(() => CityItems);
            }
        }

        public class CityMenuItem
        {
            public CityMenuItem(string name, string state, CitiesViewModel parent)
            {
                Name = name;
                State = state;
                ShowCommand = new MvxCommand(() => parent.ShowViewModel<RiskViewModel>(new { city = Name, state = State }));
            }

            public string Name { get; set; }
            public string State { get; set; }

            public ICommand ShowCommand { get; private set; }
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