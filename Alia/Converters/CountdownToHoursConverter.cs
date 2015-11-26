using System;
using Xamarin.Forms;

namespace Alia
{
	public class CountdownToHoursConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = TimeSpan.FromSeconds((double)value);

			if (timespan.TotalHours < 1.0)
			{
				return "And no more hours to waste";
			}

			return string.Format("{0:D2} Hours", timespan.Hours);
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

