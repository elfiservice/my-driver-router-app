using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly IProvideTenantUseCase provideTenantUseCase;
    private readonly IViewLanguagesAvaliableUseCase viewLanguagesAvaliableUseCase;
    private readonly ISelectLanguageUseCase selectLanguageUseCase;

    public SettingsPage(
		IProvideTenantUseCase provideTenantUseCase,
		IViewLanguagesAvaliableUseCase viewLanguagesAvaliableUseCase,
		ISelectLanguageUseCase selectLanguageUseCase)
	{
		InitializeComponent();
		this.provideTenantUseCase = provideTenantUseCase;
		this.viewLanguagesAvaliableUseCase = viewLanguagesAvaliableUseCase;
		this.selectLanguageUseCase = selectLanguageUseCase;
	}

	async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		string newTenantValue = tenantEntry.Text;
		// DisplayAlert("Alert", $"You have been alerted {newTenantValue}, {newText}, {oldText}", "OK");
		await this.provideTenantUseCase.ExecuteAsync(newTenantValue);
		picker.ItemsSource = await this.viewLanguagesAvaliableUseCase.ExecuteAsync(newTenantValue) as Language[];
	}

	async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			// monkeyNameLabel.Text = picker.Items[selectedIndex];
			await DisplayAlert("Alert", $"Item selected: {selectedIndex}, {picker.Items[selectedIndex]}", "OK");
			await this.selectLanguageUseCase.ExecuteAsync(picker.Items[selectedIndex]);
		}
	}
}
