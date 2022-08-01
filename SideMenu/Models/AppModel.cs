using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SideMenu.Models
{
    public class AppModel
    {
        public string FileName { get; set; }
        public string AppName { get; set; }
        public BitmapImage AppImage { get; set; }

        public AppModel(string filePath, string appName, BitmapImage appImage)
        {
            FileName = filePath;
            AppName = appName;
            AppImage = appImage;
        }
    }
}
