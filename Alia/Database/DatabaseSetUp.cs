using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;

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
			db.CreateTable<TextTaskTable> ();
			db.CreateTable<NavTaskTable> ();
			db.CreateTable<QuizTaskTable> ();
		}

		public void DestoryTables()
		{			
			db.DropTable<TextTaskTable> ();
			db.DropTable<NavTaskTable> ();
			db.DropTable<QuizTaskTable> ();
		}

		public void SetUpTasks()
		{
			//db.InsertAll (SetUpDatabaseTasks.SetUpNavTasks ());
			db.InsertAll (SetUpDatabaseTasks.SetUpTextTask ());
			db.InsertAll (SetUpDatabaseTasks.SetUpQuizTasks ());
		}

		void SaveQuizTasks(List<QuizTaskTable> quizTasks)
		{

		}
	}
}