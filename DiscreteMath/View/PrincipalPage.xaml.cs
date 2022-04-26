using GoldenToolKit.Interfaces;
using System;
using System.Windows.Controls;

namespace DiscreteMath.View
{
    /// <summary>
    /// Interaction logic for PrincipalPage.xaml
    /// </summary>
    public partial class PrincipalPage : UserControl, IUserControlInterface
    {
        public PrincipalPage()
        {
            InitializeComponent();
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
    }
}
