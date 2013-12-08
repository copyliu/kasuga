using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class ColorSet : ICatalogItem
	{
		public static ColorSet Default;

		public BasicColorEx BorderAfterColor
		{
			get;
			set;
		}

		public BasicColorEx BorderBeforeColor
		{
			get;
			set;
		}

		public BasicColorEx InnerAfterColor
		{
			get;
			set;
		}

		public BasicColorEx InnerBeforeColor
		{
			get;
			set;
		}

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

		public BasicColorEx ShadowColor
		{
			get;
			set;
		}

		static ColorSet()
		{
			ColorSet.Default = new ColorSet("デフォルト", new SolidColor(new ColorAlpha(0, 255, 255, 255)), new SolidColor(new ColorAlpha(0, 255, 0, 0)), new SolidColor(new ColorAlpha(0, 0, 0, 0)), new SolidColor(new ColorAlpha(0, 255, 255, 255)), new SolidColor(new ColorAlpha(128, 0, 0, 0)));
		}

		public ColorSet()
		{
			try
			{
				this.InnerBeforeColor = new SolidColor();
				this.InnerAfterColor = new SolidColor();
				this.BorderBeforeColor = new SolidColor();
				this.BorderAfterColor = new SolidColor();
				this.ShadowColor = new SolidColor();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public ColorSet(string name, BasicColorEx innerBeforeColor, BasicColorEx innerAfterColor, BasicColorEx borderBeforeColor, BasicColorEx borderAfterColor, BasicColorEx shadowColor)
		{
			try
			{
				this.Name = name;
				this.InnerBeforeColor = innerBeforeColor;
				this.InnerAfterColor = innerAfterColor;
				this.BorderBeforeColor = borderBeforeColor;
				this.BorderAfterColor = borderAfterColor;
				this.ShadowColor = shadowColor;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}