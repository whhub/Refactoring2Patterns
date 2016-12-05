namespace Ticket
{
    public class TicketDispenser
    {
        public TicketDispenser(TurnNumberSequence turnNumberSequence)
        {
            throw new System.NotImplementedException();
        }

        public TicketDispenser() : this(new TurnNumberSequence())
        {
            throw new System.NotImplementedException();
        }

        public TurnTicket GetTurnTicket()
        {
            // TODO: Depending on a static method violates the Dependency Inversion Priciple and Open-Closed Principle.
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
