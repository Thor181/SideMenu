using System;
using System.Collections.ObjectModel;
using System.Windows;
using SideMenu.Models;
using SideMenu.Extensions;
using System.Windows.Threading;

namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<AppModel> AppModels { get; set; } = new ObservableCollection<AppModel>();

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            _ = AppModels.DeserializeConfigAsync(dispatcher);
            AppModels.CollectionChanged += AppModels_CollectionChanged;
        }

        private void AppModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _ = AppModels.SerializeConfigAsync();
        }

        public void AddNewApp(DragEventArgs e)
        {
            try
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (var path in filePaths)
                {
                    AppModels.Add(new AppModel(path));
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
