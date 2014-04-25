using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RiskMeter.Core.Models;
using RiskMeter.Core.ViewModels;

namespace RiskMeter.UI.Touch.ViewControllers
{
    [Register("StatesView")]
    public class StatesViewController : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView);
            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource StateItems"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
    public class TableSource : MvxStandardTableViewSource
    {
        private static readonly NSString Identifier = new NSString("MenuCellIdentifier");
        private const string BindingText = "TitleText Name;SelectedCommand ShowCommand";

        public TableSource(UITableView tableView)
            : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
        {
        }
    }
}