using IWshRuntimeLibrary;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SideMenu.Extensions;

namespace SideMenu.Models
{
    public partial class AppCard : UserControl
    {

        public AppCard()
        {
            InitializeComponent();
        }
        public AppCard(string filePath) : this()
        {
            string appName = filePath.GetAppName();
            BitmapImage appImage = filePath.GetIcon();
            AppModel appModel = new AppModel(filePath, appName, appImage);
            DataContext = new ViewModels.AppModelViewModel(appModel);
        }
        
    }
}
