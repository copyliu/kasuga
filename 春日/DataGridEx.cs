using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace 春日
{
	public class DataGridEx : DataGrid
	{
		public readonly static DependencyProperty HiddenColumnsProperty;

		public IList<string> HiddenColumns
		{
			get
			{
				return (IList<string>)base.GetValue(DataGridEx.HiddenColumnsProperty);
			}
			set
			{
				base.SetValue(DataGridEx.HiddenColumnsProperty, value);
			}
		}

		static DataGridEx()
		{
			DataGridEx.HiddenColumnsProperty = DependencyProperty.Register("HiddenColumns", typeof(IList<string>), typeof(DataGridEx), new PropertyMetadata(new PropertyChangedCallback(DataGridEx.HiddenColumnsChanged)));
		}

		public DataGridEx()
		{
		}

		private static void HiddenColumnsChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;
			if (e.OldValue != e.NewValue)
			{
				foreach (DataGridColumn column in dataGrid.Columns)
				{
					if (!((IList<string>)e.NewValue).Contains(column.Header.ToString()))
					{
						column.Visibility = System.Windows.Visibility.Visible;
					}
					else
					{
						column.Visibility = System.Windows.Visibility.Collapsed;
					}
				}
			}
		}
	}
}