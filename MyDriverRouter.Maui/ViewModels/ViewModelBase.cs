using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace MyDriverRouter.Maui.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    protected ILogger? _logger;

    [ObservableProperty]
    string? _titlePage;
	
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    protected BaseViewModel(ILogger? logger = null)
    {
        _logger = logger;
    }
}

public abstract class BaseParameterViewModel<T> : BaseViewModel, IQueryAttributable
    where T : class, new()
{
    private T Parameters { get; set; } = new();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("Parameters", out var value)) return;

        Parameters = value as T ?? throw new NullReferenceException();
    }

    public T GetParameters()
    {
        return Parameters;
    }
}