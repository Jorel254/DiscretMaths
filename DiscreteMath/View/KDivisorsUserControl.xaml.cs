using DiscreteMath.ViewModel;
using GoldenToolKit.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DiscreteMath.View
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
            Mydatagrid.ItemsSource = Model.CalculateDivisorK();
        }
    }
}
