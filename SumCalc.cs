using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;

namespace Lab2
{

    class MyCommand : ICommand
    {
        private SumCalc model;

        public Action Operation { get; set; }

        public MyCommand(SumCalc model)
        {
            this.model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Operation();
            model.OnPropertyChanged("Sumi");

        }
    }

    //class MyCommandDel : ICommand
    //{
    //    private SumCalc model;

    //    public MyCommandDel(SumCalc model)
    //    {
    //        this.model = model;
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        model.Sumi = model.A - model.B;
    //        model.OnPropertyChanged("Sumi");
    //    }
    //}

    class SumCalc : INotifyPropertyChanged
    {
        private MyCommand takeCaesarZ;
        private MyCommand takeCaesarR;

        public SumCalc()
        {
            takeCaesarZ = new MyCommand(this);
            takeCaesarZ.Operation = MetCaesarZ;
            takeCaesarR = new MyCommand(this);
            takeCaesarR.Operation = MetCaesarR;
        }

  
        void MetCaesarZ(`) {

            int count = Convert.ToInt32(B);
            int c2 = 0;
            char[] charStr = A.ToCharArray();
            for(int i = 0; i < A.Length; i++)
            {
                c2 = (int)A[i];
                if (c2 > 64 && c2 < 123)
                {
                    if (IsUpper(c2))  c2=(65+(c2+count)%65) ; 
                    else  c2=(97+(c2+count)%97); 
                }
                charStr[i] = (char)c2; 
            }
            Sumi = new string(charStr);
        }

        void MetCaesarR() {

            int count = Convert.ToInt32(B);
            int c2 = 0;
            char[] charStr = A.ToCharArray();
            for (int i = 0; i < A.Length; i++)
            {
                c2 = (int)A[i];
                if (c2 > 64 && c2 < 123)
                {
                    if (IsUpper(c2))  c2=(65+(c2-count)%65) ; 
                    else  c2=(97+(c2-count)%97); 
                }
                charStr[i] = (char)c2;
            }
            Sumi = new string(charStr);
        }

        public string A { get; set; }

        public string B { get; set; }

        public string Sumi { get; set; }

       // public string Op { get; set; }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TakeCaesarZ { get { return takeCaesarZ; } }
        public ICommand TakeCaesarR { get { return takeCaesarR; } }
    }
}
