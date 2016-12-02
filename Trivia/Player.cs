namespace UglyTrivia
{
    public class Player
    {
        private readonly string _name;

        public Player(string playerName)
        {
            _name = playerName;
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

        public void MoveForwardSteps(int rollingNumber)
        {
            
        }
    }
}