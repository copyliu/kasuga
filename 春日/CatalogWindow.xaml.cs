using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace 春日
{
	public partial class CatalogWindow : Window
	{
		protected ICatalogViewModel _viewModel;

		public CatalogWindow(ICatalogViewModel viewModel)
		{
			this.InitializeComponent();
			this._viewModel = viewModel;
			base.DataContext = this._viewModel;
		}

		private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._viewModel.UpdateButtons();
		}
	}
}