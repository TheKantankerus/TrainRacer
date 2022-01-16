using System.Linq;
using System.Windows;
using TrainRacer.Contract;

namespace TrainRacer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetRaceClick(object sender, RoutedEventArgs e)
        {
            foreach (ISelectable? item in AvailableTrainsListView.Items.OfType<ISelectable>())
            {
                item.IsSelected = false;
            }
        }
    }
}
