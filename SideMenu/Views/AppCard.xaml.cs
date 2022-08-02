using IWshRuntimeLibrary;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SideMenu.Extensions;
using SideMenu.ViewModels;
using SideMenu.Models;

namespace SideMenu.Views
{
    public partial class AppCard : UserControl
    {
        public AppCardViewModel AppCardViewModel { get; set; }

        public AppCard(string appFilePath)
        {
            InitializeComponent();
            AppCardViewModel = new AppCardViewModel(new AppModel(appFilePath));
            DataContext = AppCardViewModel;
        }
    }
}
