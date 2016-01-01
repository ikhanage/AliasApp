using Android.Widget;
using Android.App;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace Alia.Droid
{
	public class NativeAndroidListViewAdapter : BaseAdapter<TaskViewItem>
	{
		readonly Activity context;
		IList<TaskViewItem> tableItems = new List<TaskViewItem> ();

		public IEnumerable<TaskViewItem> Items {
			set { 
				tableItems = value.ToList ();
			}
		}

		public NativeAndroidListViewAdapter (Activity context, NativeListView view)
		{
			this.context = context;
			tableItems = view.Items.ToList ();

		}

		public override TaskViewItem this [int index] {
			get { 
				return tableItems [index];
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get { return tableItems.Count; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = tableItems [position];

			var view = convertView;
			if (view == null) {
				view = context.LayoutInflater.Inflate (Resource.Layout.NativeAndroidListViewCell, null);
			}
			view.FindViewById<TextView> (Resource.Id.Status).SetBackgroundColor (item.StatusColour.ToAndroid ());
			view.FindViewById<TextView> (Resource.Id.Title).Text = item.Title;

			return view;
		}
	}
}