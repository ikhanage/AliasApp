using System;
using System.IO;
using Xamarin.Forms;
using System.Reflection;

namespace Alia
{
	public static class GetText
	{
		public static string GetTextPageText (TaskNames textPage)
		{
			return GetTextFile (textPage.ToString ());
		}

		public static string GetQuizPageText (PageTypes quizPage)
		{
			throw new NotImplementedException ();
		}

		public static string GetNavPageText (PageTypes navPage)
		{
			throw new NotImplementedException ();
		}

		static string GetTextFile (string fileName)
		{
			try
			{
				var assembly = typeof(TaskPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(string.Format("Alia.TaskTextFiles.{0}.txt", fileName));
				string text = "";
				using (var reader = new StreamReader (stream)) {
					text = reader.ReadToEnd ();
				}

				return text;
			}
			catch (Exception e)
			{
				return string.Format("Unable to read {0} file.", fileName);
			}
		}
	}
}