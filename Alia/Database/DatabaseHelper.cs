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

		public TextTaskTable GetTaskById(int id)
		{
			var textTask = db.Table<TextTaskTable> ().Single (x => x.Id == id);

			var quizTask = db.Table<QuizTaskTable> ().SingleOrDefault (x => x.Id == id);

			var navTask = db.Table<NavTaskTable> ().SingleOrDefault (x => x.Id == id);

			if (quizTask != null) {
				return quizTask;
			}

			if (navTask != null) {
				return navTask;
			}

			return textTask;
		}
	}
}