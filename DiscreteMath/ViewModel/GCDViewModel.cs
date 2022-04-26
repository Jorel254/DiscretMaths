using GoldenToolKit;
using System.Windows.Input;

namespace DiscreteMath.ViewModel
{
    public class GCDViewModel : ModelBase
    {
        private int _a;

        public int a
        {
            get => _a;
            set
            {
                _a = value;
                OnPropertyChanged();
            }
        }
        private int _b;

        public int b
        {
            get => _b;
            set
            {
                _b = value;
                OnPropertyChanged();
            }
        }
        private int _q;

        public int q
        {
            get => _q;
            set
            {
                _q = value;
            }
        }
        private int _r;

        public int r
        {
            get => _r;
            set
            {
                _r = value;
            }
        }
        private int _ResulGCD;

        public int ResulGCD
        {
            get => _ResulGCD;
            set
            {
                _ResulGCD = value;
                OnPropertyChanged();
            }
        }

        public ICommand GCDCommand { get; set; }
        public GCDViewModel()
        {
            GCDCommand = new Command(CalculateGCD);
        }
        public void CalculateGCD(object obj)
        {
            var r2 = 0;
            int aux = 0;
            if (b > a)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            q = a / b;
            r = ModClass.ManualMod(a, b);
            r2 = r;
            if (r == 0)
            {
                ResulGCD = b;
            }
            else
            {
                q = b / r;
                r = ModClass.ManualMod(b, r);
                while (r != 0)
                {
                    aux = ModClass.ManualMod(r2, r);
                    r2 = r;
                    r = aux;
                }
                ResulGCD = r2;
            }
            //if (b > a)
            //{
            //    int temp = a;
            //    a= b;
            //    b= temp;
            //}
            //while (b != 0)
            //{
            //    r = ModClass.ManualMod(a, b);
            //    a = b;
            //    b = r;
            //}
            //ResulGCD = a;
        }
    }
}
