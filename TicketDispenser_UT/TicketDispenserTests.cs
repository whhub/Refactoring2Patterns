using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket;

namespace Ticket_UT
{
    [TestClass]
    public class TicketDispenserTests
    {
        // TODO-new-feature: the turn number sequence of the vip customers starts from 1001

        // TODO-new-feature: the turn number sequence of the regular customers starts from 2001
        
        [TestMethod]
        public void A_new_ticket_should_have_the_turn_number_subsequent_to_the_previous_ticket()
        {
            // Arrange
            var ticketDispenser = new TicketDispenser();
            TurnTicket previouseTicket = ticketDispenser.GetTurnTicket();

            // Act
            TurnTicket newTicket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, newTicket.TurnNumber - previouseTicket.TurnNumber);
        }

        // TODO-user-intent-test-working-on: a new ticket should have the turn number subsequent to the previous ticket from another dispenser
        [TestMethod]
        public void A_new_ticket_should_have_the_turn_number_subsequent_to_the_previous_ticket_from_another_dispenser()
        {
            // Arrange
            var ticketDispenser = new TicketDispenser();
            var anotherTicketDispenser = new TicketDispenser();

            // Act
            TurnTicket previouseTicket = ticketDispenser.GetTurnTicket();
            TurnTicket newTicket = anotherTicketDispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1, newTicket.TurnNumber - previouseTicket.TurnNumber);
        }
        // TODO-unit-test: the ticket dispenser shouble dispense the ticket number 11 if give a turn number 11 to it

    }
}