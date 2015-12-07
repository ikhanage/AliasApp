using Xamarin.Forms;
using SQLite;

namespace Alia
{
	public class DatabaseSetUp
	{
		readonly SQLiteConnection db;

		public DatabaseSetUp()
		{
			db = DependencyService.Get<ISQLite> ().GetConnection ();
		}

		public void CreateDBTables ()
		{
			db.CreateTable<TaskTable> ();
			db.CreateTable<NavTaskTable> ();
			db.CreateTable<QuizTaskTable> ();
		}

		public void DestoryTables()
		{			
			db.DropTable<TaskTable> ();
			db.DropTable<NavTaskTable> ();
			db.DropTable<QuizTaskTable> ();
		}

		public void SetUpTasks()
		{
			//db.InsertAll (SetUpDatabaseTasks.SetUpNavTasks ());
			//db.InsertAll (SetUpDatabaseTasks.SetUpQuizTasks ());
			db.InsertAll (SetUpDatabaseTasks.SetUpTextTask ());

			var test = db.Table<TaskTable> ().Where(x => x.Id == 1);
		}
	}
}