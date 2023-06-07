using System;

using Assessment.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Assessment.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
