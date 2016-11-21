namespace NetFlix
{
    internal class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; private set; }
        public int DaysRented { get; private set; }

        public double GetCharge()
        {
            double thisAmount = 0;

            switch (Movie.PriceCode)
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (DaysRented > 2) thisAmount += (DaysRented - 2)*1.5;
                    break;
                case Movie.NewRelease:
                    thisAmount += DaysRented*3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (DaysRented > 3) thisAmount += (DaysRented - 3)*1.5;
                    break;
            }
            return thisAmount;
        }
    }
}