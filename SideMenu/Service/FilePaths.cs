using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideMenu.Service
{
    public static class FilePaths
    {
        private const string _logDirectory = "%LOCALAPPDATA%\\SideMenu\\Logs";
        private const string _configDirectory = "%LOCALAPPDATA%\\SideMenu\\Config";

        public static string LogDirectory
        {
            get
            {
                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }
                return _logDirectory;
            }
        }
        public static string ConfigDirectory
        {
            get
            {
                if (!Directory.Exists(_configDirectory))
                {
                    Directory.CreateDirectory(_configDirectory);
                }
                return _logDirectory;
            }
        }
    }
}
