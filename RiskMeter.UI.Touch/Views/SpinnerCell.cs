using MonoTouch.UIKit;

namespace RiskMeter.UI.Touch.Views
{
    public class SpinnerCell : CustomViewCell
    {
        public SpinnerCell()
            : base(CreateView())
        {
        }

        private static UIActivityIndicatorView CreateView()
        {
            var indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
            indicator.StartAnimating();

            return indicator;
        }
    }
}