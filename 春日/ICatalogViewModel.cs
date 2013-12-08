using System;
using System.ComponentModel;
using System.Windows.Input;

namespace 春日
{
	public interface ICatalogViewModel : INotifyPropertyChanged
	{
		ICommand CloseCommand
		{
			get;
		}

		ICommand CopyCommand
		{
			get;
		}

		ICommand DeleteCommand
		{
			get;
		}

		ICommand EditCommand
		{
			get;
		}

		ICommand NewCommand
		{
			get;
		}

		string WindowTitle
		{
			get;
		}

		void UpdateButtons();
	}
}