using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Alia
{
	public static class GetText
	{
		public static string GetTextPageText (TaskNames textPage)
		{
			return GetTextFile (textPage.ToString ());
		}

		public static QuizButtons GetQuizButtons (TaskNames textPage)
		{
			return JsonConvert.DeserializeObject<QuizButtons> (GetTextFile (textPage.ToString ()));
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
			catch (Exception)
			{
				return string.Format("Unable to read {0} file.", fileName);
			}
		}
	}
}