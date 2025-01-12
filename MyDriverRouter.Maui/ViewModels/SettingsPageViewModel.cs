using System.Collections.ObjectModel;
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
    Language _selectedLanguage;
    
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
        var langs = await _viewLanguagesAvailableUseCase.ExecuteAsync(Tenant);
        if (langs != null)
        {
            Languages = new List<Language>(langs);
        }
    }
    
    public async Task OnPickerSelectedIndexChanged(int selectedIndex, Language language)
    {
        if (selectedIndex != -1 && language != null)
        {
            await Shell.Current.DisplayAlert("Alert", $"Item selected: {selectedIndex}, {language.Description}", "OK");
            
            await this._selectLanguageUseCase.ExecuteAsync(language);
        }
    }
}