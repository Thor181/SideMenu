using IWshRuntimeLibrary;
using System.Linq;

namespace SideMenu.Extensions
{
    public static class Paths
    {
        public static string GetAppName(this string filePath)
        {
            return filePath.Split("\\").Last().Split('.').First();
        }

        public static string GetFilePathFromShortcut(this string shortcutPath)
        {
            WshShell wshShell = new WshShell();
            WshShortcut wshShortcut = (WshShortcut)wshShell.CreateShortcut(shortcutPath);
            return wshShortcut.TargetPath;
        }
    }
    
}
