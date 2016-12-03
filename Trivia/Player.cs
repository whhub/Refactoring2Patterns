namespace UglyTrivia
{
    public class Player
    {
        private readonly string _name;
        private int _place;
        private int _sumOfGoldCoins;
        private bool _isInPenaltyBox;

        public static readonly int MaxNumberOfPlace = 12;

        public Player(string playerName)
        {
            _name = playerName;
        }

        public int Place
        {
            get { return _place; }
        }

        #region Overrides of Object

        /// <summary>
        ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return _name;
        }

        #endregion

        public void MoveForwardSteps(int steps)
        {
            _place += steps;
            if (_place > MaxNumberOfPlace-1) _place -= MaxNumberOfPlace;
        }

        public static readonly int CategoryPop1 = 0;

        public static readonly int CategoryPop2 = 4;

        public static readonly int CategoryPop3 = 8;

        public static readonly int CategoryScience1 = 1;

        public static readonly int CategoryScience2 = 5;

        public static readonly int CategoryScience3 = 9;

        public static readonly int CategorySports1 = 2;

        public static readonly int CategorySports2 = 6;

        public static readonly int CategorySports3 = 10;
        public string CurrentCategory()
        {
            if (Place == CategoryPop1) return "Pop";
            if (Place == CategoryPop2) return "Pop";
            if (Place == CategoryPop3) return "Pop";
            if (Place == CategoryScience1) return "Science";
            if (Place == CategoryScience2) return "Science";
            if (Place == CategoryScience3) return "Science";
            if (Place == CategorySports1) return "Sports";
            if (Place == CategorySports2) return "Sports";
            if (Place == CategorySports3) return "Sports";
            return "Rock";
        }

        public void WinAGoldCoin()
        {
            _sumOfGoldCoins++;
        }

        public int CountGoldCoin()
        {
            return _sumOfGoldCoins;
        }

        public bool IsInPenaltyBox()
        {
            return _isInPenaltyBox;
        }

        public void GetOutOfPenaltyBox()
        {
            _isInPenaltyBox = false;
        }

        public void StayInPenaltyBox()
        {
            _isInPenaltyBox = true;
        }

        public bool IsGettingOutOfPenaltyBox()
        {
            return !_isInPenaltyBox;
        }

        public void SentToPenaltyBox()
        {
            _isInPenaltyBox = true;
        }
    }
}