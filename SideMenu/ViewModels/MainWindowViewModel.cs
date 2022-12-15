using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using SideMenu.Extensions;
using SideMenu.Service;
using SideMenu.Views;

namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<AppCard> AppCards { get; set; } 

        public StartupLocation StartupLocation { get; set; }

        public CloseAppCommand CloseAppCommand { get; set; }

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            AppCards = new ObservableCollection<AppCard>();

            InitializeComponents(dispatcher);
            CloseAppCommand = new CloseAppCommand();
        }

        private void InitializeComponents(Dispatcher dispatcher)
        {
            StartupLocation startupLocation = GetStartupLocation(dispatcher);

            Application.Current.MainWindow.Left = startupLocation.X;
            Application.Current.MainWindow.Top = startupLocation.Y;

            StartupLocation = startupLocation;

            AppCards.DeserializeConfig(dispatcher);
            AppCards.CollectionChanged += delegate (object sender, NotifyCollectionChangedEventArgs e)
            {
                AppCards.SerializeConfig();
            };
        }

        private StartupLocation GetStartupLocation(Dispatcher dispatcher)
        {
            StartupLocation startupLocation = new StartupLocation();
            startupLocation.DeserializeConfig(dispatcher);

            if (startupLocation.AnimationPositionHide + startupLocation.AnimationPositionShow + startupLocation.X + startupLocation.Y == 0)
            {
                startupLocation = new StartupLocation(Application.Current.MainWindow);
                startupLocation.SerializeConfig();
            }

            return startupLocation;
        }

        public void AddNewApp(DragEventArgs e)
        {
            try
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach (var path in filePaths)
                {
                    AppCards.Add(new AppCard(path));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
#if DEBUG
                throw;
#endif
            }
        }

        public void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (sender is Window window && e.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
            }
        }

        public void RemoveAppCard(string filePath)
        {
            AppCard removableItem = AppCards.Where(i => i.AppCardViewModel.AppModel.FilePath == filePath).FirstOrDefault();
            if (removableItem != null)
            {
                AppCards.Remove(removableItem);
            }
        }

        public void AppLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void InstallToStartup()
        {
            //TODO: Add check for autorun or not to task bar icon
            string subkeyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subkeyName, true);
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            key.SetValue(currentAssembly.GetName().Name, currentAssembly.Location);
        }
    }

    public class CustomDragMove
    {
        private static bool IsCaptured { get; set; }
        private static int AnchorPoint { get; set; }

        internal static void CustomLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Window window)
            {
                IsCaptured = true;
                e.Handled = true;
                AnchorPoint = (int)e.GetPosition(window).Y;
            }
        }

        internal static void CustomMouseMove(object sender, MouseEventArgs e)
        {
            if (IsCaptured && sender is Window window)
            {
                Point currentPosition = e.GetPosition(window);
                window.Top = window.Top + (currentPosition.Y - AnchorPoint);
            }
        }

        internal static void CustomLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Window window)
            {
                IsCaptured = false;
                e.Handled = true;
                StartupLocation.SaveCurrentPosition(window);
            }
        }
    }
}
