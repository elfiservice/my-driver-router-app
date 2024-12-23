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
			.UseMauiCommunityToolkit()
			.RegisterUseCases()
			.RegisterPages()
			.RegisterRepositories();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		
		return builder.Build();
	}
	
	static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<SettingsPage>();
		
		return mauiAppBuilder;
	}
	
	static MauiAppBuilder RegisterRepositories(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<Ii18nRepository, I18nInMemoryRepository>();
		mauiAppBuilder.Services.AddSingleton<ISettingsRepository, SettingsInMemoryRepository>();
		
		return mauiAppBuilder;
	}

	static MauiAppBuilder RegisterUseCases(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<IProvideTenantUseCase, ProvideTenantUseCase>();
		mauiAppBuilder.Services.AddSingleton<ISelectLanguageUseCase, SelectLanguageUseCase>();
		mauiAppBuilder.Services.AddSingleton<IViewLanguagesAvaliableUseCase, ViewLanguagesAvaliableUseCase>();
		
		return mauiAppBuilder;
	}
}
