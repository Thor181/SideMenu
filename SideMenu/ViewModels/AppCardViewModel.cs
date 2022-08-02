using SideMenu.Models;
using SideMenu.Service;

namespace SideMenu.ViewModels
{
    public class AppCardViewModel
    {
        public AppModel AppModel { get; set; }

        public RunAppCommand ClickCommand { get; set; }

        public AppCardViewModel(AppModel appModel)
        {
            AppModel = appModel;
            ClickCommand = new RunAppCommand(AppModel.FilePath);
        }
    }
}
