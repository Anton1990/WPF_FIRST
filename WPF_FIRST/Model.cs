using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace WPF_FIRST
{
    internal class Model: INotifyPropertyChanged
    {
        public string s1="0";
        public string s2="0";
        public string total;
        public Model() { 
          
        
        }

        public string S1
        {
            get { return s1; }
            set
            {
                s1 = value;
                OnPropertyChanged("S1");
            }

        }
        public string S2
        {
            get { return s2; }
            set
            {
                s2 = value;
                OnPropertyChanged("S2");
            }
        }
        public string Total
        {
            get { return total; }
            set
            {
               total = value;
                OnPropertyChanged("Total");
            }
        }

        #region ModelMethods
        public string enter_pointer(  string s) 
        {
            if (s.Contains(",") != true)
            {
                s = s + ","; 
            }
            return s;
         
         }
        public void add() { 
            Total = (float.Parse(S1) + float.Parse(S2)).ToString();
        }
        public void sub()
        {
            Total = (float.Parse(S1) - float.Parse(S2)).ToString();
        }

        public void mul()
        {
            Total = (float.Parse(S1) * float.Parse(S2)).ToString();
        }

        public void div()
        {
            Total = (float.Parse(S1) / float.Parse(S2)).ToString();
        }


        //private RelayCommand addCommand;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {
        //              S2 = "222";
        //              S1 = "22";
        //              add();
        //          }));
        //    }
       // }



        #endregion





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

}
