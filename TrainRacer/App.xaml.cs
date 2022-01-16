using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using TrainRacer.Contract;
using TrainRacer.Core.Controllers;
using TrainRacer.Core.Models.Tracks;
using TrainRacer.Core.Models.Trains;
using TrainRacer.Core.Services;

namespace TrainRacer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRaceController, RaceController>();
            containerRegistry.RegisterSingleton<ITrainDriverService, TrainDriverService>();

            containerRegistry.RegisterSingleton<ITrain, StandardSteam>(nameof(StandardSteam));
            containerRegistry.RegisterSingleton<ITrain, SuperSteam>(nameof(SuperSteam));
            containerRegistry.RegisterSingleton<ITrain, ShinyDiesel>(nameof(ShinyDiesel));
            containerRegistry.RegisterSingleton<ITrain, OddElectric>(nameof(OddElectric));

            containerRegistry.RegisterSingleton<ITrack, DefaultTrack>(nameof(DefaultTrack));

            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
        }
    }
}
