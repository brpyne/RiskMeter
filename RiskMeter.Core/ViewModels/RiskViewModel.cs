using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.ViewModels
{
    public class RiskViewModel : MvxViewModel
    {
        private string _location;
        private int _score;

        public RiskViewModel()
        {
            
        }

        public void Init(string city, string state)
        {
            Location = string.Format("{0}, {1}", city, state);

            Score = 5;
        }

        public string Location
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