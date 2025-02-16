using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using MyDriverRouter.Maui.Facades.Interfaces;

namespace MyDriverRouter.Maui.ViewModels;

public class BaseViewModelCtorParameters(
    ILoggerFactory loggerFactory,
    ILocalizationResourceManager localizationResourceManager,
    IAlertUserFacade alertUserFacade
)
{
    public readonly ILoggerFactory LoggerFactory = loggerFactory;
    public readonly ILocalizationResourceManager LocalizationResourceManager = localizationResourceManager;
    public readonly IAlertUserFacade AlertUserFacade = alertUserFacade;
}