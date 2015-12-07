using Xamarin.Forms;

namespace Alia
{
	public class App : Application
	{
 		public App ()
		{
			AppStart ();
		}

		protected override void OnStart ()
		{
			AppStart ();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		void AppStart()
		{
			DatabaseSetUp ();
			MainPage = new StartPage ();
		}

		static void DatabaseSetUp()
		{
			var setUp = new DatabaseSetUp ();

			#if DEBUG
			setUp.DestoryTables();
			#endif

			setUp.CreateDBTables ();
			setUp.SetUpTasks ();
		}
	}
}