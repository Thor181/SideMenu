using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideMenu.Service
{
    public static class Logger
    {
        public static void WriteException(Exception ex)
        {
            string exceptionString = $"[{DateTime.Now}] Exception: [{ex}]";
            string logFileName = GetLogFileName();
            File.WriteAllText(logFileName, exceptionString);
        }
        private static string GetLogFileName()
        {
            return $"{FilePaths.LogDirectory}log{DateTime.Now.ToString().ReplaceCharsToNull(":",".")}.txt";
        }
    }
    public static class Extensions
    {
        public static string ReplaceCharsToNull(this string str, params string[] chars)
        {
            if (str == null) throw new ArgumentNullException();
                       
            string result = str;
            foreach (var item in chars)
            {
                result = result.Replace(item, "");
            }
            return result;
        }
    }

}
