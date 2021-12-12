using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
namespace ModuleA;
public class ModuleAModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        containerProvider.Resolve<IRegionManager>().RequestNavigate("MainRegion", nameof(ViewA));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA>();
    }
}
