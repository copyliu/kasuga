using System.Windows.Input;

namespace 春日
{
	public interface IDialogViewModel
	{
		ICommand CancelCommand
		{
			get;
		}

		ICommand OkCommand
		{
			get;
		}
	}
}