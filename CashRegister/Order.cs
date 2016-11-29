namespace CashRegister
{
    internal class Order
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public Order(double price, double quantity, PriceStrategy strategy)
        {
            Price = price;
            Quantity = quantity;
            PriceStrategy = strategy;

            Total = PriceStrategy.AcceptCash(price*quantity);
        }

        public PriceStrategy PriceStrategy { get; private set; }
        public double Quantity { get; private set; }
        public double Price { get; private set; }
        public double Total { get; private set; }
    }
}