using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RiskMeter.Core.Services;

namespace RiskMeter.UI.Touch.ViewControllers
{
    [Register("RiskView")]
    public class RiskViewController : MvxViewController
    {
        private readonly ICrimeStatisticsService _crimeStatistics;

        public string Location { get; set; }

        public RiskViewController()
        {
            
        }

        public RiskViewController(ICrimeStatisticsService crimeStatistics)
        {
            _crimeStatistics = crimeStatistics;
        }

        public override void ViewDidLoad()
        {
            View = new UIView() {BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            var scoreLabel = new UILabel(new RectangleF(10, 10, 200, 50))
            {
                Text = "5"
            };
            Add(scoreLabel);

            var locationLabel = new UILabel(new RectangleF(10, 70, 200, 50));
            Add(locationLabel);

            var set = this.CreateBindingSet<RiskViewController, Core.ViewModels.RiskViewModel>();
            set.Bind(locationLabel).To(vm => vm.Location);
            set.Apply();
        }
    }
}