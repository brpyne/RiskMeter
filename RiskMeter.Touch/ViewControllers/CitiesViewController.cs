using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using RiskMeter.Core.Models;
using RiskMeter.Core.ViewModels;

namespace RiskMeter.Touch.ViewControllers
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

        public override string TitleForHeader(UITableView tableView, int section)
        {
            return "Select a City";
        }

        /*
    public override string[] SectionIndexTitles(UITableView tableView)
    {
        indexedTableItems = new Dictionary<string, List<string>>();
        foreach (var t in items) {
            if (indexedTableItems.ContainsKey (t[0].ToString ())) {
                indexedTableItems[t[0].ToString ()].Add(t);
            } else {
                indexedTableItems.Add (t[0].ToString (), new List<string>() {t});
            }
        }
        keys = indexedTableItems.Keys.ToArray ();
    }
         */
    }
}