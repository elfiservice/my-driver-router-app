using Microsoft.Extensions.Logging;
using MyDriverRouter.Maui.ViewModels;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(ILogger<SettingsPage> logger, SettingsPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}
