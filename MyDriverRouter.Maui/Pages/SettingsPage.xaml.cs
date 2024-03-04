using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly IProvideTenantUseCase provideTenantUseCase;
    private readonly IViewLanguagesAvaliableUseCase viewLanguagesAvaliableUseCase;

    public SettingsPage(
		IProvideTenantUseCase provideTenantUseCase,
		IViewLanguagesAvaliableUseCase viewLanguagesAvaliableUseCase)
	{
		InitializeComponent();
		this.provideTenantUseCase = provideTenantUseCase;
		this.viewLanguagesAvaliableUseCase = viewLanguagesAvaliableUseCase;
	}

	async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		string newTenantValue = tenantEntry.Text;
		// DisplayAlert("Alert", $"You have been alerted {newTenantValue}, {newText}, {oldText}", "OK");
		await this.provideTenantUseCase.ExecuteAsync(newTenantValue);
		picker.ItemsSource = await this.viewLanguagesAvaliableUseCase.ExecuteAsync(newTenantValue) as Language[];
	}
}
