using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SideMenu.Extensions;

namespace SideMenu.Service
{
    public class StartupLocation
    {
        private const int AnimationShiftValue = 100;
        
        public int X { get; set; }
        public int Y { get; set; }

        public int AnimationPositionShow { get; set; }
        public int AnimationPositionHide { get; set; }

        public StartupLocation()
        {

        }

        public StartupLocation(Window mainWindow)
        {
            InitializeStartupLocation(mainWindow);
        }

        public void InitializeStartupLocation(Window mainWindow)
        {
            X = GetLeftLocation();
            Y = GetTopLocation(mainWindow);

            AnimationPositionShow = X - 100;
            AnimationPositionHide = X;
        }

        public static void SaveCurrentPosition(Window mainWindow)
        {
            StartupLocation startupLocation = new StartupLocation();
            startupLocation.X = GetLeftLocation();
            startupLocation.Y = (int)mainWindow.Top;
            startupLocation.AnimationPositionShow = startupLocation.X - AnimationShiftValue;
            startupLocation.AnimationPositionHide = startupLocation.X;
            
            startupLocation.SerializeConfig();
        }

        private static int GetLeftLocation()
        {
            var totalWidth = Screen.AllScreens.Sum(x => x.Bounds.Width);
            return totalWidth - 2;
        }

        private static int GetTopLocation(Window mainWindow)
        {
            var height = Screen.AllScreens.Last().Bounds.Height;
            return (int)(height / 2 - (mainWindow.Height / 2));
        }
    }
}
