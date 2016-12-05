namespace TicketDispenser
{
    public class TicketDispenser
    {

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
