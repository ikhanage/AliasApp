using System;
using System.IO;
using Xamarin.Forms;
using Alia.Droid;

[assembly: Dependency (typeof (SQLite_droid))]
namespace Alia.Droid
{
	public class SQLite_droid : ISQLite {
		public SQLite_droid () {}

		public SQLite.SQLiteConnection GetConnection () {
			var sqliteFilename = "AliasAppSQLite.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}}
}