using SideMenu.Extensions;
using SideMenu.Service;
using System.Windows.Media.Imaging;

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
