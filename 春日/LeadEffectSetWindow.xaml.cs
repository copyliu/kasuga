using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace 春日
{
	public partial class LeadEffectSetWindow : Window
	{
		private LeadEffectSetViewModel _viewModel;

		public LeadEffectSetWindow(LeadEffectSetViewModel viewModel)
		{
			this.InitializeComponent();
			this._viewModel = viewModel;
			base.DataContext = this._viewModel;
		}
	}
}