using Xamarin.Forms;
using Ninject;
using System;
using System.Collections.Generic;

namespace Alia
{
	public class MainView : ScrollView
	{
		readonly IDatabaseHelper _db;

		public MainView ()
		{
			var kernel = new StandardKernel();
			_db = kernel.Get<DatabaseHelper> ();
			MessagingCenter.Subscribe<LockView> (this, "TaskUpdate", RefreshPage);
			MessagingCenter.Subscribe<TextTaskView> (this, "TaskUpdate", RefreshPage);
			Content = TasksLayout ();
		}

		void RefreshPage(Object sender) 
		{
			Content = TasksLayout ();
		}

		StackLayout TasksLayout()
		{
			var layout = new StackLayout ();
			var listView = new ListView ();
			var listSource = new List<TaskViewItem> ();

			listView.ItemTemplate = new DataTemplate (typeof(TaskListTemplate));
			layout.Padding = AppSettings.LayoutPadding;

			var items = _db.GetTasks ().ToArray();
			var gesture = new TapGestureRecognizer();

			//gesture.Tapped += TaskTap;

			for (var i = 0; i < items.Length; i++) {
				var nextTaskLocked = i + 1 == items.Length || items [i + 1].Locked;
				var taskViewItem = new TaskViewItem (items [i], nextTaskLocked);
				//taskViewItem.GestureRecognizers.Add (gesture);

				//layout.Children.Add (taskViewItem);
				listSource.Add (taskViewItem);
			}

			listView.ItemTapped += ListView_ItemTapped;;
			listView.ItemsSource = listSource;
			layout.Children.Add (listView);
			
			return layout;
		}

		void ListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			var viewItem = (TaskViewItem)e.Item;
			Navigation.PushModalAsync (new TaskPage(viewItem.Id));
		}

		void TaskTap(object sender, SelectedItemChangedEventArgs e)
		{
			var viewItem = (TaskViewItem)sender;
			Navigation.PushModalAsync (new TaskPage(viewItem.Id));
		}
	}
}