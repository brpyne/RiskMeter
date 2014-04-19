using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using RiskMeter.Core;
using RiskMeter.Core.ViewModels;

namespace RiskMeter.UI.Touch
{
	public partial class HomeView : MvxViewController
	{
		public new HomeViewModel ViewModel
		{
			get { return (HomeViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public HomeView () : base ("HomeView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.CreateBinding (this.lblCurrentLocation).To ((HomeViewModel vm) => vm.CurrentLocation).Apply ();
		}
	}
}

