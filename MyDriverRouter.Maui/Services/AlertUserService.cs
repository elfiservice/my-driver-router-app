using MyDriverRouter.Maui.Providers.Interfaces;
using MyDriverRouter.Maui.Services.Interfaces;

namespace MyDriverRouter.Maui.Services;

public sealed record DisplayResults(string Type)
{
    public static DisplayResults IsOpened  { get; } = new("IsOpened");
    public static DisplayResults IsClosed  { get; } = new("IsClosed");
    public static DisplayResults IsAccepted  { get; } = new("IsAccepted");
}

public class AlertUserService(
    ICurrentShellProvider currentShellProvider) : IAlertUserService
{
    bool _isAlertOpen = false;
    
    public async Task ShowAsync(string message, string? title = "", string? closeButtonLabel = "OK")
    {
        if (_isAlertOpen)
        {
            return;
        }

        _isAlertOpen = true;
        await currentShellProvider.DisplayAlert(
            title: title, message: message, acceptButtonLabel: closeButtonLabel);
        _isAlertOpen = false;
    }
    
    public async Task<DisplayResults> ShowWithResultAsync(
        string title, string message, string acceptButtonLabel, string cancelButtonLabel)
    {
        if (_isAlertOpen)
        {
            return DisplayResults.IsOpened;
        }

        _isAlertOpen = true;
        
        var result = await currentShellProvider
            .DisplayAlert(message, cancelButtonLabel: title, title: cancelButtonLabel, acceptButtonLabel: acceptButtonLabel);
        
        _isAlertOpen = false;
        
        return result ? DisplayResults.IsAccepted : DisplayResults.IsClosed;
    }
}