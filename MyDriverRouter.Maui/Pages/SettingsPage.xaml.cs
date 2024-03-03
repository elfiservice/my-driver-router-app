using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Maui.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly IProvideTenantUseCase provideTenantUseCase;

    public SettingsPage(IProvideTenantUseCase provideTenantUseCase)
	{
		InitializeComponent();
		this.provideTenantUseCase = provideTenantUseCase;
	}

	async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		string newTenantValue = tenantEntry.Text;
		// DisplayAlert("Alert", $"You have been alerted {newTenantValue}, {newText}, {oldText}", "OK");
		picker.ItemsSource = await this.provideTenantUseCase.ExecuteAsync(newTenantValue) as Language[];
	}
}
