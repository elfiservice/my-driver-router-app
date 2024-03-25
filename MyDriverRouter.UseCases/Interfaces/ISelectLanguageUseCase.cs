using MyDriverRouter.CoreBusiness;

namespace MyDriverRouter.UseCases;

public interface ISelectLanguageUseCase
{
    Task ExecuteAsync(Language language);
}
