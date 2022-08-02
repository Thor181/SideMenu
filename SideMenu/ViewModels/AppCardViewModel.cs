using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SideMenu.Service;

namespace SideMenu.ViewModels
{
    public class AppCardViewModel
    {
        public string AppName { get; set; }
        public BitmapImage AppImage { get; set; }

        public Command ClickCommand { get; set; } = new Command();

        public AppCardViewModel(Models.AppModel appModel)
        {
            AppName = appModel.AppName;
            AppImage = appModel.AppImage;
        }
    }
}
