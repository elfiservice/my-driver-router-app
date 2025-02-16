using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MyDriverRouter.CoreBusiness;
using MyDriverRouter.Maui.Controls;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.ViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    private readonly IProvideTenantUseCase _provideTenantUseCase;
    private readonly IViewLanguagesAvaliableUseCase _viewLanguagesAvailableUseCase;
    private readonly ISelectLanguageUseCase _selectLanguageUseCase;
    
    [ObservableProperty]
    Language? _selectedLanguage;
    
    [ObservableProperty]
    DropDownItemDto? _selectedLanguageDropDown;
    
    [ObservableProperty]
    List<Language>? _languages = new();
    
    [ObservableProperty]
    List<DropDownItemDto>? _languagesNewDropDown = new();

    [ObservableProperty] string _tenant = "";

    public SettingsPageViewModel(
        BaseViewModelCtorParameters baseCtorParams,
        IProvideTenantUseCase provideTenantUseCase,
        IViewLanguagesAvaliableUseCase viewLanguagesAvailableUseCase,
        ISelectLanguageUseCase selectLanguageUseCase)
    : base(baseCtorParams)
    {
        this._provideTenantUseCase = provideTenantUseCase;
        this._viewLanguagesAvailableUseCase = viewLanguagesAvailableUseCase;
        this._selectLanguageUseCase = selectLanguageUseCase;
    }

    [RelayCommand]
    public async Task OnEntryTextChanged(string newTenantValue)
    {
        LoggerBase.LogInformation("Tenant value changed to {newTenantValue}", newTenantValue);
        
        await this._provideTenantUseCase.ExecuteAsync(Tenant);
        var languages = await _viewLanguagesAvailableUseCase.ExecuteAsync(Tenant);
        var languagesNormalized = languages as Language[] ?? languages.ToArray();
        
        if (languagesNormalized.Any())
        {
            Languages = new List<Language>(languagesNormalized);

            LanguagesNewDropDown = new List<DropDownItemDto>(
                Languages.Select(language => new DropDownItemDto
                {
                    Description = language.Description,
                    Key = language.Code
                }));

        }
    }
    
    [RelayCommand]
    async Task OptionItemClicked()
    {
        var language = SelectedLanguage;
        
        if (language is null) return;
        
        await AlertUserServiceBase.ShowAsync( $"Item selected from Gesture: {language.Description}", "Alert");
        await _selectLanguageUseCase.ExecuteAsync(language);
    }
    
    [RelayCommand]
    async Task DropDownItemClicked()
    {
        var language = SelectedLanguageDropDown;
        
        if (language is null) return;
        
       await AlertUserServiceBase.ShowAsync($"Item selected from Gesture: {language.Description}", "Alert");

        var dropDowntoLanguage = new Language
        {
            Description = language.Description,
            Code = language.Key
        };
        
        await _selectLanguageUseCase.ExecuteAsync(dropDowntoLanguage);
    }
}