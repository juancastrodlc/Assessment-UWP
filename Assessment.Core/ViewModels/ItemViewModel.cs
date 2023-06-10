using Assessment.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Drawing;

namespace Assessment.Core.ViewModels
{
    public partial class ItemViewModel : ObservableObject
    {
        private object lockobject = new();
        private bool updating;
        [ObservableProperty]
        Item item = new();

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string imageUri;

        [ObservableProperty]
        Color? color;

        partial void OnNameChanged(string value)
        {
            if (updating)
            {
                return;
            }
            lock (lockobject)
            {
                if (updating)
                {
                    return;
                }
                Item.Name = value;
            }
        }

        partial void OnImageUriChanged(string value)
        {
            if (updating)
            {
                return;
            }
            lock (lockobject)
            {
                if (updating)
                {
                    return;
                }
                Item.ImageUri = value;
            }
        }

        partial void OnColorChanged(Color? value)
        {
            if (updating)
            {
                return;
            }
            lock (lockobject)
            {
                if (updating)
                {
                    return;
                }
                Item.Color = value;
            }
        }

        partial void OnItemChanged(Item value)
        {
            updating = true;
            try
            {
                Name = value.Name;
                ImageUri = value.ImageUri;
                Color = value.Color;
            }
            finally
            {
                updating = false;
            }
        }
    }
}
