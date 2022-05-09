using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DungeonCrawler
{
	// Token: 0x02000063 RID: 99
	public class NegativeVisibilityConverter : IValueConverter
	{
		// Token: 0x060002CF RID: 719 RVA: 0x0001A5EC File Offset: 0x000187EC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Visibility.Collapsed : Visibility.Visible;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000943F File Offset: 0x0000763F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
