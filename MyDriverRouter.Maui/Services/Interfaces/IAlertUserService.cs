namespace MyDriverRouter.Maui.Services.Interfaces;

public interface IAlertUserService
{
    Task ShowAsync(string message, string? title = "", string? closeButtonLabel = "OK");

    Task<DisplayResults> ShowWithResultAsync(
        string title, string message, string acceptButtonLabel, string cancelButtonLabel);
}