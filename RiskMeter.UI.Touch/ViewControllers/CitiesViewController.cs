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
    [Register("CitiesView")]
    public class CitiesViewController : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new CitiesTableSource(TableView);
            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource CityItems"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }
    }

    public class CitiesTableSource : MvxStandardTableViewSource
    {
        private static readonly NSString Identifier = new NSString("MenuCellIdentifier");
        private const string BindingText = "TitleText Name;SelectedCommand ShowCommand";

        public CitiesTableSource(UITableView tableView)
            : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
        {
        }
    }
}