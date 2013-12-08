using Kasuga;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace 春日
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private Kasuga.Sub _sub;

		private 春日.Config _config;

		private MainWindow _window;

		private string _fileName;

		private ICommand _openCommand;

		private ICommand _saveCommand;

		private ICommand _saveAsCommand;

		private ICommand _importTimeTaggedTextCommand;

		private ICommand _exportToAssCommand;

		private ICommand _closeCommand;

		private ICommand _configCommand;

		private ICommand _changeResolutionCommand;

		private ICommand _showFontCatalogCommand;

		private ICommand _showColorCatalogCommand;

		private ICommand _showOutputCatalogCommand;

		private ICommand _showVersionInfoCommand;

		private ICommand _joinPagesCommand;

		private ICommand _splitPageCommand;

		private ICommand _joinWordsCommand;

		private ICommand _splitWordCommand;

		public ICommand ChangeResolutionCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._changeResolutionCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ChangeResolutionCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ChangeResolutionCommandCanExecute)
						};
						this._changeResolutionCommand = delegateCommand;
					}
					command = this._changeResolutionCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ObservableCollection<CharactorViewModel> Charactors
		{
			get
			{
				ObservableCollection<CharactorViewModel> observableCollection;
				try
				{
					ObservableCollection<CharactorViewModel> observableCollection1 = new ObservableCollection<CharactorViewModel>();
					foreach (Charactor charactor in this.Sub.Charactors)
					{
						observableCollection1.Add(new CharactorViewModel(charactor, this));
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public ICommand CloseCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._closeCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.CloseCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.CloseCommandCanExecute)
						};
						this._closeCommand = delegateCommand;
					}
					command = this._closeCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public 春日.Config Config
		{
			get
			{
				春日.Config config;
				try
				{
					config = this._config;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					config = null;
				}
				return config;
			}
		}

		public ICommand ConfigCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._configCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ConfigCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ConfigCommandCanExecute)
						};
						this._configCommand = delegateCommand;
					}
					command = this._configCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand ExportToAssCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._exportToAssCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ExportToAssCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ExportToAssCommandCanExecute)
						};
						this._exportToAssCommand = delegateCommand;
					}
					command = this._exportToAssCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public Size FrameSize
		{
			get
			{
				Size size;
				try
				{
					Size resolution = this.Sub.Resolution;
					double width = resolution.Width * this.Config.ViewRatio;
					Size resolution1 = this.Sub.Resolution;
					size = new Size(width, resolution1.Height * this.Config.ViewRatio);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = Size.Empty;
				}
				return size;
			}
		}

		public ICommand ImportTimeTaggedTextCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._importTimeTaggedTextCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ImportTimeTaggedTextCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ImportTimeTaggedTextCommandCanExecute)
						};
						this._importTimeTaggedTextCommand = delegateCommand;
					}
					command = this._importTimeTaggedTextCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand JoinPagesCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._joinPagesCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.JoinPagesCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.JoinPagesCommandCanExecute)
						};
						this._joinPagesCommand = delegateCommand;
					}
					command = this._joinPagesCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand JoinWordsCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._joinWordsCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.JoinWordsCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.JoinWordsCommandCanExecute)
						};
						this._joinWordsCommand = delegateCommand;
					}
					command = this._joinWordsCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ObservableCollection<LineViewModel> Lines
		{
			get
			{
				ObservableCollection<LineViewModel> observableCollection;
				try
				{
					ObservableCollection<LineViewModel> observableCollection1 = new ObservableCollection<LineViewModel>();
					foreach (Line line in this.Sub.Lines)
					{
						observableCollection1.Add(new LineViewModel(line, this));
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public ICommand OpenCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._openCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.OpenCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.OpenCommandCanExecute)
						};
						this._openCommand = delegateCommand;
					}
					command = this._openCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ObservableCollection<PageViewModel> Pages
		{
			get
			{
				ObservableCollection<PageViewModel> observableCollection;
				try
				{
					ObservableCollection<PageViewModel> observableCollection1 = new ObservableCollection<PageViewModel>();
					foreach (Kasuga.Page page in this.Sub.Pages)
					{
						observableCollection1.Add(new PageViewModel(page, this));
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public ObservableCollection<PartViewModel> Parts
		{
			get
			{
				ObservableCollection<PartViewModel> observableCollection;
				try
				{
					ObservableCollection<PartViewModel> observableCollection1 = new ObservableCollection<PartViewModel>();
					foreach (Part part in this.Sub.Parts)
					{
						observableCollection1.Add(new PartViewModel(part, this));
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public ICommand SaveAsCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._saveAsCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.SaveAsCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.SaveAsCommandCanExecute)
						};
						this._saveAsCommand = delegateCommand;
					}
					command = this._saveAsCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand SaveCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._saveCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.SaveCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.SaveCommandCanExecute)
						};
						this._saveCommand = delegateCommand;
					}
					command = this._saveCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand ShowColorCatalogCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._showColorCatalogCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ShowColorCatalogCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ShowColorCatalogCommandCanExecute)
						};
						this._showColorCatalogCommand = delegateCommand;
					}
					command = this._showColorCatalogCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand ShowFontCatalogCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._showFontCatalogCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ShowFontCatalogCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ShowFontCatalogCommandCanExecute)
						};
						this._showFontCatalogCommand = delegateCommand;
					}
					command = this._showFontCatalogCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand ShowOutputCatalogCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._showOutputCatalogCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ShowOutputCatalogCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ShowOutputCatalogCommandCanExecute)
						};
						this._showOutputCatalogCommand = delegateCommand;
					}
					command = this._showOutputCatalogCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand ShowVersionInfoCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._showVersionInfoCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ShowVersionInfoCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ShowVersionInfoCommandCanExecute)
						};
						this._showVersionInfoCommand = delegateCommand;
					}
					command = this._showVersionInfoCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand SplitPageCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._splitPageCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.SplitPageCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.SplitPageCommandCanExecute)
						};
						this._splitPageCommand = delegateCommand;
					}
					command = this._splitPageCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand SplitWordCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._splitWordCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.SplitWordCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.SplitWordCommandCanExecute)
						};
						this._splitWordCommand = delegateCommand;
					}
					command = this._splitWordCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public Kasuga.Sub Sub
		{
			get
			{
				Kasuga.Sub sub;
				try
				{
					sub = this._sub;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					sub = null;
				}
				return sub;
			}
		}

		public ObservableCollection<WordViewModel> Words
		{
			get
			{
				ObservableCollection<WordViewModel> observableCollection;
				try
				{
					ObservableCollection<WordViewModel> observableCollection1 = new ObservableCollection<WordViewModel>();
					foreach (Word word in this.Sub.Words)
					{
						observableCollection1.Add(new WordViewModel(word, this));
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public MainViewModel(MainWindow window)
		{
			try
			{
				this._sub = new Kasuga.Sub(0);
				this._config = new 春日.Config();
				this._window = window;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private void ArrangeText(Kasuga.Page page)
		{
			try
			{
				UIElementCollection children = this._window.canvas.Children;
				children.Clear();
				double viewRatio = this._config.ViewRatio;
				foreach (Charactor charactor in page.Charactors)
				{
					OutlineTextControl outlineTextControl = new OutlineTextControl()
					{
						Text = charactor.Char.ToString()
					};
					FontEx fontEx = charactor.FontEx;
					outlineTextControl.Font = new FontFamily(fontEx.FamilyName);
					outlineTextControl.FontSize = fontEx.Size * viewRatio;
					outlineTextControl.Bold = fontEx.IsBold;
					outlineTextControl.Italic = fontEx.IsItalic;
					outlineTextControl.Underline = fontEx.HasUnderline;
					outlineTextControl.Strikeout = fontEx.HasStrikeout;
					outlineTextControl.StrokeThickness = fontEx.BorderWidth * 2 * viewRatio;
					outlineTextControl.ShadowDepth = fontEx.ShadowDepth * viewRatio;
					outlineTextControl.ScaleX = fontEx.ScaleX;
					outlineTextControl.ScaleY = fontEx.ScaleY;
					ColorSet colorSet = charactor.ColorSet;
					if (!this._config.DoesShowBeforeColor)
					{
						outlineTextControl.Fill = colorSet.InnerAfterColor.Brush;
						outlineTextControl.Stroke = colorSet.BorderAfterColor.Brush;
					}
					else
					{
						outlineTextControl.Fill = colorSet.InnerBeforeColor.Brush;
						outlineTextControl.Stroke = colorSet.BorderBeforeColor.Brush;
					}
					outlineTextControl.Shadow = colorSet.ShadowColor.Brush;
					Size originalSize = charactor.OriginalSize;
					outlineTextControl.CenterX = originalSize.Width * viewRatio / 2;
					outlineTextControl.CenterY = originalSize.Height * viewRatio / 2;
					outlineTextControl.Angle = -charactor.Angle;
					Point leftTop = charactor.LeftTop;
					Canvas.SetLeft(outlineTextControl, leftTop.X * viewRatio);
					Canvas.SetTop(outlineTextControl, leftTop.Y * viewRatio);
					children.Add(outlineTextControl);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ArrangeTextFromCharactorsGrid()
		{
			try
			{
				int currentRowIndex = 春日.DataGridHelper.GetCurrentRowIndex(this._window.charactorsDataGrid);
				if (currentRowIndex >= 0)
				{
					this.ArrangeText(this.Sub.Charactors[currentRowIndex].ParentalPage);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ArrangeTextFromLinesGrid()
		{
			try
			{
				int currentRowIndex = 春日.DataGridHelper.GetCurrentRowIndex(this._window.linesDataGrid);
				if (currentRowIndex >= 0)
				{
					this.ArrangeText(this.Sub.Lines[currentRowIndex].ParentalPage);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ArrangeTextFromPagesGrid()
		{
			try
			{
				int currentRowIndex = 春日.DataGridHelper.GetCurrentRowIndex(this._window.pagesDataGrid);
				if (currentRowIndex >= 0)
				{
					this.ArrangeText(this.Sub.Pages[currentRowIndex]);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ArrangeTextFromPartsGrid()
		{
			try
			{
				int currentRowIndex = 春日.DataGridHelper.GetCurrentRowIndex(this._window.partsDataGrid);
				if (currentRowIndex >= 0)
				{
					Part item = this.Sub.Parts[currentRowIndex];
					if (item.Pages.Count > 0)
					{
						this.ArrangeText(item.Pages[0]);
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private void ArrangeTextFromThis()
		{
			try
			{
				if (this._window.tabControl.SelectedContent == this._window.partsTabItem)
				{
					this.ArrangeTextFromPartsGrid();
				}
				else if (this._window.tabControl.SelectedContent == this._window.pagesTabItem)
				{
					this.ArrangeTextFromPagesGrid();
				}
				else if (this._window.tabControl.SelectedContent == this._window.linesTabItem)
				{
					this.ArrangeTextFromLinesGrid();
				}
				else if (this._window.tabControl.SelectedContent == this._window.wordsTabItem)
				{
					this.ArrangeTextFromWordsGrid();
				}
				else if (this._window.tabControl.SelectedContent == this._window.charactorsTabItem)
				{
					this.ArrangeTextFromCharactorsGrid();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ArrangeTextFromWordsGrid()
		{
			try
			{
				int currentRowIndex = 春日.DataGridHelper.GetCurrentRowIndex(this._window.wordsDataGrid);
				if (currentRowIndex >= 0)
				{
					this.ArrangeText(this.Sub.Words[currentRowIndex].ParentalPage);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ChangeResolutionCommandCanExecute(object parameter)
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

		private void ChangeResolutionCommandExecute(object parameter)
		{
			try
			{
				ResolutionViewModel resolutionViewModel = new ResolutionViewModel(this.Sub.Resolution);
				bool? nullable = resolutionViewModel.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue) && this.Sub.Resolution != resolutionViewModel.Resolution)
				{
					this.Sub.Resolution = resolutionViewModel.Resolution;
					foreach (Part part in this.Sub.Parts)
					{
						part.Arrange();
					}
					this.RaisePropertyChanged("FrameSize");
					this.RaisePropertyChanged("Sub");
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool CloseCommandCanExecute(object parameter)
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

		private void CloseCommandExecute(object parameter)
		{
			try
			{
				this._window.Close();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ConfigCommandCanExecute(object parameter)
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

		private void ConfigCommandExecute(object parameter)
		{
			try
			{
				ConfigViewModel configViewModel = new ConfigViewModel(this.Config);
				bool? nullable = configViewModel.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					bool flag = false;
					if (this.Config.ViewRatio != configViewModel.Config.ViewRatio)
					{
						this.Config.ViewRatio = configViewModel.Config.ViewRatio;
						flag = true;
						this.RaisePropertyChanged("FrameSize");
					}
					if (this.Config.DoesShowBeforeColor != configViewModel.Config.DoesShowBeforeColor)
					{
						this.Config.DoesShowBeforeColor = configViewModel.Config.DoesShowBeforeColor;
						flag = true;
					}
					if (flag)
					{
						this.RaisePropertyChanged("Config");
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ExportToAssCommandCanExecute(object parameter)
		{
			bool count;
			try
			{
				count = this.Sub.Parts.Count > 0;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				count = false;
			}
			return count;
		}

		private void ExportToAssCommandExecute(object parameter)
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog()
				{
					Filter = "ASSファイル (*.ass)|*.ass|すべてのファイル (*.*)|*.*"
				};
				bool? nullable = saveFileDialog.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.Sub.ExportToAss(saveFileDialog.FileName);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ImportTimeTaggedTextCommandCanExecute(object parameter)
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

		private void ImportTimeTaggedTextCommandExecute(object parameter)
		{
			try
			{
				ImportViewModel importViewModel = new ImportViewModel(this.Sub.Parts.Count, this.Sub.FontSetCatalog, this.Sub.ColorSetCatalog, this.Sub.OutputCatalog);
				bool? nullable = importViewModel.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.Sub.ImportFromTimeTaggedText(importViewModel.ImportInfo);
					this.RaisePropertyChanged("Sub");
					this.RaisePropertyChanged("Parts");
					this.RaisePropertyChanged("Pages");
					this.RaisePropertyChanged("Lines");
					this.RaisePropertyChanged("Words");
					this.RaisePropertyChanged("Charactors");
					((DelegateCommand)this.ExportToAssCommand).RaiseCanExecuteChanged();
					this._fileName = null;
					((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool JoinPagesCommandCanExecute(object parameter)
		{
			bool count;
			try
			{
				count = this._window.pagesDataGrid.SelectedItems.Count > 1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				count = false;
			}
			return count;
		}

		private void JoinPagesCommandExecute(object parameter)
		{
			try
			{
				List<Kasuga.Page> pages = new List<Kasuga.Page>();
				foreach (PageViewModel selectedItem in this._window.pagesDataGrid.SelectedItems)
				{
					pages.Add(selectedItem.Page);
				}
				Kasuga.Page page = Kasuga.Page.Unite(pages);
				this.Sub.InsertPage(this.Sub.Pages.IndexOf(pages[0]), page);
				foreach (Kasuga.Page page1 in pages)
				{
					this.Sub.RemovePage(page1);
				}
				page.ParentalPart.Arrange();
				page.ParentalPart.PutViewTimes();
				this.RaisePropertyChanged("Parts");
				this.RaisePropertyChanged("Pages");
				this.RaisePropertyChanged("Lines");
				this.RaisePropertyChanged("Words");
				this.RaisePropertyChanged("Charactors");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool JoinWordsCommandCanExecute(object parameter)
		{
			bool count;
			try
			{
				count = this._window.wordsDataGrid.SelectedItems.Count > 1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				count = false;
			}
			return count;
		}

		private void JoinWordsCommandExecute(object parameter)
		{
			try
			{
				List<Word> words = new List<Word>();
				foreach (WordViewModel selectedItem in this._window.wordsDataGrid.SelectedItems)
				{
					words.Add(selectedItem.Word);
				}
				Word word = Word.Unite(words);
				this.Sub.InsertWord(this.Sub.Words.IndexOf(words[0]), word);
				foreach (Word word1 in words)
				{
					this.Sub.RemoveWord(word1);
				}
				word.ParentalPage.Arrange();
				this.RaisePropertyChanged("Parts");
				this.RaisePropertyChanged("Pages");
				this.RaisePropertyChanged("Lines");
				this.RaisePropertyChanged("Words");
				this.RaisePropertyChanged("Charactors");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool OpenCommandCanExecute(object parameter)
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

		private void OpenCommandExecute(object parameter)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog()
				{
					Filter = "春日ファイル (*.ksg)|*.ksg|すべてのファイル (*.*)|*.*"
				};
				bool? nullable = openFileDialog.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					Kasuga.Sub sub = Kasuga.Sub.Deserialize(openFileDialog.FileName);
					if (sub != null)
					{
						this._sub = sub;
						this.RaisePropertyChanged("Sub");
						this.RaisePropertyChanged("Parts");
						this.RaisePropertyChanged("Pages");
						this.RaisePropertyChanged("Lines");
						this.RaisePropertyChanged("Words");
						this.RaisePropertyChanged("Charactors");
						this.RaisePropertyChanged("FrameSize");
						((DelegateCommand)this.ExportToAssCommand).RaiseCanExecuteChanged();
						this._fileName = openFileDialog.FileName;
						((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
					}
				}
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

		private bool SaveAsCommandCanExecute(object parameter)
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

		private void SaveAsCommandExecute(object parameter)
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog()
				{
					Filter = "春日ファイル (*.ksg)|*.ksg|すべてのファイル (*.*)|*.*"
				};
				bool? nullable = saveFileDialog.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.Sub.Serialize(saveFileDialog.FileName);
					this._fileName = saveFileDialog.FileName;
					((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool SaveCommandCanExecute(object parameter)
		{
			bool flag;
			try
			{
				flag = this._fileName != null;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		private void SaveCommandExecute(object parameter)
		{
			try
			{
				this.Sub.Serialize(this._fileName);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ShowColorCatalogCommandCanExecute(object parameter)
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

		private void ShowColorCatalogCommandExecute(object parameter)
		{
			try
			{
				ColorCatalogViewModel colorCatalogViewModel = new ColorCatalogViewModel(this.Sub.ColorSetCatalog);
				colorCatalogViewModel.ShowDialog();
				this.Sub.ColorSetCatalog = colorCatalogViewModel.Catalog;
				foreach (PartViewModel part in this.Parts)
				{
					part.RaiseFontSetNamesChanged();
				}
				foreach (PageViewModel page in this.Pages)
				{
					page.RaiseFontSetNamesChanged();
				}
				foreach (LineViewModel line in this.Lines)
				{
					line.RaiseColorSetNamesChanged();
				}
				foreach (WordViewModel word in this.Words)
				{
					word.RaiseColorSetNamesChanged();
				}
				foreach (CharactorViewModel charactor in this.Charactors)
				{
					charactor.RaiseColorSetNamesChanged();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ShowFontCatalogCommandCanExecute(object parameter)
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

		private void ShowFontCatalogCommandExecute(object parameter)
		{
			try
			{
				FontCatalogViewModel fontCatalogViewModel = new FontCatalogViewModel(this.Sub.FontSetCatalog);
				fontCatalogViewModel.ShowDialog();
				this.Sub.FontSetCatalog = fontCatalogViewModel.Catalog;
				foreach (PartViewModel part in this.Parts)
				{
					part.RaiseFontSetNamesChanged();
				}
				foreach (PageViewModel page in this.Pages)
				{
					page.RaiseFontSetNamesChanged();
				}
				foreach (LineViewModel line in this.Lines)
				{
					line.RaiseFontSetNamesChanged();
				}
				foreach (WordViewModel word in this.Words)
				{
					word.RaiseFontSetNamesChanged();
				}
				foreach (CharactorViewModel charactor in this.Charactors)
				{
					charactor.RaiseFontSetNamesChanged();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ShowOutputCatalogCommandCanExecute(object parameter)
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

		private void ShowOutputCatalogCommandExecute(object parameter)
		{
			try
			{
				OutputCatalogViewModel outputCatalogViewModel = new OutputCatalogViewModel(this.Sub.OutputCatalog);
				outputCatalogViewModel.ShowDialog();
				this.Sub.OutputCatalog = outputCatalogViewModel.Catalog;
				foreach (PartViewModel part in this.Parts)
				{
					part.RaiseOutputNamesChanged();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool ShowVersionInfoCommandCanExecute(object parameter)
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

		private void ShowVersionInfoCommandExecute(object parameter)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string[] title = new string[] { ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(executingAssembly, typeof(AssemblyTitleAttribute))).Title, " ver. ", executingAssembly.GetName().Version.ToString(), Environment.NewLine, ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(executingAssembly, typeof(AssemblyCopyrightAttribute))).Copyright };
				MessageBox.Show(string.Concat(title));
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool SplitPageCommandCanExecute(object parameter)
		{
			bool count;
			try
			{
				count = this._window.pagesDataGrid.SelectedItems.Count == 1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				count = false;
			}
			return count;
		}

		private void SplitPageCommandExecute(object parameter)
		{
			try
			{
				Kasuga.Page page = ((PageViewModel)this._window.pagesDataGrid.SelectedItem).Page;
				List<Kasuga.Page> pages = Kasuga.Page.Split(page);
				int num = this.Sub.Pages.IndexOf(page);
				for (int i = pages.Count - 1; i >= 0; i--)
				{
					this.Sub.InsertPage(num, pages[i]);
				}
				this.Sub.RemovePage(page);
				pages[0].ParentalPart.Arrange();
				pages[0].ParentalPart.PutViewTimes();
				this.RaisePropertyChanged("Parts");
				this.RaisePropertyChanged("Pages");
				this.RaisePropertyChanged("Lines");
				this.RaisePropertyChanged("Words");
				this.RaisePropertyChanged("Charactors");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool SplitWordCommandCanExecute(object parameter)
		{
			bool count;
			try
			{
				count = this._window.wordsDataGrid.SelectedItems.Count == 1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				count = false;
			}
			return count;
		}

		private void SplitWordCommandExecute(object parameter)
		{
			try
			{
				Word word = ((WordViewModel)this._window.wordsDataGrid.SelectedItem).Word;
				List<Word> words = Word.Split(word);
				int num = this.Sub.Words.IndexOf(word);
				for (int i = words.Count - 1; i >= 0; i--)
				{
					this.Sub.InsertWord(num, words[i]);
				}
				this.Sub.RemoveWord(word);
				words[0].ParentalPage.Arrange();
				this.RaisePropertyChanged("Parts");
				this.RaisePropertyChanged("Pages");
				this.RaisePropertyChanged("Lines");
				this.RaisePropertyChanged("Words");
				this.RaisePropertyChanged("Charactors");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdateCharactorsGrid()
		{
			try
			{
				this.RaisePropertyChanged("Charactors");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdateLinesGrid()
		{
			try
			{
				this.RaisePropertyChanged("Lines");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdatePagesContextMenu()
		{
			try
			{
				((DelegateCommand)this.JoinPagesCommand).RaiseCanExecuteChanged();
				((DelegateCommand)this.SplitPageCommand).RaiseCanExecuteChanged();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdatePagesGrid()
		{
			try
			{
				this.RaisePropertyChanged("Pages");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdatePartsGrid()
		{
			try
			{
				this.RaisePropertyChanged("Parts");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdateWordsContextMenu()
		{
			try
			{
				((DelegateCommand)this.JoinWordsCommand).RaiseCanExecuteChanged();
				((DelegateCommand)this.SplitWordCommand).RaiseCanExecuteChanged();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void UpdateWordsGrid()
		{
			try
			{
				this.RaisePropertyChanged("Words");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}