using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace RiskMeter.Touch.ViewControllers
{
    [Register("StatesView")]
    public class StatesViewController : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new StatesTableSource(TableView);
            this.AddBindings(new Dictionary<object, string>
            {
                {source, "ItemsSource StateItems"}
            });

            TableView.Source = source;
            TableView.ReloadData();
        }
    }

    public class StatesTableSource : MvxStandardTableViewSource
    {
        private const string BindingText = "TitleText Name;SelectedCommand ShowCommand";
        private static readonly NSString Identifier = new NSString("MenuCellIdentifier");

        public StatesTableSource(UITableView tableView)
            : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
        {
        }

        public override string TitleForHeader(UITableView tableView, int section)
        {
            return "Select a State";
        }
    }
}