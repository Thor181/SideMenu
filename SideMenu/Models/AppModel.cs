using System.IO;
using System.Windows.Media.Imaging;

using SideMenu.Extensions;

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
            //TODO: realize individual file to path to custom pictures
            if (Directory.Exists(filePath))
            {
                AppImage = new BitmapImage(new System.Uri("\\Resources\\folder.png", System.UriKind.Relative));
                return;
            }

            AppImage = filePath.GetIcon();
        }
    }
}
