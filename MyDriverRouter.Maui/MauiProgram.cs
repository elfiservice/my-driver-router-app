using CommunityToolkit.Maui;
using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using MyDriverRouter.Maui.Pages;
using MyDriverRouter.Maui.Resources.Languages;
using MyDriverRouter.Plugins.DataStore.InMemory;
using MyDriverRouter.UseCases;
using MyDriverRouter.UseCases.PluginInterfaces;

namespace MyDriverRouter.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseLocalizationResourceManager(settings =>
			{
				settings.AddResource(AppResources.ResourceManager);
				settings.RestoreLatestCulture(true);
			})
			.UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<Ii18nRepository, I18nInMemoryRepository>();
		builder.Services.AddSingleton<ISettingsRepository, SettingsInMemoryRepository>();

		builder.Services.AddSingleton<IProvideTenantUseCase, ProvideTenantUseCase>();
		builder.Services.AddSingleton<ISelectLanguageUseCase, SelectLanguageUseCase>();
		builder.Services.AddSingleton<IViewLanguagesAvaliableUseCase, ViewLanguagesAvaliableUseCase>();

		builder.Services.AddSingleton<SettingsPage>();


		return builder.Build();
	}
}
