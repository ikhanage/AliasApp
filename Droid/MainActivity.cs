using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;
using XLabs.Ioc.Ninject;
using Ninject;

namespace Alia.Droid
{
	[Activity (Label = "Alia", Icon = "@drawable/heart", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			if (!Resolver.IsSet)
				SetIoc();
			
			base.OnCreate (savedInstanceState);

			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);

			LoadApplication (new App ());
		}

		static void SetIoc ()
		{
			var standardKernel = new StandardKernel();
			var resolverContainer = new NinjectContainer(standardKernel);

			standardKernel.Bind<IDatabaseHelper> ().To<DatabaseHelper> ();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}