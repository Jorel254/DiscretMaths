using GoldenToolKit.Interfaces;
using MCD.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCD
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
