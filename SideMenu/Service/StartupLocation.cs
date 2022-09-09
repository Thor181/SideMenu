using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideMenu.Service
{
    public class StartupLocation
    {
        public Point Location { get; set; }

        public int AnimationPositionShow { get; set; }
        public int AnimationPositionHide { get; set; }

        public StartupLocation()
        {
            InitializeStartupLocation();
        }

        public Point InitializeStartupLocation()
        {
            var totalWidth = Screen.AllScreens.Select(x => x.Bounds).GetSumWidth();
            var height = Screen.AllScreens.Last().Bounds.Height;

            Location = new Point(totalWidth - 2, height);

            AnimationPositionShow = (int)Location.X - 100;
            AnimationPositionHide = (int)Location.X;

            return Location;
        }
    }

    public static class ExtensionsLocation
    {
        public static int GetSumWidth(this IEnumerable<System.Drawing.Rectangle> rectangles)
        {
            int sum = 0;
            foreach (var item in rectangles)
            {
                sum += item.Width;
            }
            return sum;
        }
    }
}
