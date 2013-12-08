using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace 春日
{
	public class LeadEffectViewModel : INotifyPropertyChanged
	{
		private string _offset;

		private string _duration;

		private string _speed;

		private string _expression;

		private IDialogViewModel _parentalViewModel;

		public string Duration
		{
			get
			{
				string empty;
				try
				{
					empty = this._duration;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this._duration != value)
					{
						this._duration = value;
						this.RaisePropertyChanged("Duration");
						this.RaisePropertyChanged("HasDurationError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Expression
		{
			get
			{
				string empty;
				try
				{
					empty = this._expression;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this._expression != value)
					{
						this._expression = value;
						this.RaisePropertyChanged("Expression");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool HasDurationError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.Duration, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasError
		{
			get
			{
				bool flag;
				try
				{
					flag = (this.HasOffsetError || this.HasDurationError ? true : this.HasSpeedError);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasOffsetError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.Offset, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasSpeedError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.Speed, false, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public Kasuga.LeadEffect LeadEffect
		{
			get
			{
				Kasuga.LeadEffect leadEffect;
				try
				{
					leadEffect = new Kasuga.LeadEffect(new PlayTimeSpan(new double?(double.Parse(this.Offset))), new PlayTimeSpan(new double?(double.Parse(this.Duration))), double.Parse(this.Speed), this.Expression);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffect = null;
				}
				return leadEffect;
			}
		}

		public string Offset
		{
			get
			{
				string empty;
				try
				{
					empty = this._offset;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this._offset != value)
					{
						this._offset = value;
						this.RaisePropertyChanged("Offset");
						this.RaisePropertyChanged("HasOffsetError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Speed
		{
			get
			{
				string empty;
				try
				{
					empty = this._speed;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this._speed != value)
					{
						this._speed = value;
						this.RaisePropertyChanged("Speed");
						this.RaisePropertyChanged("HasSpeedError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public LeadEffectViewModel(Kasuga.LeadEffect leadEffect, IDialogViewModel parentalViewModel)
		{
			try
			{
				this._offset = leadEffect.Offset.SecondsString;
				this._duration = leadEffect.Duration.SecondsString;
				this._speed = leadEffect.Speed.ToString();
				this._expression = leadEffect.Expression;
				this._parentalViewModel = parentalViewModel;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		protected void RaisePropertyChanged(string propertyName)
		{
			try
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}