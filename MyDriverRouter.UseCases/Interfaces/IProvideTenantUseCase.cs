namespace MyDriverRouter.UseCases;


public interface IProvideTenantUseCase
{
    Task<IEnumerable<string>> ExecuteAsync(string tenant);
}