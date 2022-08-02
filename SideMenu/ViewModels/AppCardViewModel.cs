using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SideMenu.Models;
using SideMenu.Service;

namespace SideMenu.ViewModels
{
    public class AppCardViewModel
    {
        public AppModel AppModel { get; set; }

        //public Command ClickCommand { get; set; } = new Command();

        public AppCardViewModel(AppModel appModel)
        {
            AppModel = appModel;
        }
    }
}
