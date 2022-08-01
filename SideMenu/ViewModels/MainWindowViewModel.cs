using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SideMenu.Models;


namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        private ObservableCollection<AppModel> _appModels;

        public ObservableCollection<AppModel> AppModels
        {
            get; set;
        }



        public MainWindowViewModel()
        {
            AppModels.CollectionChanged += AppModels_CollectionChanged;
        }

        private void AppModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }

        public void AddNewApp(DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            AppModels.Add(new AppModel(filePath));




            //AppsStackPanel.Children.Add(new Views.AppCard(filePath));

        }


    }
}
