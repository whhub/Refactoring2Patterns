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
    }
}