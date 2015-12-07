using Xamarin.Forms;
using Alia.iOS;
using System;
using System.IO;

[assembly: Dependency (typeof (ISQLite_ios))]
namespace Alia.iOS
{
	public class ISQLite_ios : ISQLite
	{
		public ISQLite_ios (){	}

		public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "AliasAppSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); 
			var path = Path.Combine(libraryPath, sqliteFilename);

			var conn = new SQLite.SQLiteConnection(path);

			return conn;
		}
	}
}