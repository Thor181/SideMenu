using System.Windows;
using System.Windows.Input;
using SideMenu.ViewModels;

namespace SideMenu
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                _mainWindowViewModel ??= new MainWindowViewModel(Dispatcher);
                return _mainWindowViewModel;
            }
            set { _mainWindowViewModel = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            MainWindowX.DataContext = MainWindowViewModel;

            MainWindowX.MouseLeftButtonDown += CustomDragMove.CustomLeftButtonDown;
            MainWindowX.MouseMove += CustomDragMove.CustomMouseMove;
            MainWindowX.MouseLeftButtonUp += CustomDragMove.CustomLeftButtonUp;

        }
        
        private void AppsStackPanel_Drop(object sender, DragEventArgs e)
        {
            MainWindowViewModel.AddNewApp(e);
        }
    }
}
