using System;
using Xamarin.Forms;

namespace Alia
{
	public class CountdownToSecondsConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = TimeSpan.FromSeconds((double)value);

			if (timespan.TotalSeconds < 1.0)
			{
				return "Not a second more to race";
			}

			return string.Format("{0:D2} Seconds",	timespan.Seconds);
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

