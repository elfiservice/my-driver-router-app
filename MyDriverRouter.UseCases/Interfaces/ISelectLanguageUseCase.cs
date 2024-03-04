namespace MyDriverRouter.UseCases;

public interface ISelectLanguageUseCase
{
    Task ExecuteAsync(string language);
}
