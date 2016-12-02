namespace UglyTrivia
{
    public class Player
    {
        private readonly string _name;
        private int _place;

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
            if (_place > 11) _place -= 12;
        }
    }
}