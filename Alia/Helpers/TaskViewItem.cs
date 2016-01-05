using Xamarin.Forms;

namespace Alia
{
	public class TaskViewItem
	{
		public int Id { get; set; } 
		public Color StatusColour { get; set; } 
		public string Title { get; set; } 

		public TaskViewItem(TextTaskTable item, bool nextTaskLocked)
		{
			Id = item.Id;
			Title = item.Name;
			StatusColour = GetTaskColour (nextTaskLocked, item.Locked);
		}

		static Color GetTaskColour (bool nextTaskLocked, bool locked)
		{
			if (locked) return ColourSettings.LockedTask;
			if (!nextTaskLocked) return ColourSettings.CompletedTask;
			return ColourSettings.UnlockedTask;
		}
	}
}