namespace Ticket
{
    public class TicketDispenser
    {
        public TicketDispenser(TurnNumberSequence turnNumberSequence)
        {
        }

        public TicketDispenser() : this(new TurnNumberSequence())
        {
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
