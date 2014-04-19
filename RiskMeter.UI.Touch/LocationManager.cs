using System;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;

namespace RiskMeter.UI.Touch
{
    public class LocationManager
    {
        protected CLLocationManager locMgr;

        public LocationManager()
        {
            locMgr = new CLLocationManager();
            LocationUpdated += PrintLocation;
        }

        public CLLocationManager LocMgr
        {
            get { return locMgr; }
        }

        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

        public void StartLocationUpdates()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                LocMgr.DesiredAccuracy = 1; // in meters

                if (UIDevice.CurrentDevice.CheckSystemVersion(6, 0))
                {
                    LocMgr.LocationsUpdated +=
                        (sender, e) =>
                            LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
                }
                else
                {
                    LocMgr.UpdatedLocation +=
                        (sender, e) => LocationUpdated(this, new LocationUpdatedEventArgs(e.NewLocation));
                }

                LocMgr.StartUpdatingLocation();
                LocMgr.Failed += (sender, e) => Console.WriteLine(e.Error);
            }
            else
            {
                Console.WriteLine("Location services not enabled, please enable this in your Settings");
            }
        }

        //This will keep going in the background and the foreground
        public void PrintLocation(object sender, LocationUpdatedEventArgs e)
        {
            CLLocation location = e.Location;

            Console.WriteLine("Altitude: " + location.Altitude + " meters");
            Console.WriteLine("Longitude: " + location.Coordinate.Longitude);
            Console.WriteLine("Latitude: " + location.Coordinate.Latitude);
            Console.WriteLine("Course: " + location.Course);
            Console.WriteLine("Speed: " + location.Speed);
        }
    }
}