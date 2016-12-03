﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace Trivia_UT
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void The_place_should_be_1_if_the_player_moves_forward_1_step()
        {
            // Arrange
            var player = new Player("Chet");

            // Act
            player.MoveForwardSteps(1);

            // Assert
            Assert.AreEqual(1, player.Place);
        }

         [TestMethod]
        public void The_place_should_be_0_if_the_player_moves_forward_12_step()
        {
            // Arrange
            var player = new Player("Chet");

            // Act
            player.MoveForwardSteps(12);

            // Assert
            Assert.AreEqual(0, player.Place);
        }       

        [TestMethod]
        public void The_category_should_be_Pop_if_the_player_in_place_12_4_or_8()
        {
            // Arrange
            var player = new Player("Chet");
            const string expected = "Pop";

            // Act, Assert
            player.MoveForwardSteps(12);
            Assert.AreEqual(expected, player.CurrentCategory());

            player.MoveForwardSteps(4);
            Assert.AreEqual(expected, player.CurrentCategory());

            player.MoveForwardSteps(4);
            Assert.AreEqual(expected, player.CurrentCategory());
        }
        // TODO-working-on: the category should be Science if the player moves 1, 5 or 9 steps
        [TestMethod]
        public void The_category_should_be_Science_if_the_player_in_place_1_5_or_9()
        {
            // Arrange
            var player = new Player("Chet");
            const string expected = "Science";

            // Act, Assert
            player.MoveForwardSteps(1);
            Assert.AreEqual(expected, player.CurrentCategory());

            player.MoveForwardSteps(4);
            Assert.AreEqual(expected, player.CurrentCategory());

            player.MoveForwardSteps(4);
            Assert.AreEqual(expected, player.CurrentCategory());
        }
        // TODO: the category should be Sports if the player in place 2, 6 or 10 
        // TODO: the category should be Rock if the player in place 3, 7 or 11 
    }
}
