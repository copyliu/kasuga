using Kasuga;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using 春日.Annotations;

namespace 春日
{
    public class ImportViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private string _fileName;

		private bool _isAdd;

		private bool _isAddEnabled;

		private string _beforeMargin;

		private string _afterMargin;

		private string _viewInterval;

		private bool _isTopBase;

		private string _baseX;

		private string _baseY;

		private string _usableWidth;

		private string _angle;

		private ObservableCollection<string> _arrangementNames;

		private string _arrangementName;

		private bool _isCenteringEnabled;

		private string _minOverlapping;

		private string _distanceToNextLine;

		private string _distanceToRuby;

		private bool _isSpacingEnabled;

		private string _spacingEnabledLabel;

		private bool _isLikeUgaWord;

		private ObservableCollection<string> _fontSetNames;

		private string _fontSetName;

		private ObservableCollection<string> _colorSetNames;

		private string _colorSetName;

		private ObservableCollection<string> _outputNames;

		private string _outputName;

		private bool _isWithoutSing;

		private ImportWindow _dialog;

		private ICommand _okCommand;

		private ICommand _cancelCommand;

		private ICommand _fileRefCommand;
        private bool _istxt2Ass;
        private List<string> _fileEncodingList;
        private string _fileEncoding;

        public string FileEncoding
        {
            get { return _fileEncoding; }
            set
            {
                if (value == _fileEncoding) return;
                _fileEncoding = value;
                RaisePropertyChanged("FileEncoding");
            }
        }

        public List<string> FileEncodingList
        {
            get { return _fileEncodingList; }
            set
            {
                if (Equals(value, _fileEncodingList)) return;
                _fileEncodingList = value;
                RaisePropertyChanged("FileEncodingList");
            }
        }

        public bool Istxt2ass
        {
            get { return _istxt2Ass; }
            set
            {
                if (value.Equals(_istxt2Ass)) return;
                _istxt2Ass = value;
                RaisePropertyChanged("Istxt2ass");
            }
        }

        public string AfterMargin
		{
			get
			{
				string empty;
				try
				{
					empty = this._afterMargin;
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
					if (this._afterMargin != value)
					{
						this._afterMargin = value;
						this.RaisePropertyChanged("AfterMargin");
						this.RaisePropertyChanged("HasAfterMarginError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Angle
		{
			get
			{
				string empty;
				try
				{
					empty = this._angle;
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
					if (this._angle != value)
					{
						this._angle = value;
						this.RaisePropertyChanged("Angle");
						this.RaisePropertyChanged("HasAngleError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ArrangementName
		{
			get
			{
				string empty;
				try
				{
					empty = this._arrangementName;
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
					if (this._arrangementName != value)
					{
						this._arrangementName = value;
						this.RaisePropertyChanged("ColorSetName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> ArrangementNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._arrangementNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public string BaseX
		{
			get
			{
				string empty;
				try
				{
					empty = this._baseX;
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
					if (this._baseX != value)
					{
						this._baseX = value;
						this.RaisePropertyChanged("BaseX");
						this.RaisePropertyChanged("HasBaseXError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string BaseY
		{
			get
			{
				string empty;
				try
				{
					empty = this._baseY;
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
					if (this._baseY != value)
					{
						this._baseY = value;
						this.RaisePropertyChanged("BaseY");
						this.RaisePropertyChanged("HasBaseYError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string BeforeMargin
		{
			get
			{
				string empty;
				try
				{
					empty = this._beforeMargin;
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
					if (this._beforeMargin != value)
					{
						this._beforeMargin = value;
						this.RaisePropertyChanged("BeforeMargin");
						this.RaisePropertyChanged("HasBeforeMarginError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
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

		public string ColorSetName
		{
			get
			{
				string empty;
				try
				{
					empty = this._colorSetName;
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
					if (this._colorSetName != value)
					{
						this._colorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> ColorSetNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._colorSetNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public string DistanceToNextLine
		{
			get
			{
				string empty;
				try
				{
					empty = this._distanceToNextLine;
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
					if (this._distanceToNextLine != value)
					{
						this._distanceToNextLine = value;
						this.RaisePropertyChanged("DistanceToNextLine");
						this.RaisePropertyChanged("HasDistanceToNextLineError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string DistanceToRuby
		{
			get
			{
				string empty;
				try
				{
					empty = this._distanceToRuby;
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
					if (this._distanceToRuby != value)
					{
						this._distanceToRuby = value;
						this.RaisePropertyChanged("DistanceToRuby");
						this.RaisePropertyChanged("HasDistanceToRubyError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string FileName
		{
			get
			{
				string empty;
				try
				{
					empty = this._fileName;
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
					if (this._fileName != value)
					{
						this._fileName = value;
						this.RaisePropertyChanged("FileName");
						this.RaisePropertyChanged("HasFileNameError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ICommand FileRefCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._fileRefCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.FileRefCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.FileRefCommandCanExecute)
						};
						this._fileRefCommand = delegateCommand;
					}
					command = this._fileRefCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public string FontSetName
		{
			get
			{
				string empty;
				try
				{
					empty = this._fontSetName;
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
					if (this._fontSetName != value)
					{
						this._fontSetName = value;
						this.RaisePropertyChanged("FontExName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> FontSetNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._fontSetNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public bool HasAfterMarginError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.AfterMargin, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasAngleError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.Angle, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasBaseXError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.BaseX, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasBaseYError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.BaseY, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasBeforeMarginError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.BeforeMargin, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasDistanceToNextLineError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.DistanceToNextLine, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasDistanceToRubyError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.DistanceToRuby, true, true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasFileNameError
		{
			get
			{
				bool flag;
				try
				{
					flag = !File.Exists(this.FileName);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasMinOverlappingError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.MinOverlapping, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasUsableWidthError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.UsableWidth, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasViewIntervalError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.ViewInterval, true, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public Kasuga.ImportInfo ImportInfo
		{
			get
			{
				Kasuga.ImportInfo importInfo;
				try
				{
				    importInfo = new Kasuga.ImportInfo(this.FileName, this.IsAdd,
				        new PlayTimeSpan(new double?(double.Parse(this.BeforeMargin))),
				        new PlayTimeSpan(new double?(double.Parse(this.AfterMargin))),
				        new PlayTimeSpan(new double?(double.Parse(this.ViewInterval))), this.IsTopBase,
				        new Point(double.Parse(this.BaseX), double.Parse(this.BaseY)), double.Parse(this.UsableWidth),
				        double.Parse(this.Angle), this.ArrangementName, this.IsCenteringEnabled, double.Parse(this.MinOverlapping),
				        double.Parse(this.DistanceToNextLine), double.Parse(this.DistanceToRuby), this.IsSpacingEnabled,
				        this.IsLikeUgaWord, this.FontSetName, this.ColorSetName, this.OutputName, this.IsWithoutSing, this.Istxt2ass,
				        this.FileEncoding);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					importInfo = null;
				}
				return importInfo;
			}
		}

		public bool IsAdd
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isAdd;
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
					if (this._isAdd != value)
					{
						this._isAdd = value;
						this.RaisePropertyChanged("IsAdd");
						this.RaisePropertyChanged("IsNew");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsAddEnabled
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isAddEnabled;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool IsBottomBase
		{
			get
			{
				bool flag;
				try
				{
					flag = !this._isTopBase;
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
					if (this._isTopBase != !value)
					{
						this._isTopBase = !value;
						this.RaisePropertyChanged("IsTopBase");
						this.RaisePropertyChanged("IsBottomBase");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsCenteringEnabled
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isCenteringEnabled;
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
					if (this._isCenteringEnabled != value)
					{
						this._isCenteringEnabled = value;
						this.RaisePropertyChanged("IsCenteringEnabled");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsLikeUgaWord
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isLikeUgaWord;
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
					if (this._isLikeUgaWord != value)
					{
						this._isLikeUgaWord = value;
						if (!value)
						{
							this._spacingEnabledLabel = "ルビの均等割り付け";
						}
						else
						{
							this._spacingEnabledLabel = "本文/ルビの均等割り付け";
						}
						this.RaisePropertyChanged("IsLikeUgaWord");
						this.RaisePropertyChanged("SpacingEnabledLabel");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsNew
		{
			get
			{
				bool flag;
				try
				{
					flag = !this._isAdd;
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
					if (this._isAdd != !value)
					{
						this._isAdd = !value;
						this.RaisePropertyChanged("IsAdd");
						this.RaisePropertyChanged("IsNew");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsSpacingEnabled
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isSpacingEnabled;
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
					if (this._isSpacingEnabled != value)
					{
						this._isSpacingEnabled = value;
						this.RaisePropertyChanged("IsSpacingEnabled");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsTopBase
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isTopBase;
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
					if (this._isTopBase != value)
					{
						this._isTopBase = value;
						this.RaisePropertyChanged("IsTopBase");
						this.RaisePropertyChanged("IsBottomBase");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsWithoutSing
		{
			get
			{
				bool flag;
				try
				{
					flag = this._isWithoutSing;
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
					if (this._isWithoutSing != value)
					{
						this._isWithoutSing = value;
						this.RaisePropertyChanged("IsWithoutSing");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string MinOverlapping
		{
			get
			{
				string empty;
				try
				{
					empty = this._minOverlapping;
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
					if (this._minOverlapping != value)
					{
						this._minOverlapping = value;
						this.RaisePropertyChanged("MinOverlapping");
						this.RaisePropertyChanged("HasMinOverlappingError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
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

		public string OutputName
		{
			get
			{
				string empty;
				try
				{
					empty = this._outputName;
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
					if (this._outputName != value)
					{
						this._outputName = value;
						this.RaisePropertyChanged("EffectName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> OutputNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._outputNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public string SpacingEnabledLabel
		{
			get
			{
				string empty;
				try
				{
					empty = this._spacingEnabledLabel;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public string UsableWidth
		{
			get
			{
				string empty;
				try
				{
					empty = this._usableWidth;
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
					if (this._usableWidth != value)
					{
						this._usableWidth = value;
						this.RaisePropertyChanged("UsableWidth");
						this.RaisePropertyChanged("HasUsableWidthError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ViewInterval
		{
			get
			{
				string empty;
				try
				{
					empty = this._viewInterval;
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
					if (this._viewInterval != value)
					{
						this._viewInterval = value;
						this.RaisePropertyChanged("ViewInterval");
						this.RaisePropertyChanged("HasViewIntervalError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ImportViewModel(int partsCount, Catalog<FontSet> fontSetCatalog, Catalog<ColorSet> colorSetCatalog, Catalog<BasicOutput> outputCatalog)
		{
			try
			{
				this._fileName = string.Empty;
				this._isAdd = false;
				if (partsCount <= 0)
				{
					this._isAddEnabled = false;
				}
				else
				{
					this._isAddEnabled = true;
				}
				this._beforeMargin = "1.20";
				this._afterMargin = "0.20";
				this._viewInterval = "0.30";
				this._isTopBase = false;
				this._baseX = "65.0";
				this._baseY = "430.0";
				this._usableWidth = "510.0";
				this._angle = "0.0";
				this._arrangementNames = new ObservableCollection<string>()
				{
					ArrangementLikeJoy.TypeName,
					LineHeadArrangement.TypeName
				};
				this._arrangementName = this._arrangementNames[0];
				this._isCenteringEnabled = true;
				this._minOverlapping = "35.0";
				this._distanceToNextLine = "82.0";
				this._distanceToRuby = "-25.0";
				this._isSpacingEnabled = true;
				this._spacingEnabledLabel = "ルビの均等割り付け";
				this._isLikeUgaWord = false;
				this._fontSetNames = new ObservableCollection<string>();
				foreach (string name in fontSetCatalog.Names)
				{
					this._fontSetNames.Add(name);
				}
				this._fontSetName = this._fontSetNames[0];
				this._colorSetNames = new ObservableCollection<string>();
				foreach (string str in colorSetCatalog.Names)
				{
					this._colorSetNames.Add(str);
				}
				this._colorSetName = this._colorSetNames[0];
				this._outputNames = new ObservableCollection<string>();
				foreach (string name1 in outputCatalog.Names)
				{
					this._outputNames.Add(name1);
				}
				this._outputName = this._outputNames[0];
				this._isWithoutSing = false;
			    this._istxt2Ass = false;
                this._fileEncodingList=new List<string>(){"SHIFT-JIS","UTF-8","GBK","BIG5"};
			    this._fileEncoding = "SHIFT-JIS";
				this._dialog = new ImportWindow(this);
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

		private bool FileRefCommandCanExecute(object parameter)
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

		private void FileRefCommandExecute(object parameter)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog()
				{
					Filter = "テキストファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*"
				};
				bool? nullable = openFileDialog.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.FileName = openFileDialog.FileName;
				}
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
				flag = (this.HasFileNameError || this.HasBeforeMarginError || this.HasAfterMarginError || this.HasViewIntervalError || this.HasBaseXError || this.HasBaseYError || this.HasUsableWidthError || this.HasAngleError || this.HasMinOverlappingError || this.HasDistanceToNextLineError ? false : !this.HasDistanceToRubyError);
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

        [NotifyPropertyChangedInvocator]
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