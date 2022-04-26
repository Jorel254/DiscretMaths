using Kit.WPF;
using System.Windows;

namespace DiscreteMath
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new MainWindow mainWindow { get; set; }
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Tools.Init();
        }
    }
}
