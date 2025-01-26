using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;
using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.ViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    private readonly IProvideTenantUseCase _provideTenantUseCase;
    private readonly IViewLanguagesAvaliableUseCase _viewLanguagesAvailableUseCase;
    private readonly ISelectLanguageUseCase _selectLanguageUseCase;
    private readonly ILocalizationResourceManager _localizationResourceManager;
    
    [ObservableProperty]
    Language? _selectedLanguage;
    
    [ObservableProperty]
    List<Language>? _languages = new();

    [ObservableProperty] string _tenant = "";

    public SettingsPageViewModel(
        IProvideTenantUseCase provideTenantUseCase,
        IViewLanguagesAvaliableUseCase viewLanguagesAvailableUseCase,
        ISelectLanguageUseCase selectLanguageUseCase,
        ILocalizationResourceManager localizationResourceManager)
    {
        this._provideTenantUseCase = provideTenantUseCase;
        this._viewLanguagesAvailableUseCase = viewLanguagesAvailableUseCase;
        this._selectLanguageUseCase = selectLanguageUseCase;
        this._localizationResourceManager = localizationResourceManager;
    }

    [RelayCommand]
    public async Task OnEntryTextChanged(string newTenantValue)
    {
        await this._provideTenantUseCase.ExecuteAsync(Tenant);
        var languages = await _viewLanguagesAvailableUseCase.ExecuteAsync(Tenant);
        var languagesNormalized = languages as Language[] ?? languages.ToArray();
        
        if (languagesNormalized.Any())
        {
            Languages = new List<Language>(languagesNormalized);
        }
    }
    
    [RelayCommand]
    async Task OptionItemClicked()
    {
        var language = SelectedLanguage;
        
        if (language is null) return;
        
        await Shell.Current.DisplayAlert("Alert", $"Item selected from Gesture: {language.Description}", "OK");
        await _selectLanguageUseCase.ExecuteAsync(language);
    }
}