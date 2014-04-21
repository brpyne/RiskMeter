using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.ViewModels
{
    public class RiskViewModel : MvxViewModel
    {
        private Location _location;
        private int _score;

        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged(() => Location);
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged(() => Score);
            }
        }
    }
}