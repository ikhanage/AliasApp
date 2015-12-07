using System;
using System.IO;
using Xamarin.Forms;
using Alia.iOS;

[assembly: Dependency (typeof (ILoadFile_ios))]
namespace Alia.iOS
{
	public class ILoadFile_ios : ILoadFile
	{
		public ILoadFile_ios ()
		{
		}

		public string LoadText (string filename) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}
	}
}

