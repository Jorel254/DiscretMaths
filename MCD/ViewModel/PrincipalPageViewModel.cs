using GoldenToolKit;
using MCD.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Views;

namespace MCD.ViewModel
{
    public class PrincipalPageViewModel : ModelBase
    {
        public ICommand ModuleCommand { get; set; }
        public ICommand ZCommand { get; set; }
        public ICommand KCommand { get; set; }
        public ICommand GCommand { get; set; }
        public ICommand EuclidesCommand { get; set; }
        public ICommand EquationCommand { get; set; }
        public ICommand EuclidesPolinomianCommand { get; set; }
        public PrincipalPageViewModel()
        {
            ModuleCommand = new Command(ModulePage);
            ZCommand = new Command(ZPage);
            KCommand = new Command(KPage);
            GCommand = new Command(GPage);
            EuclidesCommand = new Command(EuclidesPage);
            EquationCommand = new Command(EquationPage);
            EuclidesPolinomianCommand = new Command(EuclidesPPage);
        }

        private void EuclidesPPage(object obj) => MasterControl.Current.Navegar<EuclidesPolinomiosUserControl>();

        private void GPage(object obj) => MasterControl.Current.Navegar<GCDUserControl>();

        private void KPage(object obj) => MasterControl.Current.Navegar<KDivisorsUserControl>();

        private void ZPage(object obj) => MasterControl.Current.Navegar<MultiplicativeInverseZ>();

        private void ModulePage(object obj) => MasterControl.Current.Navegar<ModUserControl>();

        private void EuclidesPage(object obj) => MasterControl.Current.Navegar<EuclidesInverseMultiplicativeView>();
        private void EquationPage(object obj) => MasterControl.Current.Navegar<CongruencesView>();

    }
}
