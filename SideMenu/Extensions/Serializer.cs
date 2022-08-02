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
using System.Windows.Threading;

namespace SideMenu.Extensions
{
    public static class Serializer
    {
        public static async Task SerializeConfigAsync(this ObservableCollection<AppModel> collection)
        {
            using (StreamWriter sw = new StreamWriter(FilePaths.ConfigFile, false))
            {
                List<string> filePaths = new List<string>(collection.Select(x => x.FilePath));
                string jsonString = JsonSerializer.Serialize(filePaths, typeof(List<string>));
                await sw.WriteAsync(jsonString);
            }
        }
        public static async Task DeserializeConfigAsync(this ObservableCollection<AppModel> appModelCollection, Dispatcher dispatcher)
        {
            if (new FileInfo(FilePaths.ConfigFile).Length == 0) return;
            
            await dispatcher.BeginInvoke(() =>
            {
                List<string> appPaths = new List<string>();
                using (StreamReader sr = new StreamReader(FilePaths.ConfigFile, false))
                {
                    appPaths = (List<string>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(List<string>));
                }
                foreach (var item in appPaths)
                {
                    appModelCollection.Add(new AppModel(item));
                }
            });
        }
    }
}
