using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace 春日
{
	public partial class MainWindow : Window
	{
		private MainViewModel _viewModel;

		public MainWindow()
		{
			this.InitializeComponent();
			this._viewModel = new MainViewModel(this);
			base.DataContext = this._viewModel;
		}

		private void charactorsDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			this._viewModel.ArrangeTextFromCharactorsGrid();
		}

		private void linesDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			this._viewModel.ArrangeTextFromLinesGrid();
		}

		private void pagesDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			this._viewModel.ArrangeTextFromPagesGrid();
		}

		private void pagesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._viewModel.UpdatePagesContextMenu();
		}

		private void partsDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			this._viewModel.ArrangeTextFromPartsGrid();
		}

		private void wordsDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			this._viewModel.ArrangeTextFromWordsGrid();
		}

		private void wordsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._viewModel.UpdateWordsContextMenu();
		}
	}
}