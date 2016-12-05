namespace Ticket
{
    public class TurnNumberSequence
    {
        private static int _turnNumber;

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}