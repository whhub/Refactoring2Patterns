using System.Collections.Generic;

namespace NetFlix
{
    internal class Customer
    {
        private readonly IList<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        // 计算顾客的消费金额并打印报表
        public string Statement()
        {
            double totalAmount = 0; // 总消费金额
            var frequentRenterPoints = 0; // 常客积点
            var result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                var thisAmount = rental.GetCharge();

                // add frequent renter points (累计常客积点）
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                // show figures for this rental (显示此笔租借记录）
                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";

                totalAmount += thisAmount;
            }

            // add footer lines (结尾打印）
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}