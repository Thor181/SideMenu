using SideMenu.Models;
using SideMenu.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SideMenu.Extensions.Serialization
{
    public static class Extensions
    {
        private static readonly string _configFilePath = $"{FilePaths.ConfigDirectory}\\config.json";
        public static async void SerializeAsync(this ObservableCollection<AppModel> collection)
        {
            using (StreamWriter sw = new StreamWriter(_configFilePath, false))
            {
                List<string> filePaths = new List<string>(collection.Select(x => x.FilePath));
                string jsonString = JsonSerializer.Serialize(filePaths, typeof(List<string>));
                

            }


            await Task.Run(() =>
            {

            });


            var JUST_BREAKPOINT = string.Empty;
        }
    }
}
