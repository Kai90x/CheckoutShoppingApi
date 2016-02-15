using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ShoppingAPI.Utils
{
    public class LogUtils
    {
        public static string AppName = "Checkout Shopping";

        public static void LogError(string className, string functionName, string errorMessage)
        {
            EventLog.WriteEntry(AppName, string.Format("ClassName : {0},Function Name : {1}, ErrorMessage : {2} ", className, functionName, errorMessage), EventLogEntryType.Error);
        }
    }
}