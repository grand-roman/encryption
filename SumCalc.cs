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

  
        void MetCaesarZ() {

            int count = Convert.ToInt32(B);
            int c2 = 0;
            char[] charStr = A.ToCharArray();
            for(int i = 0; i < A.Length; i++)
            {
                c2 = (int)A[i];
                c2 += count;
                if (c2 < 97 && c2 > 57)
                {
                    if (c2 < 65)  c2 += 26; 
                    else if (c2 > 90)  c2 -= 26; 
                }

                if (c2 < 97 && c2 > 57)
                {
                    if (c2 < 97) { c2 += 26; }
                    else if (c2 > 122) { c2 -= 26; }
                }
                else if (c2 < 97) { c2 += 26; }
                else if (c2 > 122) { c2 -= 26; }
                else if (c2 < 128) { c2 += 32; }
                else if (c2 > 159) { c2 -= 32; }
                else if (c2 < 160) { c2 += 32; }
                else if (c2 > 175) { c2 -= 48; }
                else if (c2 < 224) { c2 -= 48; }
                else if (c2 > 239) { c2 -= 32; }
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
                c2 -= count;
                if (c2 < 65) { c2 += 26;  }
                else if (c2 > 90) { c2 -= 26; }

                else if (c2 < 97) { c2 += 26; }
                else if (c2 > 122) { c2 -= 26; }
                else if (c2 < 128) { c2 += 32; }
                else if (c2 > 159) { c2 -= 32; }
                else if (c2 < 160) { c2 += 32; }
                else if (c2 > 175) { c2 -= 48; }
                else if (c2 < 224) { c2 -= 48; }
                else if (c2 > 239) { c2 -= 32; }
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
