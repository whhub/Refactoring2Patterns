namespace NetFlix
{
    public class Movie
    {
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public string Title { get; private set; }
        public int PriceCode { get; set; }

        public double GetCharge(int daysRented)
        {
            double thisAmount = 0;

            switch (PriceCode)
            {
                case Regular:
                    thisAmount += 2;
                    if (daysRented > 2) thisAmount += (daysRented - 2)*1.5;
                    break;
                case NewRelease:
                    thisAmount += daysRented*3;
                    break;
                case Childrens:
                    thisAmount += 1.5;
                    if (daysRented > 3) thisAmount += (daysRented - 3)*1.5;
                    break;
            }
            return thisAmount;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if (PriceCode == NewRelease && daysRented > 1) return 2;
            return 1;
        }
    }
}