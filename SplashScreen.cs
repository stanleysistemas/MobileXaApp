using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace NavDrawer
{
	[Activity(
		Label = "MobileX"
		, MainLauncher = true
		, Icon = "@drawable/tecno"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{
		}
	}
}
