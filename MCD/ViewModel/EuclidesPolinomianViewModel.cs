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
        public List<Polynomial> S1 { get; set; }
        public List<Polynomial> S2 { get; set; }
        public List<Polynomial> S { get; set; }
        public List<Polynomial> T1 { get; set; }
        public List<Polynomial> T2 { get; set; }
        public List<Polynomial> T { get; set; }

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
            S2 = new List<Polynomial>();
            S1 = new List<Polynomial>();
            S  = new List<Polynomial>();
            T1 = new List<Polynomial>();
            T2 = new List<Polynomial>();
            T = new List<Polynomial>();
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
            Glist.Clear();
            Hlist.Clear();
            S2.Clear();
            S1.Clear();
            S .Clear();
            T1.Clear();
            T2.Clear();
            T.Clear();
            string exreg = "([+-]?[^-+]+)";
            Regex regex = new Regex(exreg);
            Match match = regex.Match(gx);
            var Gtemp=ValidateRegex(match, gx, exreg); 
            Glist = Gtemp.Select(x => x.CloneList()).ToList();
            Match match2 = regex.Match(hx);
            Gtemp = ValidateRegex(match, hx, exreg);
            Hlist = Gtemp.Select(x => x.CloneList()).ToList();
            S2.Add(new Polynomial(1, TypeValuePolynomial.C, 0));
            S1.Add(new Polynomial(0, TypeValuePolynomial.C, 0));
            T2.Add(new Polynomial(0, TypeValuePolynomial.C, 0));
            T1.Add(new Polynomial(1, TypeValuePolynomial.C, 0));
            Glist = Glist.OrderByDescending(x => x.ValuePow).ToList();
            Hlist = Hlist.OrderByDescending(x => x.ValuePow).ToList();
            while (Hlist.Count != 0)
            {
                if (Glist[0].ValuePow >= Hlist[0].ValuePow)
                {
                    Rlist = Glist.Select(x => x.CloneList()).ToList();
                    H2list = Hlist.Select(x => x.CloneList()).ToList();
                    while (Rlist[0].ValuePow >= H2list[0].ValuePow)
                    {
                        int multPow = 0;
                        double multVal = 0;
                        multVal= Rlist[0].Value / H2list[0].Value;
                        multPow = Rlist[0].ValuePow - H2list[0].ValuePow;
                        if (multPow != 0)
                        {
                            if ( multVal != 1 && multVal != -1)
                            {
                                    Qlist.Add(new Polynomial(multVal, TypeValuePolynomial.X, multPow));
                            }else
                            {
                                multVal = multVal == 1 ? 1 : -1;
                                Qlist.Add(new Polynomial(multVal, TypeValuePolynomial.X, multPow));
                            }
                           
                        }else if( multPow == 0)
                        {
                            if (multVal != 1 && multVal != -1)
                            {
                                    Qlist.Add(new Polynomial(multVal, TypeValuePolynomial.C, multPow));
                            }
                            else
                            { 
                                multVal = multVal == 1 ? 1 : -1;
                                Qlist.Add(new Polynomial(multVal, TypeValuePolynomial.C, multPow));
                            }  
                        }
                        foreach (var item in H2list)
                        {
                            item.Value *= multVal;
                            item.ValuePow += multPow;
                            if (item.Type == TypeValuePolynomial.C && item.ValuePow != 0)
                            {
                                item.Type = TypeValuePolynomial.X;
                            }
                        }
                        var polynomials = new List<Polynomial>();
                        polynomials = SumPolynomials(Rlist, H2list).Select(x => x.CloneList()).ToList();
                        Rlist.Clear();
                        Rlist = polynomials.Select(x => x.CloneList()).ToList();
                        Rlist.RemoveAll(x => x.ValuePow == 0 && x.Value == 0);
                        Rlist = Rlist.OrderByDescending(x => x.ValuePow).ToList();
                        H2list.Clear();
                        H2list = Hlist.Select(x => x.CloneList()).ToList();
                        if (Rlist.Count == 0)
                        {
                            break;
                        }
                    }
                    var polynomials1 = new List<Polynomial>();
                    Qlist = Qlist.OrderByDescending(x => x.ValuePow).ToList();
                    q = ConvertStringList(Qlist);
                    r = ConvertStringList(Rlist);
                    polynomials1= MulPolynomials(S2, Qlist, S1).Select(x => x.CloneList()).ToList();
                    polynomials1.RemoveAll(x => x.ValuePow == 0 && x.Value == 0);
                    S.Clear();
                    S = polynomials1.Select(x => x.CloneList()).ToList();
                    S = S.OrderByDescending(x => x.ValuePow).ToList();
                    s  = ConvertStringList(S);
                    polynomials1.Clear();
                    polynomials1 = MulPolynomials(T2, Qlist, T1).Select(x => x.CloneList()).ToList();
                    polynomials1.RemoveAll(x => x.ValuePow == 0 && x.Value == 0);
                    T.Clear();
                    T = polynomials1.Select(x => x.CloneList()).ToList();
                    T = T.OrderByDescending(x => x.ValuePow).ToList();
                    t = ConvertStringList(T);
                    Glist = Hlist.Select(x => x.CloneList()).ToList();
                    Hlist = Rlist.Select(x => x.CloneList()).ToList();
                    gx = ConvertStringList(Glist);
                    hx = ConvertStringList(Hlist);
                    S2.Clear();
                    S2 = S1.Select(x => x.CloneList()).ToList();
                    S1.Clear();
                    S1 = S.Select(x => x.CloneList()).ToList();
                    T2.Clear();
                    T2 = T1.Select(x => x.CloneList()).ToList();
                    T1.Clear();
                    T1 = T.Select(x => x.CloneList()).ToList();
                    s2 = ConvertStringList(S2);
                    s1 = ConvertStringList(S1); 
                    t2 = ConvertStringList(T2);
                    t1 = ConvertStringList(T1);
                    Qlist.Clear();
                }
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
                    val += "+" + L1[i].Value;
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
                if (L1[i].Value == -1 && i != 0 && L1[i].Type != TypeValuePolynomial.C)
                {
                    val += "-";
                }
                if (L1[i].Value < 0 && L1[i].Value != -1 && i != 0)
                {
                    val +=  L1[i].Value;
                }
                if (L1[i].Value < 0 && L1[i].Value != -1 && i == 0)
                {

                    val += L1[i].Value;
                }
                if (L1[i].Value == -1 && i == 0)
                {
                    val += "-";
                }
                if (L1[i].Value > -1 && i == 0 && L1[i].Value != 1)
                {
                    val += L1[i].Value;
                }

                if (L1[i].Type == TypeValuePolynomial.X)
                {
                    val += L1[i].Type.ToString();
                }
                if (L1[i].Type == TypeValuePolynomial.X && L1[i].ValuePow > 1)
                {
                    val += "^" + L1[i].ValuePow.ToString();
                }
                
                if (L1[i].Type == TypeValuePolynomial.C && L1[i].Value == 1)
                {
                    val += L1[i].Value.ToString();
                }
                if (L1[i].Type == TypeValuePolynomial.C && L1[i].Value == -1)
                {
                    val += L1[i].Value.ToString();
                }
            }
            return val;
        }
        public List<Polynomial> SumPolynomials(List<Polynomial> list1, List<Polynomial> list2)
        {
            for (int i = 0; i < list2.Count; i++)
            {
                if (!list1.Contains(list2[i]))
                {
                    for (int j = 0; j < list1.Count; j++)
                    {
                        if (list1[j].ValuePow == list2[i].ValuePow)
                        {
                            var res = list1[j].Value + list2[i].Value;
                            res %= 2;
                            if (res == 0)
                            {
                                list1[j].Value = 0;
                                list1[j].ValuePow = 0;
                                list2[i].Value = 0;
                                list2[i].ValuePow = 0;
                            }
                        }
                    }
                    if (list2[i].ValuePow != 0 && list2[i].Value != 0)
                    {
                        list1.Add(list2[i]);
                    }
                    if (list2[i].Value != 0 && list2[i].Type == TypeValuePolynomial.C && !list1.Contains(list2[i]))
                    {
                        list1.Add(list2[i]);
                    }
                    list1.RemoveAll(x => x.ValuePow == 0 && x.Type != TypeValuePolynomial.C);
                }
            }
            return list1;
        }
        public List<Polynomial> MulPolynomials(List<Polynomial> list1, List<Polynomial> list2, List<Polynomial> list3)
        {
            var temp=new List<Polynomial>();
            var res = new List<Polynomial>();
            int valuepow =0;
            for (int i = 0; i < list3.Count; i++)//s1
            {
                for (int j = 0; j < list2.Count; j++)//q
                {
                    var value= list2[j].Value * list3[i].Value;
                    if (value != 0)
                    {
                        valuepow = list2[j].ValuePow + list3[i].ValuePow;
                        var typepol = list2[j].Type;
                        if (typepol == TypeValuePolynomial.C && valuepow != 0)
                        {
                            typepol = TypeValuePolynomial.X;
                        }
                        var pol = new Polynomial(value, typepol, valuepow);
                        if (temp.Contains(pol))
                        {
                            foreach (var x in temp)
                            {
                                if (x.Value == pol.Value && x.ValuePow == pol.ValuePow && x.Type == pol.Type)
                                {
                                    x.Value += pol.Value;
                                }
                            }
                        }
                        else
                        {
                            temp.Add(pol);
                        }
                    }
                }
            }
            res = SumPolynomials(list1, temp).Select(x => x.CloneList()).ToList();
            return res;
        }
        public List<Polynomial> ValidateRegex(Match match, string gx, string regex)
        {
            if (match.Success)
            {
                var list = new List<Polynomial>();
                string[] temp = Regex.Split(gx.Trim(), regex.Trim());
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
                        list.Add(new Polynomial(Convert.ToInt32(values[0]), TypeValuePolynomial.X, Convert.ToInt32(values[1])));
                    }
                    else
                    {
                        list.Add(new Polynomial(Convert.ToInt32(temp[i]), TypeValuePolynomial.C, 0));
                    }
                }
                return list;
            }
            return new List<Polynomial>();
        }
    }
    
}
