using Kasuga;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class ColorAlphaViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private byte _r;

		private byte _g;

		private byte _b;

		private byte _a;

		private string _rStr;

		private string _gStr;

		private string _bStr;

		private string _aStr;

		private ColorAlphaWindow _dialog;

		private ICommand _okCommand;

		private ICommand _cancelCommand;

		public byte A
		{
			get
			{
				byte num;
				try
				{
					num = this._a;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					if (this._a != value)
					{
						this._a = value;
						this.RaisePropertyChanged("A");
						this.RaisePropertyChanged("ColorAlpha");
						this.RaisePropertyChanged("Abgr");
						this.AStr = value.ToString();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Abgr
		{
			get
			{
				string colorAlphaString;
				try
				{
					colorAlphaString = this.ColorAlpha.ColorAlphaString;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorAlphaString = string.Empty;
				}
				return colorAlphaString;
			}
			set
			{
				try
				{
					if (this.ColorAlpha.ColorAlphaString != value)
					{
						this.RaisePropertyChanged("Abgr");
						this.RaisePropertyChanged("HasAbgrError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasAbgrError)
						{
							Match match = (new Regex("\\A\\&H([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})\\&\\z")).Match(value);
							if (match.Success)
							{
								this.A = byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber);
								this.B = byte.Parse(match.Groups[2].Value, NumberStyles.HexNumber);
								this.G = byte.Parse(match.Groups[3].Value, NumberStyles.HexNumber);
								this.R = byte.Parse(match.Groups[4].Value, NumberStyles.HexNumber);
							}
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string AStr
		{
			get
			{
				string empty;
				try
				{
					empty = this._aStr;
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
					if (this._aStr != value)
					{
						this._aStr = value;
						this.RaisePropertyChanged("AStr");
						this.RaisePropertyChanged("HasAError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasAError)
						{
							this.A = byte.Parse(value);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public byte B
		{
			get
			{
				byte num;
				try
				{
					num = this._b;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					if (this._b != value)
					{
						this._b = value;
						this.RaisePropertyChanged("B");
						this.RaisePropertyChanged("ColorAlpha");
						this.RaisePropertyChanged("Abgr");
						this.BStr = value.ToString();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string BStr
		{
			get
			{
				string empty;
				try
				{
					empty = this._bStr;
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
					if (this._bStr != value)
					{
						this._bStr = value;
						this.RaisePropertyChanged("BStr");
						this.RaisePropertyChanged("HasBError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasBError)
						{
							this.B = byte.Parse(value);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ICommand CancelCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._cancelCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.CancelCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.CancelCommandCanExecute)
						};
						this._cancelCommand = delegateCommand;
					}
					command = this._cancelCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public Kasuga.ColorAlpha ColorAlpha
		{
			get
			{
				Kasuga.ColorAlpha colorAlpha;
				try
				{
					colorAlpha = new Kasuga.ColorAlpha(this.A, this.B, this.G, this.R);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorAlpha = Kasuga.ColorAlpha.MinValue;
				}
				return colorAlpha;
			}
		}

		public byte G
		{
			get
			{
				byte num;
				try
				{
					num = this._g;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					if (this._g != value)
					{
						this._g = value;
						this.RaisePropertyChanged("G");
						this.RaisePropertyChanged("ColorAlpha");
						this.RaisePropertyChanged("Abgr");
						this.GStr = value.ToString();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string GStr
		{
			get
			{
				string empty;
				try
				{
					empty = this._gStr;
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
					if (this._gStr != value)
					{
						this._gStr = value;
						this.RaisePropertyChanged("GStr");
						this.RaisePropertyChanged("HasGError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasGError)
						{
							this.G = byte.Parse(value);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool HasAbgrError
		{
			get
			{
				bool flag;
				try
				{
					Regex regex = new Regex("\\A\\&H[0-9A-Fa-f]{8}\\&\\z");
					flag = !regex.IsMatch(this.Abgr);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasAError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.ByteValidate(this.AStr);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasBError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.ByteValidate(this.BStr);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasGError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.ByteValidate(this.GStr);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasRError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.ByteValidate(this.RStr);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public ICommand OkCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._okCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.OkCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.OkCommandCanExecute)
						};
						this._okCommand = delegateCommand;
					}
					command = this._okCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public byte R
		{
			get
			{
				byte num;
				try
				{
					num = this._r;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					if (this._r != value)
					{
						this._r = value;
						this.RaisePropertyChanged("R");
						this.RaisePropertyChanged("ColorAlpha");
						this.RaisePropertyChanged("Abgr");
						this.RStr = value.ToString();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string RStr
		{
			get
			{
				string empty;
				try
				{
					empty = this._rStr;
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
					if (this._rStr != value)
					{
						this._rStr = value;
						this.RaisePropertyChanged("RStr");
						this.RaisePropertyChanged("HasRError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasRError)
						{
							this.R = byte.Parse(value);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ColorAlphaViewModel(Kasuga.ColorAlpha colorAlpha)
		{
			try
			{
				this._r = colorAlpha.R;
				this._rStr = colorAlpha.R.ToString();
				this._g = colorAlpha.G;
				this._gStr = colorAlpha.G.ToString();
				this._b = colorAlpha.B;
				this._bStr = colorAlpha.B.ToString();
				this._a = colorAlpha.A;
				this._aStr = colorAlpha.A.ToString();
				this._dialog = new ColorAlphaWindow(this);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool CancelCommandCanExecute(object parameter)
		{
			bool flag;
			try
			{
				flag = true;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		private void CancelCommandExecute(object parameter)
		{
			try
			{
				this._dialog.DialogResult = new bool?(false);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool OkCommandCanExecute(object parameter)
		{
			bool flag;
			try
			{
				flag = (this.HasRError || this.HasGError || this.HasBError || this.HasAError ? false : !this.HasAbgrError);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		private void OkCommandExecute(object parameter)
		{
			try
			{
				this._dialog.DialogResult = new bool?(true);
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

		public bool? ShowDialog()
		{
			bool? nullable;
			try
			{
				nullable = this._dialog.ShowDialog();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				nullable = new bool?(false);
			}
			return nullable;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}