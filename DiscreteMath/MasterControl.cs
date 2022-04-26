using GoldenToolKit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace DiscreteMath
{
    public class MasterControl : ContentControl, INavigationPage
    {
        public static MasterControl Current { get; private set; }
        //public List<IUserControlInterface> ControlInterfaces { get; set; }
        Dictionary<string, IUserControlInterface> ControlInterfaces { get; set; }
        public IUserControlInterface Actual { get; set; }
        public List<string> ControlViews { get; set; }
        public int PageNumber { get; set; }
        public int ActualPage { get; set; }

        public IUserControlInterface GoBack()
        {
            if (ActualPage == 0)
            {

            }
            else
            {
                if (ActualPage != 0)
                {
                    Actual = ControlInterfaces.Values.ElementAt(0);
                    ControlInterfaces.Clear();
                }
                //Actual = ControlInterfaces.Values.ElementAt(ActualPage - 1);
                //ActualPage -= 1;
                return Actual;

            }

            return Actual;
        }

        public IUserControlInterface GoFoward()
        {
            if (ActualPage + 1 > ControlInterfaces.Count - 1)
            {

            }
            else
            {

                Actual = ControlInterfaces.Values.ElementAt(ActualPage + 1);
                ActualPage += 1;
                return Actual;
            }

            return Actual;
        }
        public void Navegar(IUserControlInterface usercontrol)
        {

            this.Content = usercontrol;
            var temp = usercontrol.GetType();
            if (!ControlInterfaces.ContainsKey(temp.FullName))
            {
                ControlViews.Add(temp.FullName);
                ControlInterfaces.Add(temp.FullName, usercontrol);
                PageNumber += 1;
                ActualPage = PageNumber - 1;
            }
            Actual = usercontrol;
            usercontrol.OnShown();
        }

        public void SendMessage(IUserControlInterface control, string json)
        {
            control.OnMessageReceived(json);
        }

        public void SendMessage<T>(object obj) where T : IUserControlInterface
        {
            //Encontrar la ventana del tipo T y enviarle el mensajito
            //si no esta arroja una excepcion
            throw new NotImplementedException();
        }
        public void SendMessage<T>(string json) where T : IUserControlInterface
        {
            //Encontrar la ventana del tipo T y enviarle el mensajito
            //si no esta arroja una excepcion
            throw new NotImplementedException();
        }

        public void Navegar<T>(object parameter = null) where T : IUserControlInterface
        {

            var temp = typeof(T);// controltemp.GetType();
            if (ControlInterfaces.TryGetValue(temp.FullName, out IUserControlInterface value))
            {
                Content = value;
                Actual = value;
                ActualPage = PageNumber - 1;
                value.OnShown();
            }
            else
            {
                T controltemp = (T)Activator.CreateInstance(temp);
                ControlViews.Add(temp.FullName);
                ControlInterfaces.Add(temp.FullName, controltemp);
                Content = controltemp;
                Actual = controltemp;
                PageNumber += 1;
                ActualPage = PageNumber - 1;
                controltemp.OnShown();
            }

        }

        public IUserControlInterface GetCurrentControl()
        {
            return (IUserControlInterface)this.Content;
        }

        public MasterControl()
        {
            Current = this;
            ControlViews = new List<string>();
            ControlInterfaces = new Dictionary<string, IUserControlInterface>();
        }
    }
}
