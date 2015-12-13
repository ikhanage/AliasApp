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
			TextTaskTable task;

			task = db.Table<TextTaskTable> ().SingleOrDefault (x => x.Id == id);

			if(task == null)
				task = db.Table<QuizTaskTable> ().SingleOrDefault (x => x.Id == id);

			if(task == null)
				task = db.Table<NavTaskTable> ().Single (x => x.Id == id);
			
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
			var tasks = new List<TextTaskTable> ();
			tasks.AddRange (db.Table<TextTaskTable> ().ToList ());
			tasks.AddRange (db.Table<QuizTaskTable> ().ToList ());
			return tasks.OrderBy (x => x.Id).ToList ();
		}

		public TextTaskTable GetTaskById(int id)
		{
			var quizTask = db.Table<QuizTaskTable> ().SingleOrDefault (x => x.Id == id);

			if (quizTask != null) {
				return quizTask;
			}

			var navTask = db.Table<NavTaskTable> ().SingleOrDefault (x => x.Id == id);


			if (navTask != null) {
				return navTask;
			}

			return db.Table<TextTaskTable> ().Single (x => x.Id == id);
		}
	}
}