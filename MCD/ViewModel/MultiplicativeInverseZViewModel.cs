using GoldenToolKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCD.ViewModel
{
    public class MultiplicativeInverseZViewModel: ModelBase
    {
        private int _ZValue;

        public int ZValue
        {
            get 
            { 
                return _ZValue;
            }
            set 
            {
                _ZValue = value;
                OnPropertyChanged();
            }
        }
        public DataTable dT { get; set; }
        public DataTable dTIn { get; set; }
        List<DataColumn> columns;
        List<DataColumn> columns2;
        Dictionary<string, string?> columnValues { get; set; }
        public ICommand ZInverseCommand { get; set; }
        public MultiplicativeInverseZViewModel()
        {
            dT = new DataTable();
            dTIn = new DataTable();
            columnValues = new Dictionary<string, string?>();
            columns = new List<DataColumn>();
            columns2 = new List<DataColumn>();
        }

        public DataView CalculateInversive()
        {
            dT.Clear();
            dT.Columns.Clear();
            dT.Rows.Clear();
            columns.Clear();
            columnValues.Clear();
            columns.Add(new DataColumn("#", typeof(double)));
            for (int i = 0; i <= ZValue-1; i++)
            {
                string NameColum = i.ToString();
                columns.Add(new DataColumn(NameColum, typeof(double)));
            }
            foreach (DataColumn column in columns)
            {
                dT.Columns.Add(column);
            }
            for (int i = 0; i <= columns.Count-2; i++)
            {
                DataRow row = dT.NewRow();
                for (int j = 0; j <=columns.Count-1; j++)
                {
                    
                    int RowValue= i * j;
                    if (RowValue == 1)
                    {
                        columnValues.Add(i.ToString(), j.ToString());
                    }
                    if (RowValue > (columns.Count - 1))
                    {
                        int temp = RowValue;
                        RowValue= ModClass.ManualMod(RowValue, columns.Count-1);                       
                        if (RowValue == 1)
                        {
                            columnValues.Add(i.ToString(),j.ToString());
                        }
                    }
                    if (j == 0)
                    {
                        row[j]=i;
                        row[j+1] = RowValue;
                    }
                    else
                    {
                        var aux = j + 1;
                        if (aux <= (columns.Count-1))
                        {
                            row[aux] = RowValue;
                        }
                        
                    }
                    
                   
                }
                dT.Rows.Add(row);
                if (!columnValues.ContainsKey(i.ToString()))
                {
                    columnValues.Add(i.ToString(), "----");
                }
                
            }
            return dT.DefaultView;
        }

        public DataView InverseTable()
        {
            dTIn.Clear();
            dTIn.Columns.Clear();
            dTIn.Rows.Clear();
            columns2.Clear();
            columns2.Add(new DataColumn("W", typeof(string)));
            columns2.Add(new DataColumn("W-inverso", typeof(string)));
            foreach (DataColumn column in columns2)
            {
                dTIn.Columns.Add(column);
            }
            for (int i = 0; i <= ZValue-1; i++)
            {
                DataRow row = dTIn.NewRow();
                    foreach (string keyVar in columnValues.Keys) 
                    { 
                        if (keyVar == i.ToString())
                        {
                            row[0]= keyVar;
                            row[1]=columnValues[i.ToString()];
                            break;
                        }
                        
                    }
                dTIn.Rows.Add(row);
            }
            return dTIn.DefaultView;
        }
    }
}
