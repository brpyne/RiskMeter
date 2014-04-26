using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using RiskMeter.Core.Services;

namespace RiskMeter.Touch.ViewControllers
{
    [Register("CrimeView")]
    public class CrimeViewController : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var scoreLabel = new UILabel(new RectangleF(10, 110, 200, 50));
            Add(scoreLabel);

            var locationLabel = new UILabel(new RectangleF(10, 70, 200, 50));
            Add(locationLabel);

            var set = this.CreateBindingSet<CrimeViewController, Core.ViewModels.CrimeViewModel>();
            set.Bind(scoreLabel).To(vm => vm.Score);
            set.Bind(locationLabel).To(vm => vm.Location);
            set.Apply();
        }
    }
}