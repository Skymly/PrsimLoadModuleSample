using Prism.Commands;
using PrsimLoadModuleSample.Services;
namespace PrsimLoadModuleSample.ViewModels;
public class MainWindowViewModel : BindableBase
{
    private readonly LoadModuleService _loadModuleService;
    public MainWindowViewModel(LoadModuleService loadModuleService)
    {
        _loadModuleService = loadModuleService;
        LoadModuleCommand = new(LoadModule);
    }
    public DelegateCommand<string> LoadModuleCommand { get; set; }
    private void LoadModule(string moduleFileName)
    {
        _loadModuleService.LoadModule(moduleFileName);
    }
}
