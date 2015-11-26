using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;
using XLabs.Ioc.Ninject;
using Ninject;

namespace Alia.Droid
{
	[Activity (Label = "Alia.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			if (!Resolver.IsSet)
				SetIoc();
			
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

		static void SetIoc ()
		{
			var standardKernel = new StandardKernel();
			var resolverContainer = new NinjectContainer(standardKernel);

			standardKernel.Bind<ITaskViewHelper>().To<TaskViewHelper>();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

