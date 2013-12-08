using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace 春日
{
	public partial class ConfigWindow : Window
	{
		private ConfigViewModel _viewModel;

		public ConfigWindow(ConfigViewModel viewModel)
		{
			this.InitializeComponent();
			this._viewModel = viewModel;
			base.DataContext = this._viewModel;
		}
	}
}