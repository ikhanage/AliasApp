using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Alia
{
	public class NativeListView : ListView
	{
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create ("Items", typeof(IEnumerable<TaskViewItem>), typeof(NativeListView), new List<TaskViewItem> ());
		
		public IEnumerable<TaskViewItem> Items 
		{
			get { return (IEnumerable<TaskViewItem>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		public void NotifyItemSelected (object item)
		{
			if (ItemSelected != null) {
				ItemSelected (this, new SelectedItemChangedEventArgs (item));
			}
		}
	}
}

