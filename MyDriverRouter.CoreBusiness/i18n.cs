using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDriverRouter.CoreBusiness;

public partial class i18n : ObservableObject
{
    [ObservableProperty]
    Language[] avaliableLanguages;
}
