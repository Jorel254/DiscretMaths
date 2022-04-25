using GoldenToolKit;
using MCD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCD.ViewModel
{
    public class KDivisorsViewModel: ModelBase
    {
        private int _FirstValue;
        private int _SecondValue;
        public int FirstValue
        {
            get
            {
                return _FirstValue;
            }
            set
            {
                _FirstValue = value;
                OnPropertyChanged();
            }
        }


        public int SecondValue
        {
            get
            {
                return _SecondValue;
            }
            set
            {
                _SecondValue = value;
                OnPropertyChanged();
            }
        }
        public DataTable dT { get; set; }
        List<DataColumn> columns;
        public List<Divisor> Divisors { get; set; }
        public ICommand ZInverseCommand { get; set; }

        public KDivisorsViewModel()
        {
            dT = new DataTable();
            Divisors = new ();
            columns = new List<DataColumn>();
        }

        public DataView CalculateDivisorK()
        {
            dT.Clear();
            dT.Columns.Clear();
            dT.Rows.Clear();
            columns.Clear();
            int temp = FirstValue;
            for (int i = FirstValue; i <= SecondValue; i++)  
            {
                string NameColum = i.ToString();
                columns.Add(new DataColumn(NameColum, typeof(double)));
                columns.Add(new DataColumn(NameColum + "-Modulo", typeof(double)));
            }
            foreach (DataColumn column in columns)
            {
                dT.Columns.Add(column);
            }
            for (int i = 0; i <= columns.Count/2; i++)
            {
                DataRow row = dT.NewRow();
                for (int j = 0; j <=columns.Count-1; j+=2)
                {
                    if (temp<=SecondValue)
                    {
                        int RowValue = ModClass.ManualMod(temp, i+1);
                        row[j]=i+1;
                        var ValueColum= temp;
                        row[j + 1] = RowValue;
                        var Key = ValueColum;
                        if (RowValue == 0)
                        {
                            if (Divisors.FirstOrDefault(x => x.Key==Key) is { } divisor)
                            {
                                divisor.Value++;
                            }
                            else
                            {
                                Divisors.Add(new Divisor() { Key=Key, Value=1 });
                            }                      
                        }
                        temp++;
                    }
                }
                dT.Rows.Add(row);
                temp = FirstValue;
            }
            Divisor min = Divisors.OrderBy(x=>x.Value).First();
            return dT.DefaultView;
        }
    }
}
