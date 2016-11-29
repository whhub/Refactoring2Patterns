using System.Collections.Generic;

namespace CashRegister
{
    internal abstract class PriceStrategy
    {
        protected abstract string ToPriceStrategyString();
        public abstract double AcceptCash(double money);

        #region Overrides of Object

        /// <summary>
        ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return ToPriceStrategyString();
        }

        #endregion

        public static IEnumerable<PriceStrategy> CreateStrategies()
        {
            return new List<PriceStrategy>
            {
                new NormalPriceStrategy(),
                new RebatePriceStratey(),
                new ReturnPriceStrategy()
            };
        }
    }
}