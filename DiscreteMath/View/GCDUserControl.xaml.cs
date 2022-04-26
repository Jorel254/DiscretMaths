using GoldenToolKit.Interfaces;
using System;

namespace DiscreteMath.View
{
    /// <summary>
    /// Interaction logic for GCDUserControl.xaml
    /// </summary>
    public partial class GCDUserControl : IUserControlInterface
    {
        public GCDUserControl()
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
