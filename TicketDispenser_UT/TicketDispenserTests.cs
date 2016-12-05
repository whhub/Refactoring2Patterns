using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket;

namespace Ticket_UT
{
    [TestClass]
    public class TicketDispenserTests
    {
        [TestMethod]
        public void The_turn_number_sequence_of_the_vip_customers_starts_from_1001()
        {
            // Arrange
            TurnNumberSequence vipCustomerTurnNumberSequence = new TurnNumberSequence(1001);
            TicketDispenser ticketDispenser = new TicketDispenser(vipCustomerTurnNumberSequence);

            // Act
            TurnTicket ticket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(1001, ticket.TurnNumber);
        }

        // TODO-new-feature-working-on: the turn number sequence of the regular customers starts from 2001
        [TestMethod]
        public void The_turn_number_sequence_of_the_regular_customers_starts_from_2001()
        {
            
            // Arrange
            TurnNumberSequence regularCustomerTurnNumberSequence = new TurnNumberSequence(2001);
            TicketDispenser ticketDispenser = new TicketDispenser(regularCustomerTurnNumberSequence);

            // Act
            TurnTicket ticket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(2001, ticket.TurnNumber);
        }
        
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
        [TestMethod]
        public void The_ticket_dispenser_should_dispense_the_ticket_number_11_if_give_a_turn_number_11_to_it()
        {
            // Arrange
            MockTurnNumberSequence mockTurnNumberSequence = new MockTurnNumberSequence();
            mockTurnNumberSequence.ArrangeNextTurnNumber(11);
            TicketDispenser ticketDispenser = new TicketDispenser(mockTurnNumberSequence);

            // Act
            TurnTicket ticket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.AreEqual(11, ticket.TurnNumber);
            mockTurnNumberSequence.VerifyMethodGetNextTurnNumberCalledOnce();
        }

    }

    public class MockTurnNumberSequence : TurnNumberSequence
    {
        private int _nextTurnNumber;
        private int _callsCount;

        public void ArrangeNextTurnNumber(int nextTurnNumber)
        {
            _nextTurnNumber = nextTurnNumber;
        }

        #region Overrides of TurnNumberSequence

        public override int GetNextTurnNumber()
        {
            _callsCount++;
            return _nextTurnNumber;
        }

        #endregion

        public void VerifyMethodGetNextTurnNumberCalledOnce()
        {
            if (_callsCount != 1)
                throw new InvalidOperationException("The method NextTurnNumber shouble be called once.");
        }
    }
}