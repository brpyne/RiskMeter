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

            var source = new MvxStandardTableViewSource(TableView, "TitleText Name");
            TableView.Source = source;

            var set = this.CreateBindingSet<StatesViewController, StatesViewModel>();
            set.Bind(source).To(vm => vm.States);
            set.Apply();

            TableView.ReloadData();
        }
    }
}