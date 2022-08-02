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
        public static async Task SerializeAsync(this ObservableCollection<AppModel> collection)
        {

            using (StreamWriter sw = new StreamWriter(FilePaths.ConfigFile, false))
            {
                List<string> filePaths = new List<string>(collection.Select(x => x.FilePath));
                string jsonString = JsonSerializer.Serialize(filePaths, typeof(List<string>));
                await sw.WriteAsync(jsonString);
            }
            var JUST_BREAKPOINT = string.Empty;
        }
        public static async Task<ObservableCollection<AppModel>> DeserializeAsync(this ObservableCollection<AppModel> collection)
        {
            using (StreamReader sr = new StreamReader(FilePaths.ConfigFile, false))
            {

            }
        }
    }
}
