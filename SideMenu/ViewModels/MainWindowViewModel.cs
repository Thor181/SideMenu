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
        public ObservableCollection<AppModel> AppModels { get; set; }
        
    }
}
