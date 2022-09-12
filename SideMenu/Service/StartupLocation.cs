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
            var totalWidth = Screen.AllScreens.Sum(x => x.Bounds.Width);
            var height = Screen.AllScreens.Last().Bounds.Height;

            X = totalWidth - 2;
            Y = (int)(height / 2 - (mainWindow.Height / 2));

            AnimationPositionShow = X - 100;
            AnimationPositionHide = X;
        }

        public static void SaveCurrentPosition(Window mainWindow)
        {
            StartupLocation startupLocation = new StartupLocation()
            {
                X = (int)mainWindow.Left,
                Y = (int)mainWindow.Top,
                AnimationPositionShow = (int)mainWindow.Left - 100,
                AnimationPositionHide = (int)mainWindow.Left
            };
            startupLocation.SerializeConfigAsync();
        }
    }
}
