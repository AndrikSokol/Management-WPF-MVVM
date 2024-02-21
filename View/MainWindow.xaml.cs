using Inventory_managment.ViewModel;
using System.Windows;

namespace Inventory_managment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
        }

    }
}