using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace CashRegister
{
    internal class CashRegisterViewModel : ViewModelBase
    {
        public double Price { get; set; }
        public double Quantity { get; set; }

        #region [--Sum--]

        private double _sum;

        public double Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                RaisePropertyChanged(() => Sum);
            }
        }

        #endregion [--Sum--]
    }
}
