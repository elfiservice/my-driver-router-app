using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using MyDriverRouter.Maui.Services.Interfaces;

namespace MyDriverRouter.Maui.ViewModels;

public class BaseViewModelCtorParameters(
    ILoggerFactory loggerFactory,
    ILocalizationResourceManager localizationResourceManager,
    IAlertUserService alertUserService
)
{
    public readonly ILoggerFactory LoggerFactory = loggerFactory;
    public readonly ILocalizationResourceManager LocalizationResourceManager = localizationResourceManager;
    public readonly IAlertUserService AlertUserService = alertUserService;
}