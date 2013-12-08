using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class Catalog<T> : List<T>
	where T : ICatalogItem
	{
		[XmlIgnore]
		public List<string> Names
		{
			get
			{
				List<string> strs;
				try
				{
					List<string> strs1 = new List<string>();
					foreach (T t in this)
					{
						strs1.Add(t.Name);
					}
					strs = strs1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					strs = null;
				}
				return strs;
			}
		}

		public Catalog()
		{
		}

		public T GetItem(string name)
		{
			T item;
			try
			{
				foreach (T t in this)
				{
					if (t.Name != name)
					{
						continue;
					}
					item = t;
					return item;
				}
				item = base[0];
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				item = default(T);
			}
			return item;
		}

		public bool IsExist(string name)
		{
			bool flag;
			try
			{
				foreach (T t in this)
				{
					if (t.Name != name)
					{
						continue;
					}
					flag = true;
					return flag;
				}
				flag = false;
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