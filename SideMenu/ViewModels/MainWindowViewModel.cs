using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SideMenu.Models;
using SideMenu.Extensions.Serialization;

namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<AppModel> AppModels { get; set; } = new ObservableCollection<AppModel>();
        List<AppModel> listAppModels = new List<AppModel>();
        public MainWindowViewModel()
        {
            AppModels.CollectionChanged += AppModels_CollectionChanged;
        }

        private void AppModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            AppModels.Serialize();
        }

        public void AddNewApp(DragEventArgs e)
        {
            try
            {
                string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                AppModels.Add(new AppModel(filePath));
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
