﻿using Assessment.Helpers;
using Assessment.Services;
using Assessment.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Assessment.Views
{
    public sealed partial class ImageGalleryDetailPage : Page
    {
        public ImageGalleryDetailViewModel ViewModel { get; } = new ImageGalleryDetailViewModel();

        public ImageGalleryDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataAsync();
            ViewModel.Initialize(e.Parameter as string, e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedImage);
                ImagesNavigationHelper.RemoveImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
            }
        }

        private void OnPageKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                e.Handled = true;
            }
        }
    }
}
