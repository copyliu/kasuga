using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace 春日
{
	public partial class ResolutionWindow : Window
	{
		private ResolutionViewModel _viewModel;

		public ResolutionWindow(ResolutionViewModel viewModel)
		{
			this.InitializeComponent();
			this._viewModel = viewModel;
			base.DataContext = this._viewModel;
		}
	}
}