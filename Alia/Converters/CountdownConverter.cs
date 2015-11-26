using System;
using Xamarin.Forms;

namespace Alia
{
	public class CountdownConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = TimeSpan.FromSeconds((double)value);

			if (timespan.TotalSeconds < 1.0)
			{
				return "-- : --";
			}

			return string.Format("{0:D2} {1:D2} : {2:D2} : {3:D2}",
				timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds);
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}

