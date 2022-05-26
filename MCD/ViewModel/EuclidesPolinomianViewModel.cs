using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MCD.Models;
using System.Windows.Input;
using GoldenToolKit;
using Newtonsoft.Json;

namespace MCD.ViewModel
{
    internal class EuclidesPolinomianViewModel : ModelBase
    {
        private string gx_;
        private string hx_;
        private string s1_;
        private string s2_;
        private string t1_;
        private string t2_;
        private string t_;
        private string s_;
        private string q_;
        private string r_;
        private string d_;
        public string gx
        {
            get => gx_; 
            
            set 
            { 
                gx_ = value;
                OnPropertyChanged();
            }
        }

        public string hx
        {
            get => hx_; 
            set 
            {
                hx_ = value;
                OnPropertyChanged();
            }
        }
        public string s1
        {
            get => s1_;
            set
            {
                s1_ = value;
                OnPropertyChanged();
            }
        }
        public string s2
        {
            get => s2_;
            set
            {
                s2_ = value;
                OnPropertyChanged();
            }
        }
        public string t1
        {
            get => t1_;
            set
            {
                t1_ = value;
                OnPropertyChanged();
            }
        }
        public string t2
        {
            get => t2_;
            set
            {
                t2_ = value;
                OnPropertyChanged();
            }
        }
        public string t
        {
            get => t_;
            set
            {
                t_ = value;
                OnPropertyChanged();
            }
        }
        public string s
        {
            get => s_;
            set
            {
                s_ = value;
                OnPropertyChanged();
            }
        }
        public string q
        {
            get => q_;
            set
            {
                q_ = value;
                OnPropertyChanged();
            }
        }
        public string r
        {
            get => r_;
            set
            {
                r_ = value;
                OnPropertyChanged();
            }
        }
        public string d
        {
            get => d_;
            set
            {
                d_ = value;
                OnPropertyChanged();
            }
        }
        public List<Polynomial> Glist { get; set; }
        public List<Polynomial> Hlist { get; set; }
        public List<Polynomial> H2list { get; set; }
        public List<Polynomial> Rlist { get; set; }
        public List<Polynomial> Qlist { get; set; }
        public ICommand CalcularEuclidesCommand { get; set; }
        public EuclidesPolinomianViewModel()
        {
            Glist = new List<Polynomial>();
            Hlist = new List<Polynomial>();
            Rlist = new List<Polynomial>();
            H2list = new List<Polynomial>();
            Qlist = new List<Polynomial>();
            s = "";
            s2 = "1";
            s1 = "0";
            t = "";
            t2 = "0";
            t1 = "1";
            q = "";
            r = "";
            d = "";
            CalcularEuclidesCommand = new Command(CalcularEuclides);
        }

        private void CalcularEuclides(object obj)
        {
            
            string exreg = "([+-]?[^-+]+)";
            Regex regex = new Regex(exreg);
            Match match = regex.Match(gx);
            if (match.Success)
            {
                string[] temp = Regex.Split(gx.Trim(), exreg.Trim());
                temp = temp.Where(val => val != "").ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Contains("x"))
                    {
                        temp[i] = temp[i].Replace("x", ",");
                        var values= temp[i].Split(',');
                        if (values[0] == "" || values[0] == "+")
                        {
                            values[0] = "1";
                        }
                        else if (values[0] == "-")
                        {
                            values[0] = "-1";
                        }
                        if (values[1] == "")
                        {
                            values[1] = "1";
                        }else if(values[1] == "-")
                        {
                            values[1] = "-1";
                        }
                        Glist.Add(new Polynomial(Convert.ToInt32(values[0]), TypeValuePolynomial.X,Convert.ToInt32(values[1])));
                    }
                    else
                    {
                        Glist.Add(new Polynomial(Convert.ToInt32(temp[i]), TypeValuePolynomial.C,0));
                    }
                }
                    
                
            }
            Match match2 = regex.Match(hx);
            if (match2.Success)
            {
                string[] temp = Regex.Split(hx.Trim(), exreg.Trim());
                temp = temp.Where(val => val != "").ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Contains("x"))
                    {
                        temp[i] = temp[i].Replace("x", ",");
                        var values = temp[i].Split(',');
                        if (values[0] == "" || values[0] == "+")
                        {
                            values[0] = "1";
                        }
                        else if (values[0] == "-")
                        {
                            values[0] = "-1";
                        }
                        if (values[1] == "")
                        {
                            values[1] = "1";
                        }
                        else if (values[1] == "-")
                        {
                            values[1] = "-1";
                        }
                        Hlist.Add(new Polynomial(Convert.ToInt32(values[0]), TypeValuePolynomial.X, Convert.ToInt32(values[1])));
                    }
                    else
                    {
                        Hlist.Add(new Polynomial(Convert.ToInt32(temp[i]), TypeValuePolynomial.C, 0));
                    }
                }
            }
            Glist = Glist.OrderByDescending(x => x.ValuePow).ToList();
            Hlist = Hlist.OrderByDescending(x => x.ValuePow).ToList();

                if (Glist[0].ValuePow >= Hlist[0].ValuePow)
                {
                    Rlist = Glist.Select(x => x.CloneList()).ToList();
                    H2list = Hlist.Select(x => x.CloneList()).ToList();
                    while (Rlist[0].ValuePow >= H2list[0].ValuePow)
                    {
                        int multPow = 0;
                        double multVal = 0;
                        if (Rlist[0].Value != 1 && Rlist[0].Value != -1)
                        {
                            if (Rlist[0].Value > 0)
                            {
                                multVal = Rlist[0].Value * -1;
                            }
                            else
                            {
                                multVal = Rlist[0].Value;
                            }
                            Qlist.Add(new Polynomial(multVal, TypeValuePolynomial.C, multPow));
                        }
                        
                        if (H2list[0].ValuePow < Rlist[0].ValuePow)
                        {
                            multPow = Rlist[0].ValuePow - H2list[0].ValuePow;
                            Qlist.Add(new Polynomial(1, TypeValuePolynomial.X, multPow));
                           
                        }
                        if (H2list[0].ValuePow == Rlist[0].ValuePow)
                        {
                            Qlist.Add(new Polynomial(1, TypeValuePolynomial.C, multPow));
                        }
                        foreach (var item in H2list)
                        {
                            if (multVal != 0)
                            {
                                item.Value *= multVal;
                            }
                            item.ValuePow += multPow;
                            if (item.Type == TypeValuePolynomial.C && item.ValuePow != 0)
                            {
                                item.Type = TypeValuePolynomial.X;
                            }
                        }
                        foreach (var item in H2list)
                        {
                            item.Value *= -1;
                        }
                        for (int i = 0; i < H2list.Count; i++)
                        {
                            if (i <= Rlist.Count - 1)
                            {
                                if (H2list[i].ValuePow == Rlist[i].ValuePow)
                                {
                                    var res = Rlist[i].Value + H2list[i].Value;
                                    if (res == 0)
                                    {
                                        this.Rlist[i].Value = 0;
                                        this.Rlist[i].ValuePow = 0;
                                        this.H2list[i].Value = 0;
                                        this.H2list[i].ValuePow = 0;
                                    }
                                    else
                                    {
                                        Rlist[i].Value += H2list[i].Value;
                                        this.H2list[i].Value = 0;
                                        this.H2list[i].ValuePow = 0;
                                    }
                                }
                            }
                        }
                        Rlist.RemoveAll(x => x.ValuePow == 0 && x.Type != TypeValuePolynomial.C);
                        H2list.RemoveAll(x => x.ValuePow == 0 && x.Type != TypeValuePolynomial.C);
                        for (int i = 0; i < H2list.Count; i++)
                        {
                            if (!Rlist.Contains(H2list[i]))
                            {
                                for (int j = 0; j < Rlist.Count; j++)
                                {
                                    if (Rlist[j].ValuePow == H2list[i].ValuePow)
                                    {
                                        var res = Rlist[j].Value + H2list[i].Value;
                                        if (res == 0)
                                        {
                                            Rlist[j].Value = 0;
                                            Rlist[j].ValuePow = 0;
                                            H2list[i].Value = 0;
                                            H2list[i].ValuePow = 0;

                                        }
                                        else
                                        {
                                            Rlist[j].Value += H2list[i].Value;
                                            H2list[i].Value = 0;
                                            H2list[i].ValuePow = 0;
                                        }

                                    }
                                }
                                if (H2list[i].ValuePow != 0 && H2list[i].Value != 0)
                                {
                                    Rlist.Add(H2list[i]);
                                }
                                Rlist.RemoveAll(x => x.ValuePow == 0 && x.Type != TypeValuePolynomial.C);
                            }

                        }
                        Rlist.RemoveAll(x => x.ValuePow == 0 && x.Value == 0);
                        Rlist = Rlist.OrderByDescending(x => x.ValuePow).ToList();

                        H2list.Clear();
                        H2list = Hlist.Select(x => x.CloneList()).ToList();
                    }
                    Qlist = Qlist.OrderByDescending(x => x.ValuePow).ToList();
                    q = ConvertStringList(Qlist);
                    r = ConvertStringList(Rlist);
                    s = s2;
                    t = ConvertStringList(Qlist);
                    Glist = Hlist.Select(x => x.CloneList()).ToList();
                    Hlist = Rlist.Select(x => x.CloneList()).ToList();
                    gx = ConvertStringList(Glist);
                    hx = ConvertStringList(Hlist);
                    s2 = s1;
                    s1 = s;
                    t2 = t1;
                    t1 = t;
                    Qlist.Clear();
                }
            d = gx;
            s = s2;
            t = t2;
        }
        public string ConvertStringList(List<Polynomial> L1)
        {
            string val = "";
            for (int i = 0; i < L1.Count; i++)
            {
                if (L1[i].Value > 0 && L1[i].Value != 1 && i != 0)
                {
                    val += "+" + L1[i].Value.ToString();
                }
                if (L1[i].Value > 0 && L1[i].Value == 1 && i != 0)
                {
                    val += "+";
                }
                
                if (L1[i].Value == 1 && i == 0)
                {
                }
                if (L1[i].Value == -1 && i == 0)
                {
                    val += "-";
                }
                if (L1[i].Value < 0 && L1[i].Value != -1 && i != 0)
                {
                    val += L1[i].Value.ToString();
                }
                if (L1[i].Value == -1 && i == 0)
                {
                    val += "-";
                }
                if (L1[i].Value == -1 && i != 0)
                {
                    val += "-";
                }
                if (L1[i].Value > -1 && i == 0 && L1[i].Value != 1)
                {
                    val += L1[i].Value.ToString();
                }

                if (L1[i].Type == TypeValuePolynomial.X)
                {
                    val += L1[i].Type.ToString();
                }
                if (L1[i].Type == TypeValuePolynomial.X && L1[i].ValuePow > 1)
                {
                    val += L1[i].ValuePow.ToString();
                }
                
                if (L1[i].Type == TypeValuePolynomial.C && L1[i].Value == 1)
                {
                    val += L1[i].Value.ToString();
                }
            }
            return val;
        }
    }
}
