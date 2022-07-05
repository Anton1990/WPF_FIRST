using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM;

namespace WPF_FIRST
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private Model _calc;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand NumberCommand { get; private set; }
        public RelayCommand PlusCommand { get; private set; }
        public RelayCommand MinusCommand { get; private set; }


        public RelayCommand TimesCommand { get; private set; }
        public RelayCommand OverCommand { get; private set; }
        public RelayCommand EqualsCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }

        public String Total
        {
            get
            {
                return _calc.Total;
            }
        }

        public String S1
        {
            get
            {
                return _calc.S1;
            }
        }

       

        public string S2
        {
            get { return _calc.S2; }
           
        }


        public ViewModel(Model calculator)
        {
            _calc = calculator;




            //NumberCommand = new RelayCommand(param => { _calc.Number(Convert.ToInt32(param)); UpdateDisplay(); },
            //                                param => _calc.CanDoNumber());

            //PlusCommand = new RelayCommand(param => { _calc.Plus(); UpdateDisplay(); },
            //                                param => _calc.CanDoOperator());

            //MinusCommand = new RelayCommand(param => { _calc.Minus(); UpdateDisplay(); },
            //                                param => _calc.CanDoOperator());

            //TimesCommand = new RelayCommand(param => { _calc.Times(); UpdateDisplay(); },
            //                                param => _calc.CanDoOperator());

            //OverCommand = new RelayCommand(param => { _calc.Over(); UpdateDisplay(); },
            //                                param => _calc.CanDoOperator());

            //EqualsCommand = new RelayCommand(param => { _calc.Equals(); UpdateDisplay(); },
            //                                param => _calc.CanDoEquals());

            //ClearCommand = new RelayCommand(param => { _calc.Clear(); UpdateDisplay(); },
            //                                param => _calc.CanDoClear());

            PlusCommand=new RelayCommand(obj =>{ Console.WriteLine(S1); UpdateDisplay(); UpdateDisplay1();

            });
            MinusCommand=new RelayCommand(obj =>{_calc.sub();});


        }

        private void UpdateDisplay()
        {
            NotifyPropertyChanged("S1");
            NotifyPropertyChanged("S2");
            NotifyPropertyChanged("Total");
            CommandManager.InvalidateRequerySuggested();
        }

        private void UpdateDisplay1()
        {
           
            NotifyPropertyChanged("S2");
           
            CommandManager.InvalidateRequerySuggested();
        }


        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

