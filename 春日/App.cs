using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace 春日
{
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public class App : Application
	{
		public App()
		{
		}

		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			base.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
		}

		[DebuggerNonUserCode]
		[STAThread]
		public static void Main()
		{
			App app = new App();
			app.InitializeComponent();
			app.Run();
		}
	}
}