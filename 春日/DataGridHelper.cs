using Kasuga;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace 春日
{
	public class DataGridHelper
	{
		public DataGridHelper()
		{
		}

		protected static DataGridCell GetCell(DataGridCellInfo cellInfo)
		{
			DataGridCell parent;
			try
			{
				if (cellInfo.IsValid)
				{
					FrameworkElement cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
					if (cellContent != null)
					{
						parent = (DataGridCell)cellContent.Parent;
					}
					else
					{
						parent = null;
					}
				}
				else
				{
					parent = null;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				parent = null;
			}
			return parent;
		}

		public static int GetCurrentRowIndex(DataGrid dataGrid)
		{
			int num;
			try
			{
				DataGridCell cell = 春日.DataGridHelper.GetCell(dataGrid.CurrentCell);
				if (cell != null)
				{
					PropertyInfo property = cell.GetType().GetProperty("RowDataItem", BindingFlags.Instance | BindingFlags.NonPublic);
					num = dataGrid.Items.IndexOf(property.GetValue(cell, null));
				}
				else
				{
					num = -1;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				num = 0;
			}
			return num;
		}
	}
}