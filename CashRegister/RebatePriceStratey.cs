namespace CashRegister
{
    class RebatePriceStratey : PriceStrategy
    {

        #region Overrides of PriceStrategy

        protected override string ToPriceStrategyString()
        {
            return "打八折";
        }

        public override double AcceptCash(double money)
        {
            return money*0.8;
        }

        #endregion
    }
}