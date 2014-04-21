using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;
using RiskMeter.Core.ViewModels;

namespace RiskMeter.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
			Mvx.RegisterType<ICrimeStatisticsService, CrimeStatisticsService>();
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }
    }
}