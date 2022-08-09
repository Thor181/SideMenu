using SideMenu.Models;
using SideMenu.Service;
using SideMenu.Views;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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

        private static Popup _popupInstance;
        private static string _appFilePath;
        public static Popup PopupDrag
        {
            get
            {
                if (_popupInstance == null)
                {
                    _popupInstance = new Popup()
                    {
                        Child = new AppCard(_appFilePath) { Opacity = 0.4 },
                        AllowsTransparency = true,
                        StaysOpen = true,
                        IsOpen = true,
                        Placement = PlacementMode.AbsolutePoint
                    };
                }
                return _popupInstance;
            }
            set { _popupInstance = value; }
        }

        public void PopupViewDrag(MouseEventArgs e, Grid grid, string appFilePath)
        {
            _appFilePath = appFilePath;
            if (e.LeftButton == MouseButtonState.Pressed && ((AppCard)e.Source).Parent != PopupDrag)
            {
                PopupDrag.SetPopupOffset(); 
                if (!grid.Children.Contains(PopupDrag))
                {
                    grid.Children.Add(PopupDrag);
                }
            }
        }

        public void RemovePopupViewDrag(Grid grid)
        {
            grid.Children.Remove(PopupDrag);
            PopupDrag.IsOpen = false;
            PopupDrag = null;
            

            
        }

    }
    public static class Extensions
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out System.Drawing.Point point);

        public static void SetPopupOffset(this Popup popup)
        {
            GetCursorPos(out System.Drawing.Point mousePointOfScreen);
            popup.HorizontalOffset = mousePointOfScreen.X;
            popup.VerticalOffset = mousePointOfScreen.Y;
        }
    }
}
