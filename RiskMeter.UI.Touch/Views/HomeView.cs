using System;
using System.Drawing;
using System.Threading.Tasks;
using MonoTouch.AddressBook;
using MonoTouch.CoreLocation;
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
        private CLLocation _currentLocation;
        private CLPlacemark _closestPlacemark;

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

            UIApplication.Notifications.ObserveDidBecomeActive((sender, args) =>
            {
                AppDelegate.Manager.LocationUpdated += HandleLocationChanged;
            });

            UIApplication.Notifications.ObserveDidEnterBackground((sender, args) =>
            {
                AppDelegate.Manager.LocationUpdated -= HandleLocationChanged;
            });

            this.CreateBinding(this.lblCurrentLocation).To((HomeViewModel vm) => vm.CurrentLocation).Apply();
        }

        public void HandleLocationChanged(object sender, LocationUpdatedEventArgs e)
        {
            CurrentLocation = e.Location;
        }

        public CLLocation CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;

                SetClosestPlacemark(_currentLocation);
            }
        }

        public CLPlacemark ClosestPlacemark
        {
            get
            {
                return _closestPlacemark;
            }
            set
            {
                _closestPlacemark = value;

                lblCurrentLocation.Text = GetCurrentCity(_closestPlacemark);
            }
        }

        public async void SetClosestPlacemark(CLLocation location)
        {
            var placemarks = await this.ReverseGeocodeAsync(location);
            ClosestPlacemark = placemarks[0];

        }

        public string GetCurrentCity(CLPlacemark placemark)
        {
            NSObject city;
            placemark.AddressDictionary.TryGetValue(ABPersonAddressKey.City, out city);

            if (city == null)
            {
                // Notify user
                return "Not Found";
            }

            return city.ToString();
        }

        public async Task<CLPlacemark[]> ReverseGeocodeAsync(CLLocation location)
        {
            var geoCoder = new CLGeocoder();
            var placemarks = await geoCoder.ReverseGeocodeLocationAsync(location);

            foreach (var placemark in placemarks)
            {
                Console.WriteLine(placemark);
            }

            return placemarks;
        }
	}
}

