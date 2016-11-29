namespace CashRegister
{
    class ReturnPriceStrategy : PriceStrategy
    {
        #region Overrides of PriceStrategy

        protected override string ToPriceStrategyString()
        {
            return "满300减100";
        }

        public override double AcceptCash(double money)
        {
            return money > 300 ? money - 100 : money;
        }

        #endregion
    }
}