using Kasuga;
using System;
using System.Reflection;

namespace 春日
{
	public class Validations
	{
		public Validations()
		{
		}

		public static bool ByteValidate(string value)
		{
			byte num;
			bool flag;
			try
			{
				flag = (byte.TryParse(value.ToString(), out num) ? true : false);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool DoubleValidate(string value, bool isAllowZero, bool isAllowMinus)
		{
			double num;
			bool flag;
			try
			{
				if (!double.TryParse(value.ToString(), out num))
				{
					flag = false;
				}
				else if (isAllowZero || num != 0)
				{
					flag = (isAllowMinus || num >= 0 ? true : false);
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool IntegerValidate(string value, bool isAllowZero, bool isAllowMinus)
		{
			int num;
			bool flag;
			try
			{
				if (!int.TryParse(value.ToString(), out num))
				{
					flag = false;
				}
				else if (isAllowZero || num != 0)
				{
					flag = (isAllowMinus || num >= 0 ? true : false);
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}
	}
}