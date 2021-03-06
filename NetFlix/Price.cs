﻿namespace NetFlix
{
    internal abstract class Price
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    internal class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
                    double  thisAmount = 2;
                    if (daysRented > 2) thisAmount += (daysRented - 2) * 1.5;
            return thisAmount;
        }
    }

    internal class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented*3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }

    internal class ChildrenPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }

        public override double GetCharge(int daysRented)
        {
                                double thisAmount = 1.5;
                    if (daysRented > 3) thisAmount += (daysRented - 3) * 1.5;
            return thisAmount;
        }
    }
}