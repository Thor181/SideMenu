using System;
using System.Collections.ObjectModel;
using System.Windows;
using SideMenu.Models;
using SideMenu.Extensions;
using System.Windows.Threading;
using SideMenu.Views;

namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<AppCard> AppCards { get; set; } = new ObservableCollection<AppCard>();

        private Service.StartupLocation _startupLocation;

        public Service.StartupLocation StartupLocation
        {
            get => _startupLocation ??= new Service.StartupLocation();
        }

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            _ = AppCards.DeserializeConfigAsync(dispatcher);
            AppCards.CollectionChanged += AppModels_CollectionChanged;
        }

        private void AppModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _ = AppCards.SerializeConfigAsync();
        }

        public void AddNewApp(DragEventArgs e)
        {
            try
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (var path in filePaths)
                {
                    AppCards.Add(new AppCard(path));
                }
            }
            catch (Exception ex)
            {
                Service.Logger.WriteException(ex);
#if DEBUG
                throw;
#endif
            }
        }

    }
}
