namespace PrsimLoadModuleSample.ViewModels;

public class ModuleNotFoundViewModel : BindableBase, Prism.Regions.INavigationAware
{
    private string name;
    public string Name { get => name; set => SetProperty(ref name, value); }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        Name = navigationContext.Parameters.GetValue<string>("Name");
    }
}
