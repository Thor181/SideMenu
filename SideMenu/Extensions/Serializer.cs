using SideMenu.Models;
using SideMenu.Service;
using SideMenu.ViewModels;
using SideMenu.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SideMenu.Extensions
{
    public static class Serializer
    {
        public static async Task SerializeConfigAsync(this ObservableCollection<AppCard> collection)
        {
            await CommonSerialize(appCards: collection);
        }

        public static async Task SerializeConfigAsync(this StartupLocation startupLocation)
        {
            await CommonSerialize(startupLocation);
        }

        private static async Task CommonSerialize(StartupLocation startupLocation = null, ObservableCollection<AppCard> appCards = null)
        {
            ObservableCollection<AppCard> appCardsDes = new ObservableCollection<AppCard>();
            await appCardsDes.DeserializeConfigAsync(Dispatcher.CurrentDispatcher);

            StartupLocation startupLocationDes = new StartupLocation(Application.Current.MainWindow);
            await startupLocationDes.DeserializeConfigAsync(Dispatcher.CurrentDispatcher);

            ConfigWrapper configWrapper = new ConfigWrapper();
            configWrapper.SetAppCards(appCards ?? appCardsDes);
            configWrapper.StartupLocation = startupLocation ?? startupLocationDes;

            using (StreamWriter sw = new StreamWriter(FilePaths.ConfigFile))
            {
                string jsonString = JsonSerializer.Serialize(configWrapper, typeof(ConfigWrapper));
                sw.WriteLine(jsonString);
            }
        }

        public static async Task DeserializeConfigAsync(this ObservableCollection<AppCard> appCardCollection, Dispatcher dispatcher)
        {
            if (new FileInfo(FilePaths.ConfigFile).Length == 0)
                return;

            using (Stream sr = new FileStream(FilePaths.ConfigFile, FileMode.Open))
            {
                ConfigWrapper configWrapper = (ConfigWrapper)JsonSerializer.DeserializeAsync(sr, typeof(ConfigWrapper)).Result;
                foreach (var item in configWrapper.GetAppCards())
                {
                    appCardCollection.Add(item);
                }
            }
        }

        public static async Task DeserializeConfigAsync(this StartupLocation startupLocation, Dispatcher dispatcher)
        {
            if (new FileInfo(FilePaths.ConfigFile).Length == 0)
                return;

            using (Stream sr = new FileStream(FilePaths.ConfigFile, FileMode.Open))
            {
                ConfigWrapper configWrapper = (ConfigWrapper)JsonSerializer.DeserializeAsync(sr, typeof(ConfigWrapper)).Result;
                startupLocation.X = configWrapper.StartupLocation.X;
                startupLocation.Y = configWrapper.StartupLocation.Y;
                startupLocation.AnimationPositionShow = configWrapper.StartupLocation.AnimationPositionShow;
                startupLocation.AnimationPositionHide = configWrapper.StartupLocation.AnimationPositionHide;
                //startupLocation = configWrapper.StartupLocation;
            }
        }

        private class ConfigWrapper
        {
            public List<string> AppCardPaths { get; set; } = new List<string>();
            public StartupLocation StartupLocation { get; set; }

            public ObservableCollection<AppCard> GetAppCards()
            {
                return new ObservableCollection<AppCard>(AppCardPaths.Select(x => new AppCard(x)));
            }

            public void SetAppCards(ObservableCollection<AppCard> collection)
            {
                AppCardPaths = new List<string>(collection.Select(x => x.AppCardViewModel.AppModel.FilePath));
            }
        }
    }
}
