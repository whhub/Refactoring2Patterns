using System.ComponentModel;

namespace NetFlix
{
    public class Movie
    {
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public string Title { get; private set; }

        public int PriceCode
        {
            get { return _price.GetPriceCode(); }
            set
            {
                switch (value)
                {
                    case Regular:
                        _price = new RegularPrice();
                        break;
                    case Childrens:
                        _price = new ChildrenPrice();
                        break;
                    case NewRelease:
                        _price = new NewReleasePrice();
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Incorrect Price Code");
                }
            }
        }

        public double GetCharge(int daysRented)
        {
           return  _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return  _price.GetFrequentRenterPoints(daysRented);
        }
    }
}