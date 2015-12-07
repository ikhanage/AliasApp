using System;
using System.IO;
using Xamarin.Forms;
using Alia.Droid;

[assembly: Dependency (typeof (ILoadFile_droid))]
namespace Alia.Droid
{
	public class ILoadFile_droid : ILoadFile
	{
		public ILoadFile_droid ()
		{
		}

		public string LoadText (string filename) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}
	}
}

