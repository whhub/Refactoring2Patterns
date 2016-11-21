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
            return Movie.GetCharge(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            // add bonus for a two day new release rental
            if (Movie.PriceCode == Movie.NewRelease && DaysRented > 1)
                return 2;
            return 1;
        }
    }
}