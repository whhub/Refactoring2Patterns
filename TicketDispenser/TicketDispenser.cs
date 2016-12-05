namespace Ticket
{
    public class TicketDispenser
    {
        private TurnNumberSequence _turnNumberSequence;

        public TicketDispenser(TurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TicketDispenser() : this(new TurnNumberSequence())
        {
        }

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
