using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SideMenu.Extensions
{
    public static class Images
    {
        public static BitmapImage GetIcon(this string filePath)
        {
            Icon icon = filePath.Contains(".lnk", StringComparison.OrdinalIgnoreCase) ? Icon.ExtractAssociatedIcon(filePath.GetFilePathFromShortcut()) 
                                                                                      : Icon.ExtractAssociatedIcon(filePath);
            var bitmap = icon.ToBitmap();

            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
