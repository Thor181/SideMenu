using System;
using System.Collections.ObjectModel;
using System.Windows;
using SideMenu.Models;
using SideMenu.Extensions;
using System.Windows.Threading;
using SideMenu.Views;
using System.Collections.Specialized;
using SideMenu.Service;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SideMenu.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<AppCard> AppCards { get; set; } = new ObservableCollection<AppCard>();

        public StartupLocation StartupLocation { get; set; }

        public CloseAppCommand CloseAppCommand { get; set; }

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            _ = InitializeComponents(dispatcher);
            CloseAppCommand = new CloseAppCommand();
        }

        private async Task InitializeComponents(Dispatcher dispatcher)
        {
            StartupLocation startupLocation = GetStartupLocation(dispatcher);

            Application.Current.MainWindow.Left = startupLocation.X;
            Application.Current.MainWindow.Top = startupLocation.Y;

            StartupLocation = startupLocation;

            await AppCards.DeserializeConfigAsync(dispatcher);
            AppCards.CollectionChanged += async delegate (object sender, NotifyCollectionChangedEventArgs e)
            {
                await AppCards.SerializeConfigAsync();
            };
        }

        private StartupLocation GetStartupLocation(Dispatcher dispatcher)
        {
            StartupLocation startupLocation = new StartupLocation();
            startupLocation.DeserializeConfigAsync(dispatcher);

            if (startupLocation.AnimationPositionHide + startupLocation.AnimationPositionShow + startupLocation.X + startupLocation.Y == 0)
            {
                startupLocation = new StartupLocation(Application.Current.MainWindow);
                startupLocation.SerializeConfigAsync();
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
