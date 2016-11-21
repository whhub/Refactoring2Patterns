﻿namespace NetFlix
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
    }
}