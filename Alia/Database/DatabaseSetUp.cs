using System;
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

		public static void CreateDBTables ()
		{
			db.CreateTable<TaskTable> ();
			db.CreateTable<NavTaskTable> ();
			db.CreateTable<QuizTaskTable> ();
		}

		public static void DestoryTables()
		{
			db.DropTable<TaskTable> ();
			db.DropTable<NavTaskTable> ();
			db.DropTable<QuizTaskTable> ();
		}
	}
}