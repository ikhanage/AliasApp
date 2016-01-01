using Xamarin.Forms;
using Alia;
using Alia.Droid;
using Xamarin.Forms.Platform.Android;
using System.Linq;

[assembly: ExportRenderer (typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
namespace Alia.Droid
{
	public class NativeAndroidListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				Control.ItemClick -= OnItemClick;
			}

			if (e.NewElement != null) {
				Control.Adapter = new NativeAndroidListViewAdapter (Forms.Context as Android.App.Activity, e.NewElement as NativeListView);
				Control.ItemClick += OnItemClick;
			}
		}

		void OnItemClick (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{           
			((NativeListView)Element).NotifyItemSelected (((NativeListView)Element).Items.ToList () [e.Position - 1]);
		}
	}
}