using MyDriverRouter.CoreBusiness;

namespace MyDriverRouter.UseCases;


public interface IProvideTenantUseCase
{
    Task ExecuteAsync(string tenant);
}