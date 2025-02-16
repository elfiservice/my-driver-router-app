using MyDriverRouter.Maui.Facades.Interfaces;

namespace MyDriverRouter.Maui.Facades;

public record DisplayResults(string Type)
{
    public static DisplayResults IsOpened  { get; } = new("IsOpened");
    public static DisplayResults IsClosed  { get; } = new("IsClosed");
    public static DisplayResults IsAccepted  { get; } = new("IsAccepted");
}

public class AlertUserFacade : IAlertUserFacade
{
    bool _isAlertOpen = false;
    
    public async Task ShowAsync(string message, string? title = "", string? closeButtonLabel = "OK")
    {
        if (_isAlertOpen)
        {
            return;
        }

        _isAlertOpen = true;
        await Shell.Current.DisplayAlert(title, message, closeButtonLabel);
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
        var result = await Shell.Current.DisplayAlert(title, message, acceptButtonLabel, cancelButtonLabel);
        _isAlertOpen = false;
        
        return result ? DisplayResults.IsAccepted : DisplayResults.IsClosed;
    }
}