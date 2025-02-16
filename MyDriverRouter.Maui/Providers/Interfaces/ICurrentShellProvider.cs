namespace MyDriverRouter.Maui.Providers.Interfaces;

public interface ICurrentShellProvider
{
    Shell CurrentShell { get; }
    Page? CurrentPage { get; }
    INavigation Navigation { get; }

    Task GoToAsync(ShellNavigationState shellNavigationState);
    Task GoToAsync(ShellNavigationState shellNavigationState, IDictionary<string, object> parameters);
    Task GoToAsync(string uri, bool animate);

    Task DisplayAlert(
        string message, string? title = "", string? acceptButtonLabel = "OK");
    Task<bool> DisplayAlert(string message,
        string cancelButtonLabel, string title = "", string acceptButtonLabel = "OK");
}