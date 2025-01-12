using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using MyDriverRouter.CoreBusiness;
using MyDriverRouter.Maui.ViewModels;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(ILogger<SettingsPage> logger, SettingsPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
    
    async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        var language = picker.SelectedItem as Language;

        if (BindingContext is SettingsPageViewModel viewModel)
        {
            await viewModel.OnPickerSelectedIndexChanged(selectedIndex, language);
        }
    }
}
