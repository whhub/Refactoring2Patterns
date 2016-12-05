namespace TicketDispenser
{
    public class TicketDispenser
    {

        public TurnTicket GetTurnTicket()
        {
            // TODO: Depending on a static method violates the Dependency Inversion Priciple and Open-Closed Principle.
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
