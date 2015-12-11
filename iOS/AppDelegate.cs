using Foundation;
using UIKit;
using XLabs.Ioc;
using XLabs.Ioc.Ninject;
using Ninject;

namespace Alia.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			if (!Resolver.IsSet)
				SetIoc();
			
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
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

