using MyDriverRouter.Maui.Providers.Interfaces;

namespace MyDriverRouter.Maui.Providers;

public class CurrentShellProvider : ICurrentShellProvider
{
    public Shell CurrentShell => Shell.Current;
    public Page? CurrentPage => Shell.Current?.CurrentPage;
    public INavigation Navigation => Shell.Current.Navigation;

    public Task GoToAsync(ShellNavigationState shellNavigationState)
    {
        return Shell.Current.GoToAsync(shellNavigationState);
    }

    public Task GoToAsync(ShellNavigationState shellNavigationState, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(shellNavigationState, parameters);
    }

    public Task GoToAsync(string uri, bool animate)
    {
        return Shell.Current.GoToAsync(uri, animate);
    }
    
    public Task DisplayAlert(
        string message, string? title = "", string? acceptButtonLabel = "OK")
    {
        return Shell.Current.DisplayAlert(title, message, acceptButtonLabel);
    }
    
    public Task<bool> DisplayAlert(string message,
        string cancelButtonLabel, string title = "", string acceptButtonLabel = "OK")
    {
        return Shell.Current.DisplayAlert(title, message, acceptButtonLabel, cancelButtonLabel);
    }
}