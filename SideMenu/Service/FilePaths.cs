﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideMenu.Service
{
    public static class FilePaths
    {
        private static readonly string _logDirectory = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\SideMenu\\Logs";
        private static readonly string _configDirectory = $"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\SideMenu\\Config";

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
        public static string ConfigFile
        {
            get
            {
                string filePath = $"{_configDirectory}\\config.json";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
                return filePath;
            }
        }
    }
}
