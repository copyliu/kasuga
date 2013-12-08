using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Kasuga
{
	[XmlInclude(typeof(BorderWipeOutput))]
	[XmlInclude(typeof(BorderWipeWithLeadOutput))]
	public abstract class BasicOutput : ICatalogItem
	{
		public static BasicOutput Default;

		public abstract object Detail
		{
			get;
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

		public abstract string TypeName
		{
			get;
		}

		static BasicOutput()
		{
			BasicOutput.Default = new BorderWipeOutput("デフォルト");
		}

		protected BasicOutput()
		{
		}

		public abstract List<AssDialogue> ConvertToAss(Part part, ref List<AssStyle> styles);
	}
}