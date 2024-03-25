using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDriverRouter.CoreBusiness;

public partial class Language : ObservableObject
{
    [ObservableProperty]
    string description;

    [ObservableProperty] 
    string code;

}
