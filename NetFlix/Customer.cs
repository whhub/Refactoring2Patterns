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
        public string statement()
        {
            double totalAmount = 0; // 总消费金额
            var frequentRenterPoints = 0; // 常客积点
            var result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                double thisAmount = 0;

                switch (rental.Movie.PriceCode)
                {
                    case Movie.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2) thisAmount += (rental.DaysRented - 2)*1.5;
                        break;
                    case Movie.NewRelease:
                        thisAmount += rental.DaysRented*3;
                        break;
                    case Movie.Childrens:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3) thisAmount += (rental.DaysRented - 3)*1.5;
                        break;
                }

                // add frequent renter points (累计常客积点）
                frequentRenterPoints ++;

                // add bonus for a two day new release rental
                if (rental.Movie.PriceCode == Movie.NewRelease && rental.DaysRented > 1)
                    frequentRenterPoints++;

                // show figures for this rental (显示此笔租借记录）
                result += "\t" + rental.Movie.Title + "\t" + totalAmount + "\n";

                totalAmount += thisAmount;
            }

            // add footer lines (结尾打印）
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}