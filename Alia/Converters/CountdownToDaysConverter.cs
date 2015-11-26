using System;
using Xamarin.Forms;

namespace Alia
{
	public class CountdownToDayConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = TimeSpan.FromSeconds((double)value);

			if (timespan.TotalDays < 1.0)
			{
				return "No more days with a longing heart";
			}

			return string.Format("{0:D2} Days",	timespan.Days);
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

