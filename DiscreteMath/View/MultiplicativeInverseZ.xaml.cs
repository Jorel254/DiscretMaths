using DiscreteMath.ViewModel;
using GoldenToolKit.Interfaces;
using System;
using System.Windows;

namespace DiscreteMath.View
{
    /// <summary>
    /// Interaction logic for MultiplicativeInverseZ.xaml
    /// </summary>
    public partial class MultiplicativeInverseZ : IUserControlInterface
    {
        public MultiplicativeInverseZViewModel Model { get; set; }
        public MultiplicativeInverseZ()
        {
            InitializeComponent();
            Model = new MultiplicativeInverseZViewModel();
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
            Mydatagrid.ItemsSource = Model.CalculateInversive();
            InverseGrid.ItemsSource = Model.InverseTable();
        }
    }
}
