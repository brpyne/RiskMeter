using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;

namespace RiskMeter.Core.ViewModels
{
    public class RiskViewModel
        : MvxViewModel
    {
        private readonly IRiskCalculator _riskCalculator;

        public RiskViewModel(IRiskCalculator riskCalculator)
        {
            _riskCalculator = riskCalculator;
        }

        public override void Start()
        {
            CityName = "Detroit";
            StateCode = "MI";

            base.Start();
        }

        private string _riskLevel;

        private string _cityName;

        private string _stateCode;

        public string RiskLevel
        {
            get { return _riskLevel; }
            set { _riskLevel = value; RaisePropertyChanged(() => RiskLevel); Recalculate(); }
        }

        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; RaisePropertyChanged(() => CityName); Recalculate(); }
        }

        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; RaisePropertyChanged(() => StateCode); Recalculate(); }
        }

        private void Recalculate()
        {
            RiskLevel = _riskCalculator.CalculateRisk(_cityName, _stateCode);
        }
    }
}