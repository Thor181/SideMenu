﻿using System.Reflection;
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

            MainWindowX.Loaded += MainWindowViewModel.AppLoaded;

            //InstallToStartup();

        }

        void InstallToStartup()
        {
            //TODO: Add check for autorun or not to task bar icon
            string subkeyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subkeyName, true);
            Assembly currentAssembly = Assembly.GetEntryAssembly();
            key.SetValue(currentAssembly.GetName().Name, currentAssembly.Location);
        }

        private void AppsStackPanel_Drop(object sender, DragEventArgs e)
        {
            MainWindowViewModel.AddNewApp(e);
        }
    }
}
