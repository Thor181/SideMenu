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
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MainWindowX.DataContext = new ViewModels.MainWindowViewModel();
        }

        private void AppsStackPanel_Drop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            AppsStackPanel.Children.Add(new Models.AppCard(filePath));
            
            
            
        }
    }
}
