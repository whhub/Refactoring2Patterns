using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CashRegister
{
    internal class CashRegisterViewModel : ViewModelBase
    {
        public CashRegisterViewModel()
        {
            Orders.CollectionChanged += OrdersOnCollectionChanged;
        }

        ~CashRegisterViewModel()
        {
            Orders.CollectionChanged -= OrdersOnCollectionChanged;
        }

        public double Price { get; set; }
        public double Quantity { get; set; }

        public IEnumerable<PriceStrategy> PriceStrategies
        {
            get { return _priceStrategies ?? (_priceStrategies = PriceStrategy.CreateStrategies()); }
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
        }

        public PriceStrategy SelectedPriceStrategy { get; set; }

        public ICommand AddItemCommand
        {
            get
            {
                return _addItemCommand ??
                       (_addItemCommand =
                           new RelayCommand(() => Orders.Add(new Order(Price, Quantity, SelectedPriceStrategy))));
            }
        }

        private void OrdersOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            Sum = Orders.Sum(o => o.Total);
        }

        #region [--Sum--]

        private IEnumerable<PriceStrategy> _priceStrategies;
        private readonly ObservableCollection<Order> _orders = new ObservableCollection<Order>();
        private ICommand _addItemCommand;
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