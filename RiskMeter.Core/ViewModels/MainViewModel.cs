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
                return new MvxCommand(() => ShowViewModel<CrimeViewModel>());
            }
        }
	}
}

