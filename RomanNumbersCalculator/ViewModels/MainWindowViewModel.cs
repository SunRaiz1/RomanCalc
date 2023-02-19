using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using RomanNumbersCalculator.Models;

namespace RomanNumbersCalculator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        string maintex = "";
        RomanNumberExtend Number;
        bool error1;

        private bool error
        {
            get => error1;
            set
            {
                if (value) SetError();
                else if (!value && error1) MainText = "";
                error1 = value;
            }
        }

        public string MainText
        {
            get
            {
                return maintex;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref maintex, value);
            }
        }
        char oper;
        public void Char(string z)
        {
            error = false;
            MainText += z;
        }
        public void Clear()
        {
            MainText = "";
            Number = null;

        }

        public void Calculate()
        {
            var z = new RomanNumberExtend(MainText);
            try
            {
                if (oper == '+')
                    MainText = (z + Number).ToString();
                else if (oper == '*')
                    MainText = (Number * z).ToString();
                else if (oper == '-')
                    MainText = (Number - z).ToString();
                else if (oper == '/')
                    MainText = (Number / z).ToString();

            }

            catch (RomanNumberException exit)
            {
                error = true;
            }

        }


        public void Operation(char oper)
        {
            try
            {
                Number = new RomanNumberExtend(MainText);
                this.oper = oper;
            }
            catch (RomanNumberException exit)
            {
                error = true;
            }
            if (!error)  MainText = "";
            else if (error) MainText = "";
        }
        private void SetError() => MainText = "#ERROR";

    }
}
