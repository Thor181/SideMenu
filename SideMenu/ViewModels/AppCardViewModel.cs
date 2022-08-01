using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SideMenu.ViewModels
{
    public class AppCardViewModel
    {
        public string AppName { get; set; }
        public BitmapImage AppImage { get; set; }

        public AppCardViewModel(Models.AppModel appModel)
        {
            AppName = appModel.AppName;
            AppImage = appModel.AppImage;
        }


    }
}
