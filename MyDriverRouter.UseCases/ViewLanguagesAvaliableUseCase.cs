using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases.PluginInterfaces;

namespace MyDriverRouter.UseCases;

public class ViewLanguagesAvaliableUseCase : IViewLanguagesAvaliableUseCase
{
    private readonly ISettingsRepository settingsRepository;

    public ViewLanguagesAvaliableUseCase(ISettingsRepository settingsRepository)
    {
        this.settingsRepository = settingsRepository;
    }

    public async Task<IEnumerable<Language>> ExecuteAsync(string tenant)
    {
        return await this.settingsRepository.GetLanguagesAvaliebles(tenant);
    }

}
