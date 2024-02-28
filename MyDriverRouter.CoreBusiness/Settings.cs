using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDriverRouter.CoreBusiness;

public partial class Settings : ObservableObject
{
    [ObservableProperty]
    string lastTenantProvided;
}
