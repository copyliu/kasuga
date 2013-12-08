using Kasuga;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace 春日
{
	[Serializable]
	public class Config
	{
		public bool DoesShowBeforeColor
		{
			get;
			set;
		}

		public double ViewRatio
		{
			get;
			set;
		}

		public Config()
		{
			try
			{
				this.ViewRatio = 1;
				this.DoesShowBeforeColor = false;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Config(double viewRatio, bool doesShowBeforeColor)
		{
			try
			{
				this.ViewRatio = viewRatio;
				this.DoesShowBeforeColor = doesShowBeforeColor;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}