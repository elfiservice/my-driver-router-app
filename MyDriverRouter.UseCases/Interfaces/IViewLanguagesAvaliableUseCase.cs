

using MyDriverRouter.CoreBusiness;

public interface IViewLanguagesAvaliableUseCase
{
    Task<IEnumerable<Language>> ExecuteAsync(string tenant);
}