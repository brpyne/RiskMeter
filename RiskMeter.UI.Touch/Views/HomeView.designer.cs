// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace RiskMeter.UI.Touch
{
	[Register ("HomeView")]
	partial class HomeView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblCurrentLocation { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblCurrentLocation != null) {
				lblCurrentLocation.Dispose ();
				lblCurrentLocation = null;
			}
		}
	}
}
