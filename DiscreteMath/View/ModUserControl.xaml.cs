using GoldenToolKit.Interfaces;
using System;
using System.Windows.Controls;

namespace DiscreteMath.View
{
    /// <summary>
    /// Interaction logic for ModUserControl.xaml
    /// </summary>
    public partial class ModUserControl : UserControl, IUserControlInterface
    {
        public ModUserControl()
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
            //throw new NotImplementedException();
        }
    }
}
