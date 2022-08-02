using SideMenu.Models;
using SideMenu.Service;

namespace SideMenu.ViewModels
{
    public class AppCardViewModel
    {
        public string AppName { get; set; }
        public BitmapImage AppImage { get; set; }

        public RunAppCommand ClickCommand { get; set; }

        public AppCardViewModel(Models.AppModel appModel)
        {
            AppModel = appModel;
            ClickCommand = new RunAppCommand(AppModel.FilePath);
        }
    }
}
