﻿using System.Windows.Controls;
using System.Windows.Input;

using SideMenu.Models;
using SideMenu.ViewModels;

namespace SideMenu.Views
{
    public partial class AppCard : UserControl
    {
        public AppCardViewModel AppCardViewModel { get; set; }
        private string _appFilePath;

        public AppCard()
        {
            InitializeComponent();
        }

        public AppCard(string appFilePath) : this()
        {
            AppCardViewModel = new AppCardViewModel(new AppModel(appFilePath));
            _appFilePath = appFilePath;
            DataContext = AppCardViewModel;
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            AppCardViewModel.PopupViewDrag(e, MainGrid, _appFilePath);
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);
            AppCardViewModel.RemovePopupViewDrag(MainGrid);
        }
    }
}
