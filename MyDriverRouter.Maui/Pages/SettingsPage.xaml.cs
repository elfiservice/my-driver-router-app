using LocalizationResourceManager.Maui;
using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly IProvideTenantUseCase _provideTenantUseCase;
    private readonly IViewLanguagesAvaliableUseCase _viewLanguagesAvailableUseCase;
    private readonly ISelectLanguageUseCase _selectLanguageUseCase;
    private readonly ILocalizationResourceManager _localizationResourceManager;

    public SettingsPage(
		IProvideTenantUseCase provideTenantUseCase,
		IViewLanguagesAvaliableUseCase viewLanguagesAvailableUseCase,
		ISelectLanguageUseCase selectLanguageUseCase,
		ILocalizationResourceManager localizationResourceManager)
	{
		InitializeComponent();
		this._provideTenantUseCase = provideTenantUseCase;
		this._viewLanguagesAvailableUseCase = viewLanguagesAvailableUseCase;
		this._selectLanguageUseCase = selectLanguageUseCase;
		this._localizationResourceManager = localizationResourceManager;
	}

	async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		string newTenantValue = tenantEntry.Text;
		// DisplayAlert("Alert", $"You have been alerted {newTenantValue}, {newText}, {oldText}", "OK");
		await this._provideTenantUseCase.ExecuteAsync(newTenantValue);
		languagePicker.ItemsSource = await this._viewLanguagesAvailableUseCase.ExecuteAsync(newTenantValue) as Language[];
	}

	async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		var language = picker.SelectedItem as Language;

		if (selectedIndex != -1 && language != null)
		{
			// _localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo(language.Code);
			
			// monkeyNameLabel.Text = picker.Items[selectedIndex];
			await DisplayAlert("Alert", $"Item selected: {selectedIndex}, {picker.Items[selectedIndex]}", "OK");
			// await this._selectLanguageUseCase.ExecuteAsync(picker.Items[selectedIndex]);
			await this._selectLanguageUseCase.ExecuteAsync(language);
		}
	}
}
