using System;
using System.Reflection;
using System.Windows;

namespace Kasuga
{
	public class ErrorMessage
	{
		public ErrorMessage()
		{
		}

		public static void Show(Exception ex, Assembly assembly, MethodBase method)
		{
			string title = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title;
			string str = assembly.GetName().Version.ToString();
			string fullName = method.ReflectedType.FullName;
			string name = method.Name;
			string[] newLine = new string[] { "エラーが発生しました。", Environment.NewLine, "アセンブリ名：", title, Environment.NewLine, "バージョン：", str, Environment.NewLine, "クラス名：", fullName, Environment.NewLine, "メソッド名：", name, Environment.NewLine, "エラー内容：", ex.Message };
			MessageBox.Show(string.Concat(newLine));
		}
	}
}