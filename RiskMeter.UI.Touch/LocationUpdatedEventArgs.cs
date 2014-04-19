using System;
using MonoTouch.CoreLocation;

namespace RiskMeter.UI.Touch
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        private readonly CLLocation location;

        public LocationUpdatedEventArgs(CLLocation location)
        {
            this.location = location;
        }

        public CLLocation Location
        {
            get { return location; }
        }
    }
}