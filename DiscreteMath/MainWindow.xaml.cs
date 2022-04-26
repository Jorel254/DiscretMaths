using DiscreteMath.View;
using System.Windows;

namespace DiscreteMath
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            App.mainWindow = this;
            InitializeComponent();
            this.Navigation.Navegar(new PrincipalPage());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Navigation.Navegar(this.Navigation.GoBack());
        }
    }
}
