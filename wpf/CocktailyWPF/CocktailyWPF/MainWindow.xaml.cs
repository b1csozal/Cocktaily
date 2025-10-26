using CocktailyWPF.Extensions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CocktailyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Attach Loaded event
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!SessionStorage.Has("Token"))
            {
                var loginWindow = new LoginWindow();

                // Set the owner AFTER MainWindow has been loaded
                loginWindow.Owner = this;
                loginWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                // Open as modal dialog
                loginWindow.ShowDialog();
            }

            MainFrame.Navigate(new Pages.HomePage());
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.HomePage());
        }

        private void GoAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AllRecipesPage());
        }

        private void GoPending_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PendingRecipesPage());
        }
    }
}