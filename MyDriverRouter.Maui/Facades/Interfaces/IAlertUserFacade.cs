namespace MyDriverRouter.Maui.Facades.Interfaces;

public interface IAlertUserFacade
{
    Task ShowAsync(string message, string? title = "", string? closeButtonLabel = "OK");

    Task<DisplayResults> ShowWithResultAsync(
        string title, string message, string acceptButtonLabel, string cancelButtonLabel);
}