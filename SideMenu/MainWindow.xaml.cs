using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ICO = System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SideMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MainWindowX.DataContext = new ViewModels.MainWindowViewModel();
        }

        private void AppsStackPanel_Drop(object sender, DragEventArgs e)
        {
            string fileName = (string)e.Data.GetData("FileName");
            ICO.Icon icon = ICO.Icon.ExtractAssociatedIcon(fileName);
            
            var JUST_BREAKPOINT = string.Empty;
        }
    }
}
