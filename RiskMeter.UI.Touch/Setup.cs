using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.UIKit;
using RiskMeter.Core;

namespace RiskMeter.UI.Touch
{
    public class Setup : MvxTouchSetup
    {
        private MvxApplicationDelegate _applicationDelegate;
        private UIWindow _window;

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _applicationDelegate = applicationDelegate;
            _window = window;
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        /*

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            return new MyPresenter(_applicationDelegate, _window);
        }

        public override void Show(Cirrious.MvvmCross.Touch.Views.IMvxTouchView view)
		{
			if (view is TabBarView)
			{
				_tabBarView = view as TabBarView;
			}

			if (view is ProfileView)
			{
				if (_tabBarView != null)
				{
					_tabBarView.ShowGrandChild(view);
				}
				return;
			}
			if (view is UserSessionView)
			{
				if (_tabBarView != null)
				{
					_tabBarView.ShowGrandChild(view);
				}
				return;
			}

			if (view is SessionActionView)
			{
				if (_tabBarView != null)
				{
					_tabBarView.ShowGrandChild(view);
				}
				return;
			}

			base.Show(view);
		}
	}
    */
    }
}