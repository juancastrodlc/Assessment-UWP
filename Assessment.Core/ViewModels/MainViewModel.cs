using CommunityToolkit.Mvvm.ComponentModel;

namespace Assessment.Core.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;
    }
}
