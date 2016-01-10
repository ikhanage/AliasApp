using Android.App;
using Android.Content;
using Android.OS;

namespace Alia.Droid
{
	[Activity (Label = "Alia", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]			
	public class Splash : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
			Finish();
		}
	}
}