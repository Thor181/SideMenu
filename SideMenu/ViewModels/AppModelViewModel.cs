using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SideMenu.ViewModels
{
    public class AppModelViewModel
    {
        public string AppName { get; set; } = "str";
        public BitmapImage AppImage { get; set; }

        public AppModelViewModel(string appName, BitmapImage appImage)
        {
            AppName = appName;
            AppImage = appImage;
        }
    
    }

}
