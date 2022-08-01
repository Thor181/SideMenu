using SideMenu.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace SideMenu.Models
{
    public class AppModel
    {
        public string FilePath { get; set; }
        public string AppName { get; set; }
        public BitmapImage AppImage { get; set; }

        public AppModel(string filePath)
        {
            FilePath = filePath;
            AppName = filePath.GetAppName();
            AppImage = filePath.GetIcon();
        }
    }
}
