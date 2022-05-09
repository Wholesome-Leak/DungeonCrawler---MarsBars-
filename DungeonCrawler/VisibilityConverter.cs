using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DungeonCrawler
{
	// Token: 0x0200005A RID: 90
	public class VisibilityConverter : IValueConverter
	{
		// Token: 0x06000289 RID: 649 RVA: 0x00018EF4 File Offset: 0x000170F4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object result;
			if (value == null)
			{
				result = Visibility.Collapsed;
			}
			else
			{
				result = Visibility.Visible;
			}
			return result;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000943F File Offset: 0x0000763F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
