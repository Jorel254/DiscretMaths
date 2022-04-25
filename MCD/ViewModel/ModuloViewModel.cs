using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCD.ViewModel
{

    internal class ModuloViewModel : ModelBase
    {
        private int valor;
        private int modValue;
        private string? moduleResult;

        public int Valor
        {
            get => valor;
            set
            {
                valor=value;
                OnPropertyChanged();
            }
        }
        public int ModValue
        {
            get => modValue;
            set
            {
                modValue=value;
                OnPropertyChanged();
            }
        }
        public string? ModuleResult
        {
            get => moduleResult;
            set
            {
                moduleResult=value;
                OnPropertyChanged();
            }
        }
        public ICommand ModCommand { get; set; }
        public ModuloViewModel()
        {
            Valor = 0;
            ModValue = 0;
            ModCommand = new Command(CalculateMod);
        }

        private void CalculateMod(object obj)
        {
            if (ModValue == 0)
            {
                ModuleResult="NaN";
            }
            else
            {
                ModuleResult = $"{Valor} Mod {ModValue} = {ModClass.ManualMod(Valor, ModValue)}";
                // ModuleResult =$"{Valor} Mod {ModValue} = {Valor % ModValue}";

            }
        }
    }
    
}
