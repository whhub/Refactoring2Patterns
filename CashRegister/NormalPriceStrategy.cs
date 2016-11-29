namespace CashRegister
{
    class NormalPriceStrategy : PriceStrategy
    {
        #region Overrides of PriceStrategy

        protected override string ToPriceStrategyString()
        {
            return "正常收费";
        }

        public override double AcceptCash(double money)
        {
            return money;
        }

        #endregion
    }
}