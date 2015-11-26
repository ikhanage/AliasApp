using Xamarin.Forms;

namespace Alia
{
	public class App : Application
	{
 		public App ()
		{
			RegisterViews ();
			MainPage = new StartPage ();
		}

		void RegisterViews()
		{
			
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

