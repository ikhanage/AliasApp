using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Alia
{
	public class DatabaseHelper : IDatabaseHelper
	{
		readonly SQLiteConnection db;

		public DatabaseHelper ()
		{
			db = DependencyService.Get<ISQLite> ().GetConnection();
		}

		public void UpdateLockStatus(int id, bool locked = false)
		{
			var task = db.Table<TextTaskTable> ().Single (x => x.Id == id);
			task.Locked = locked;

			db.Update (task);
		}

		public void UpdateCompletedStatus(int id, bool completed = true)
		{
			var task = db.Table<TextTaskTable> ().Single (x => x.Id == id);
			task.Completed = completed;

			db.Update (task);
		}

		public List<TextTaskTable> GetTasks()
		{
			return db.Table<TextTaskTable> ().ToList();
		}
	}
}