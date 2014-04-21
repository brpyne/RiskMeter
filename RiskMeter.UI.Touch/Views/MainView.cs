using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace RiskMeter.UI.Touch.Views
{
    [Register("MainView")]
    public class MainView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			   
            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textField);

            var header = new UIView(new RectangleF(0,0,320,420))
            {
                BackgroundColor = UIColor.Blue,
            };

            var location = new UILabel(new RectangleF(10, 10, 300, 40));
            location.Text = "test";
            header.Add(location);

            Add(header);

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(label).To(vm => vm.CurrentLocation);
            set.Bind(textField).To(vm => vm.CurrentLocation);
            set.Apply();
        }
    }
}