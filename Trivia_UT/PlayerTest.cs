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

        // TODO-Working-On: the place should be 0 if the player moves forward 12 step
         [TestMethod]
        public void The_place_should_be_0_if_the_player_moves_forward_12_step()
        {
            // Arrange
            var player = new Player("Chet");

            // Act
            player.MoveForwardSteps(12);

            // Assert
            Assert.AreEqual(0, player.Place);
        }       // TODO: the category should be Pop if the player moves 12, 4 or 8 steps
        // TODO: the category should be Pop if the player moves 1, 5 or 9 steps
        // TODO: the category should be Pop if the player moves 2, 6 or 10 steps
        // TODO: the category should be Rock if the player moves 3, 7 or 11 steps
    }
}