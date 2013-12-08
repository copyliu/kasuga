using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class Sub
	{
		[XmlIgnore]
		public List<Charactor> Charactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Part part in this.Parts)
					{
						foreach (Charactor charactor in part.Charactors)
						{
							charactors1.Add(charactor);
						}
					}
					charactors = charactors1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					charactors = null;
				}
				return charactors;
			}
		}

		public Catalog<ColorSet> ColorSetCatalog
		{
			get;
			set;
		}

		public Catalog<FontSet> FontSetCatalog
		{
			get;
			set;
		}

		[XmlIgnore]
		public List<Line> Lines
		{
			get
			{
				List<Line> lines;
				try
				{
					List<Line> lines1 = new List<Line>();
					foreach (Part part in this.Parts)
					{
						foreach (Line line in part.Lines)
						{
							lines1.Add(line);
						}
					}
					lines = lines1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					lines = null;
				}
				return lines;
			}
		}

		public Catalog<BasicOutput> OutputCatalog
		{
			get;
			set;
		}

		[XmlIgnore]
		public List<Page> Pages
		{
			get
			{
				List<Page> pages;
				try
				{
					List<Page> pages1 = new List<Page>();
					foreach (Part part in this.Parts)
					{
						foreach (Page page in part.Pages)
						{
							pages1.Add(page);
						}
					}
					pages = pages1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					pages = null;
				}
				return pages;
			}
		}

		public List<Part> Parts
		{
			get;
			set;
		}

		public Size Resolution
		{
			get;
			set;
		}

		[XmlIgnore]
		public List<Charactor> RubyCharactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Part part in this.Parts)
					{
						foreach (Charactor rubyCharactor in part.RubyCharactors)
						{
							charactors1.Add(rubyCharactor);
						}
					}
					charactors = charactors1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					charactors = null;
				}
				return charactors;
			}
		}

		[XmlIgnore]
		public List<Charactor> TextCharactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Part part in this.Parts)
					{
						foreach (Charactor textCharactor in part.TextCharactors)
						{
							charactors1.Add(textCharactor);
						}
					}
					charactors = charactors1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					charactors = null;
				}
				return charactors;
			}
		}

		[XmlIgnore]
		public List<Word> Words
		{
			get
			{
				List<Word> words;
				try
				{
					List<Word> words1 = new List<Word>();
					foreach (Part part in this.Parts)
					{
						foreach (Word word in part.Words)
						{
							words1.Add(word);
						}
					}
					words = words1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					words = null;
				}
				return words;
			}
		}

		public Sub()
		{
			try
			{
				this.Parts = new List<Part>();
				this.FontSetCatalog = new Catalog<FontSet>();
				this.ColorSetCatalog = new Catalog<ColorSet>();
				this.OutputCatalog = new Catalog<BasicOutput>();
				this.Resolution = new Size(640, 480);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Sub(int dummy)
		{
			try
			{
				this.Parts = new List<Part>();
				this.FontSetCatalog = new Catalog<FontSet>()
				{
					FontSet.Default
				};
				this.ColorSetCatalog = new Catalog<ColorSet>()
				{
					ColorSet.Default
				};
				this.OutputCatalog = new Catalog<BasicOutput>()
				{
					BasicOutput.Default
				};
				this.Resolution = new Size(640, 480);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public static Sub Deserialize(string fileName)
		{
			Sub sub;
			Sub sub1;
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Open);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Sub));
				try
				{
					sub = (Sub)xmlSerializer.Deserialize(fileStream);
				}
				catch (Exception exception)
				{
					MessageBox.Show("ファイルの読み込みに失敗しました。");
					sub1 = null;
					return sub1;
				}
				fileStream.Close();
				sub.Initialize();
				sub1 = sub;
			}
			catch (Exception exception1)
			{
				ErrorMessage.Show(exception1, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				sub1 = null;
			}
			return sub1;
		}

		public void ExportToAss(string fileName)
		{
			try
			{
				List<AssStyle> assStyles = new List<AssStyle>();
				List<AssDialogue> assDialogues = new List<AssDialogue>();
				foreach (Part part in this.Parts)
				{
					assDialogues.AddRange(part.ConvertToAss(ref assStyles));
				}
				StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Unicode);
				streamWriter.WriteLine("[Script Info]");
				streamWriter.WriteLine("Title: 無題");
				streamWriter.WriteLine("ScriptType: v4.00+");
				streamWriter.WriteLine("WrapStyle: 2");
				double width = this.Resolution.Width;
				streamWriter.WriteLine(string.Concat("PlayResX: ", width.ToString()));
				double height = this.Resolution.Height;
				streamWriter.WriteLine(string.Concat("PlayResY: ", height.ToString()));
				streamWriter.WriteLine();
				streamWriter.WriteLine("[V4+ Styles]");
				foreach (AssStyle assStyle in assStyles)
				{
					streamWriter.WriteLine(assStyle.ToString());
				}
				streamWriter.WriteLine();
				streamWriter.WriteLine("[Events]");
				foreach (AssDialogue assDialogue in assDialogues)
				{
					streamWriter.WriteLine(assDialogue.ToString());
				}
				streamWriter.Close();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void ImportFromTimeTaggedText(ImportInfo info)
		{
			try
			{
				if (!info.IsAdd)
				{
					this.Parts.Clear();
				}
				StreamReader streamReader = new StreamReader(info.FileName, Encoding.GetEncoding("Shift-JIS"), true);
				string end = streamReader.ReadToEnd();
				streamReader.Close();
				Part part = new Part(this, end, info.EffectName, info.IsTopBase, info.BeforeMargin, info.AfterMargin, info.ViewInterval, info.LeftCorner, info.UsableWidth, info.Angle, info.ArrangementName, info.IsCenteringEnabled, info.MinOverlapping, info.DistanceToNextLine, info.DistanceToRuby, info.IsSpacingEnabled, info.IsLikeUgaWord, info.IsWithoutSing, info.FontSetName, info.ColorSetName);
				part.Arrange();
				part.PutSingTimes();
				foreach (Word word in part.Words)
				{
					word.PutRubySingTime();
				}
				part.PutViewTimes();
				this.Parts.Add(part);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Initialize()
		{
			try
			{
				foreach (Part part in this.Parts)
				{
					part.Initialize(this);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void InsertPage(int index, Page page)
		{
			try
			{
				int num = 0;
				for (int i = 0; i < this.Parts.Count; i++)
				{
					Part item = this.Parts[i];
					int num1 = 0;
					while (num1 < item.Pages.Count)
					{
						if (num == index)
						{
							item.Pages.Insert(num1, page);
							return;
						}
						else if (i < this.Parts.Count - 1 || num1 < item.Pages.Count - 1)
						{
							num++;
							num1++;
						}
						else
						{
							item.Pages.Add(page);
							return;
						}
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void InsertWord(int index, Word word)
		{
			try
			{
				int num = 0;
				for (int i = 0; i < this.Parts.Count; i++)
				{
					Part item = this.Parts[i];
					for (int j = 0; j < item.Pages.Count; j++)
					{
						Page page = item.Pages[j];
						for (int k = 0; k < page.Lines.Count; k++)
						{
							Line line = page.Lines[k];
							int num1 = 0;
							while (num1 < line.Words.Count)
							{
								if (num == index)
								{
									line.Words.Insert(num1, word);
									return;
								}
								else if (i < this.Parts.Count - 1 || j < item.Pages.Count - 1 || k < page.Lines.Count - 1 || num1 < line.Words.Count - 1)
								{
									num++;
									num1++;
								}
								else
								{
									line.Words.Add(word);
									return;
								}
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RemovePage(Page page)
		{
			try
			{
				foreach (Part part in this.Parts)
				{
					int num = 0;
					while (num < part.Pages.Count)
					{
						if (part.Pages[num] != page)
						{
							num++;
						}
						else
						{
							part.Pages.Remove(page);
							return;
						}
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RemoveWord(Word word)
		{
			try
			{
				foreach (Part part in this.Parts)
				{
					foreach (Page page in part.Pages)
					{
						foreach (Line line in page.Lines)
						{
							int num = 0;
							while (num < line.Words.Count)
							{
								if (line.Words[num] != word)
								{
									num++;
								}
								else
								{
									line.Words.Remove(word);
									return;
								}
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Serialize(string fileName)
		{
			try
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Create);
				(new XmlSerializer(typeof(Sub))).Serialize(fileStream, this);
				fileStream.Close();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}