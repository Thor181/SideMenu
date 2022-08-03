using System.Drawing;
using System.Windows.Controls;
using SideMenu.ViewModels;
using SideMenu.Models;
using System.Windows.Controls.Primitives;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace SideMenu.Views
{
    public partial class AppCard : UserControl
    {
        public AppCardViewModel AppCardViewModel { get; set; }
        private static string _appFilePath;

        private static Popup _popupInstance;
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



        public AppCard()
        {
            InitializeComponent();
        }
        public AppCard(string appFilePath) : this()
        {
            AppCardViewModel = new AppCardViewModel(new AppModel(appFilePath));
            _appFilePath = appFilePath;
            DataContext = AppCardViewModel;
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed && ((AppCard)e.Source).Parent != PopupDrag)
            {
                PopupDrag.SetPopupOffset();
                if (!MainGrid.Children.Contains(PopupDrag))
                {
                    MainGrid.Children.Add(PopupDrag);
                }
            }
        }
    }

    public static class Extensions
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out Point point);

        public static void SetPopupOffset(this Popup popup)
        {
            GetCursorPos(out System.Drawing.Point mousePointOfScreen);
            popup.HorizontalOffset = mousePointOfScreen.X;
            popup.VerticalOffset = mousePointOfScreen.Y;
        }

    }
}
