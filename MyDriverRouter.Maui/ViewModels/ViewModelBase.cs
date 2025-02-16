using CommunityToolkit.Mvvm.ComponentModel;
using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using MyDriverRouter.Maui.Facades.Interfaces;

namespace MyDriverRouter.Maui.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    protected ILogger? _logger;
    public ILogger LoggerBase { get; set; }
    public ILocalizationResourceManager LocalizationResourceManagerBase { get; set; }
    public IAlertUserFacade AlertUserFacadeBase { get; set; }

    [ObservableProperty]
    string? _titlePage;
	
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    protected BaseViewModel(
        BaseViewModelCtorParameters baseCtorParams,
        ILogger? logger = null)
    {
        _logger = logger;

        LoggerBase = baseCtorParams.LoggerFactory.CreateLogger(this.GetType());
        LocalizationResourceManagerBase = baseCtorParams.LocalizationResourceManager;
        AlertUserFacadeBase = baseCtorParams.AlertUserFacade;
    }
}

public abstract class BaseParameterViewModel<T>(
    BaseViewModelCtorParameters baseCtorParams,
    ILogger? logger = null) 
        : BaseViewModel(baseCtorParams, logger), IQueryAttributable
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