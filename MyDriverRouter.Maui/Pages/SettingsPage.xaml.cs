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

	// void OnTenantEntryCompleted(object sender, EventArgs e)
	// {
	// 	DisplayAlert("Alert", "You have been alerted", "OK");
	// 	string newTenantValue = ((Entry)sender).Text;
	// 	DisplayAlert("Alert", $"You have been alerted {newTenantValue}", "OK");
	// 	picker.ItemsSource = this.provideTenantUseCase.ExecuteAsync(newTenantValue).Result as Language[];
	// }
	// Completed="OnTenantEntryCompleted"

	async void OnEntryTextChanged(object sender, TextChangedEventArgs e)
	{
		// string oldText = e.OldTextValue;
		// string newText = e.NewTextValue;
		string newTenantValue = tenantEntry.Text;
		// DisplayAlert("Alert", $"You have been alerted {newTenantValue}, {newText}, {oldText}", "OK");
		picker.ItemsSource = await this.provideTenantUseCase.ExecuteAsync(newTenantValue) as Language[];
	}

	//                TextChanged="OnEntryTextChanged"
}