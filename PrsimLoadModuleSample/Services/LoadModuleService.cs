namespace PrsimLoadModuleSample.Services;
public class LoadModuleService
{
    private IModuleCatalog _moduleCatalog;
    private IModuleManager _moduleManager;
    private IRegionManager _regionManager;

    public LoadModuleService(IModuleCatalog moduleCatalog, IModuleManager moduleManager, IRegionManager regionManager)
    {
        _moduleCatalog = moduleCatalog;
        _moduleManager = moduleManager;
        _regionManager = regionManager;
    }
    public void LoadModule(string moduleFileName)
    {
        try
        {
            var path = Path.Combine(Environment.CurrentDirectory, moduleFileName + ".dll");
            var asm = Assembly.LoadFrom(path);
            var type = asm.GetTypes().First(x => x.IsAssignableTo(typeof(IModule)));
            if (_moduleCatalog.Exists(type.Name))
            {
                return;
            }
            _moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = type.Name,
                ModuleType = type.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable,
                Ref = new Uri(type.Assembly.Location).AbsoluteUri,
            });
            _moduleManager.LoadModule(type.Name);
        }
        catch (Exception)
        {
            _regionManager.RequestNavigate("MainRegion", nameof(Views.ModuleNotFound), new NavigationParameters() { { "Name", moduleFileName } });
        }
    }
}
