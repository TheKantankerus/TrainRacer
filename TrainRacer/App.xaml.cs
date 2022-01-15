using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using TrainRacer.Contract;
using TrainRacer.Core;

namespace TrainRacer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRaceController, RaceController>();
            containerRegistry.RegisterSingleton<ITrainController, TrainController>();

            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>
        }
    }
}
