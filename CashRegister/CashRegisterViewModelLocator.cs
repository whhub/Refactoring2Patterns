namespace CashRegister
{
    internal class CashRegisterViewModelLocator
    {
        private static CashRegisterViewModel _cashRegisterViewModel;

        public static CashRegisterViewModel CashRegisterViewModel
        {
            get { return _cashRegisterViewModel ?? (_cashRegisterViewModel = new CashRegisterViewModel()); }
        }
    }
}