using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using RiskMeter.Core.Models;

namespace RiskMeter.UI.Touch.ViewControllers
{
    [Register("MainView")]
    public class MainViewController : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;

            var btnCurrentLocation = new UIButton(UIButtonType.RoundedRect) {Frame = new RectangleF(10, 100, 300, 50)};
            btnCurrentLocation.SetTitleColor(UIColor.Black, UIControlState.Normal);
            btnCurrentLocation.SetTitle("Current Location", UIControlState.Normal);
            btnCurrentLocation.BackgroundColor = UIColor.LightGray;
            Add(btnCurrentLocation);

            var btnCustomLocation = new UIButton(UIButtonType.RoundedRect) {Frame = new RectangleF(10, 200, 300, 50)};
            btnCustomLocation.SetTitleColor(UIColor.Black, UIControlState.Normal);
            btnCustomLocation.SetTitle("Custom Location", UIControlState.Normal);
            btnCustomLocation.BackgroundColor = UIColor.LightGray;
            Add(btnCustomLocation);

            var set = this.CreateBindingSet<MainViewController, Core.ViewModels.MainViewModel>();
            set.Bind(btnCurrentLocation).To(vm => vm.CurrentLocationCommand);
            set.Bind(btnCustomLocation).To(vm => vm.CustomLocationCommand);
            set.Apply();
        }
    }
}