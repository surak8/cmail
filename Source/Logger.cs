using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace NScmail {

	static class Logger {
		internal static void log(MethodBase mb, Exception ex) {
			log(makeSig(mb) + ":" + decomposeException(ex));
		}

		public static string decomposeException(Exception ex) {
			StringBuilder sb = null;
			Exception ex0;

			if ((ex0 = ex) != null) {
				sb = new StringBuilder();
				while (ex0 != null) {
					sb.AppendLine(ex0.Message + " [" + ex0.GetType().Name + "]");
					ex0 = ex0.InnerException;
				}
			}
			return sb == null ? string.Empty : sb.ToString();
		}

		internal static void log(MethodBase mb, string message) {
			log(makeSig(mb) + ":" + message);
		}
		static void log(string v) {
			Trace.WriteLine(v);
			Console.WriteLine(v);
		}

		static String makeSig(MethodBase mb) {
			return mb.ReflectedType.Name + "." + mb.Name;
		}
	}
}