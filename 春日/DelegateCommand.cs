using Kasuga;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;

namespace 春日
{
	public class DelegateCommand : ICommand
	{
		public Func<object, bool> CanExecuteHandler
		{
			get;
			set;
		}

		public Action<object> ExecuteHandler
		{
			get;
			set;
		}

		public DelegateCommand()
		{
		}

		public bool CanExecute(object parameter)
		{
			bool flag;
			try
			{
				Func<object, bool> canExecuteHandler = this.CanExecuteHandler;
				flag = (canExecuteHandler != null ? canExecuteHandler(parameter) : true);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public void Execute(object parameter)
		{
			try
			{
				Action<object> executeHandler = this.ExecuteHandler;
				if (executeHandler != null)
				{
					executeHandler(parameter);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RaiseCanExecuteChanged()
		{
			try
			{
				EventHandler eventHandler = this.CanExecuteChanged;
				if (eventHandler != null)
				{
					eventHandler(this, null);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public event EventHandler CanExecuteChanged;
	}
}