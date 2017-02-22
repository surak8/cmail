using System;
using System.Diagnostics;
using System.Reflection;

namespace NScmail {

    static class Logger {




        internal static void log(MethodBase mb, Exception ex) {
            log(makeSig(mb) + ":" + ex.Message);
        }

        static void log(string v) {
            Trace.WriteLine(v);
        }

        static String makeSig(MethodBase mb) {
            return mb.ReflectedType.Name + "." + mb.Name;
        }
    }
}