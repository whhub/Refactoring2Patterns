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
            var result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                // show figures for this rental (显示此笔租借记录）
                result += "\t" + rental.Movie.Title + "\t" + rental.GetCharge() + "\n";
            }

            // add footer lines (结尾打印）
            result += "Amount owed is " + GetTotalCharge() + "\n";
            result += "You earned " + GetFrequentRenterPoints() + " frequent renter points";

            return result;
        }

        private int GetFrequentRenterPoints()
        {
            var frequentRenterPoints = 0; // 常客积点
            foreach (var rental in _rentals)
            {
                // add frequent renter points (累计常客积点）
                frequentRenterPoints += rental.GetFrequentRenterPoints();
            }
            return frequentRenterPoints;
        }

        private double GetTotalCharge()
        {
            double totalAmount = 0; // 总消费金额
            foreach (var rental in _rentals)
            {
                totalAmount += rental.GetCharge();
            }
            return totalAmount;
        }
    }
}