using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using RiskMeter.Core.Services;
using RiskMeter.Core.ViewModels;

namespace RiskMeter.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                    .AsInterfaces()
                    .RegisterAsLazySingleton();

			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }
    }
}