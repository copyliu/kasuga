using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class FontSet : ICatalogItem
	{
		public static FontSet Default;

		public string Name
		{
			get
			{
				return JustDecompileGenerated_get_Name();
			}
			set
			{
				JustDecompileGenerated_set_Name(value);
			}
		}

		private string JustDecompileGenerated_Name_k__BackingField;

		public string JustDecompileGenerated_get_Name()
		{
			return this.JustDecompileGenerated_Name_k__BackingField;
		}

		public void JustDecompileGenerated_set_Name(string value)
		{
			this.JustDecompileGenerated_Name_k__BackingField = value;
		}

		public FontEx Ruby
		{
			get;
			set;
		}

		public FontEx Text
		{
			get;
			set;
		}

		static FontSet()
		{
			FontSet.Default = new FontSet("デフォルト", new FontEx("ＭＳ Ｐゴシック", 44, false, false, false, false, 1, 1, 4.4, 3.8), new FontEx("ＭＳ Ｐゴシック", 20, false, false, false, false, 1, 1, 3, 3.8));
		}

		public FontSet()
		{
		}

		public FontSet(string name, FontEx text, FontEx ruby)
		{
			try
			{
				this.Name = name;
				this.Text = text;
				this.Ruby = ruby;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}