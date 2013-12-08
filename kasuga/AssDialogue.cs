using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	public class AssDialogue
	{
		public string Actor
		{
			get;
			set;
		}

		public string Effect
		{
			get;
			set;
		}

		public PlayTime End
		{
			get;
			set;
		}

		public bool IsComment
		{
			get;
			set;
		}

		public int Layer
		{
			get;
			set;
		}

		public int LeftMargin
		{
			get;
			set;
		}

		public int RightMargin
		{
			get;
			set;
		}

		public PlayTime Start
		{
			get;
			set;
		}

		public string Style
		{
			get;
			set;
		}

		public string Text
		{
			get;
			set;
		}

		public int VerticalMargin
		{
			get;
			set;
		}

		public AssDialogue()
		{
		}

		public override string ToString()
		{
			string str;
			string empty;
			try
			{
				str = (!this.IsComment ? "Dialogue: " : "Comment: ");
				string[] strArrays = new string[] { str, this.Layer.ToString(), ",", this.Start.ToString(), ",", this.End.ToString(), ",", this.Style, ",", this.Actor, ",", this.LeftMargin.ToString("D4"), ",", this.RightMargin.ToString("D4"), ",", this.VerticalMargin.ToString("D4"), ",", this.Effect, ",", this.Text };
				empty = string.Concat(strArrays);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				empty = string.Empty;
			}
			return empty;
		}
	}
}