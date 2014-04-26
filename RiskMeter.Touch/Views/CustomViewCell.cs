using MonoTouch.UIKit;

namespace RiskMeter.Touch.Views
{
    public class CustomViewCell : UITableViewCell
    {
        readonly UIView _child;

        public UIEdgeInsets Padding { get; set; }
        public bool ResizeChild { get; set; }

        public CustomViewCell(UIView child)
            : base(UITableViewCellStyle.Default, "CustomViewCell")
        {
            _child = child;

            SelectionStyle = UITableViewCellSelectionStyle.None;
            ResizeChild = true;
            Padding = new UIEdgeInsets();

            var frame = child.Frame;
            frame.Height = frame.Bottom;
            frame.Y = 0;

            Frame = frame;
            ContentView.AddSubview(child);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (!ResizeChild)
            {
                _child.Center = ContentView.Center;
                return;
            }

            var bounds = ContentView.Bounds;
            bounds.X += Padding.Left;
            bounds.Y += Padding.Top;
            bounds.Height -= (Padding.Bottom + Padding.Top);
            bounds.Width -= (Padding.Left + Padding.Right);

            _child.Frame = bounds;
        }
    }
}