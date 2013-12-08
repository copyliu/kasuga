using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace 春日
{
	public class FontExViewModel : INotifyPropertyChanged
	{
		private string _familyName;

		private string _size;

		private bool _isBold;

		private bool _isItalic;

		private bool _hasUnderline;

		private bool _hasStrikeout;

		private string _scaleX;

		private string _scaleY;

		private string _borderWidth;

		private string _shadowDepth;

		private IDialogViewModel _parentalViewModel;

		public string BorderWidth
		{
			get
			{
				string empty;
				try
				{
					empty = this._borderWidth;
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
					if (this._borderWidth != value)
					{
						this._borderWidth = value;
						this.RaisePropertyChanged("BorderWidth");
						this.RaisePropertyChanged("HasBorderWidthError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string FamilyName
		{
			get
			{
				string empty;
				try
				{
					empty = this._familyName;
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
					if (this._familyName != value)
					{
						this._familyName = value;
						this.RaisePropertyChanged("FamilyName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public Kasuga.FontEx FontEx
		{
			get
			{
				Kasuga.FontEx fontEx;
				try
				{
					fontEx = new Kasuga.FontEx(this.FamilyName, double.Parse(this.Size), this.IsBold, this.IsItalic, this.HasUnderline, this.HasStrikeout, double.Parse(this.ScaleX), double.Parse(this.ScaleY), double.Parse(this.BorderWidth), double.Parse(this.ShadowDepth));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontEx = null;
				}
				return fontEx;
			}
		}

		public bool HasBorderWidthError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.BorderWidth, true, false);
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
					flag = (this.HasSizeError || this.HasScaleXError || this.HasScaleYError || this.HasBorderWidthError ? true : this.HasShadowDepthError);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasScaleXError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.ScaleX, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasScaleYError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.ScaleY, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasShadowDepthError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.ShadowDepth, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasSizeError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.Size, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasStrikeout
		{
			get
			{
				bool flag;
				try
				{
					flag = this._hasStrikeout;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._hasStrikeout != value)
					{
						this._hasStrikeout = value;
						this.RaisePropertyChanged("HasStrikeout");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool HasUnderline
		{
			get
			{
				bool flag;
				try
				{
					flag = this._hasUnderline;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._hasUnderline != value)
					{
						this._hasUnderline = value;
						this.RaisePropertyChanged("HasUnderline");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsBold
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isBold;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._isBold != value)
					{
						this._isBold = value;
						this.RaisePropertyChanged("IsBold");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsItalic
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isItalic;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._isItalic != value)
					{
						this._isItalic = value;
						this.RaisePropertyChanged("IsItalic");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ScaleX
		{
			get
			{
				string empty;
				try
				{
					empty = this._scaleX;
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
					if (this._scaleX != value)
					{
						this._scaleX = value;
						this.RaisePropertyChanged("ScaleX");
						this.RaisePropertyChanged("HasScaleXError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ScaleY
		{
			get
			{
				string empty;
				try
				{
					empty = this._scaleY;
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
					if (this._scaleY != value)
					{
						this._scaleY = value;
						this.RaisePropertyChanged("ScaleY");
						this.RaisePropertyChanged("HasScaleYError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ShadowDepth
		{
			get
			{
				string empty;
				try
				{
					empty = this._shadowDepth;
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
					if (this._shadowDepth != value)
					{
						this._shadowDepth = value;
						this.RaisePropertyChanged("ShadowDepth");
						this.RaisePropertyChanged("HasShadowDepthError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Size
		{
			get
			{
				string empty;
				try
				{
					empty = this._size;
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
					if (this._size != value)
					{
						this._size = value;
						this.RaisePropertyChanged("Size");
						this.RaisePropertyChanged("HasSizeError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public FontExViewModel(Kasuga.FontEx fontEx, IDialogViewModel parentalViewModel)
		{
			try
			{
				this._familyName = fontEx.FamilyName;
				this._size = fontEx.Size.ToString();
				this._isBold = fontEx.IsBold;
				this._isItalic = fontEx.IsItalic;
				this._hasUnderline = fontEx.HasUnderline;
				this._hasStrikeout = fontEx.HasStrikeout;
				this._scaleX = fontEx.ScaleX.ToString();
				this._scaleY = fontEx.ScaleY.ToString();
				this._borderWidth = fontEx.BorderWidth.ToString();
				this._shadowDepth = fontEx.ShadowDepth.ToString();
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