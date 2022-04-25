using GoldenToolKit.Interfaces;
using MCD.ViewModel;
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

namespace MCD.View
{
    /// <summary>
    /// Interaction logic for KDivisorsUserControl.xaml
    /// </summary>
    public partial class KDivisorsUserControl : UserControl, IUserControlInterface
    {
        public KDivisorsViewModel Model { get; set; }
        public KDivisorsUserControl()
        {
            InitializeComponent();
            Model = new KDivisorsViewModel();
            DataContext = Model;
        }

        public void OnHidden()
        {
            throw new NotImplementedException();
        }

        public void OnMessageReceived(string json)
        {
            throw new NotImplementedException();
        }

        public void OnMessageReceived(object obj)
        {
            throw new NotImplementedException();
        }

        public void OnShown()
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mydatagrid.ItemsSource = null;
            Mydatagrid.ItemsSource= Model.CalculateDivisorK();
        }
    }
}
