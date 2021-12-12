using Prism.Ioc;

using PrsimLoadModuleSample.ViewModels;
using PrsimLoadModuleSample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrsimLoadModuleSample
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleNotFound,ModuleNotFoundViewModel>();
        }
    }
}
