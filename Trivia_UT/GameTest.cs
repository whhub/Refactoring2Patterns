﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace Trivia_UT
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void The_game_should_be_over_if_a_player_rolls_the_dice_and_answers_each_question_correctly_for_6_times()
        {
            // Arrange
            var game = new Game();
            game.add("Chet");
            bool isGameStillInProgress = true;

            // Act
            for (int i = 0; i < 6; i++)
            {
                game.roll(1);
                isGameStillInProgress = game.wasCorrectlyAnswered();
            }

            // Asert
            Assert.IsFalse(isGameStillInProgress);
        }

        [TestMethod]
        public void The_game_should_be_over_if_a_player_rolls_the_dice_for_7_times_and_answers_the_question_wrongly_for_1_time_followed_by_an_odd_rolling_number_but_then_correctly_for_6_times()
        {
            // Arrange
            bool isGameStillInProgress = true;
            var game = new Game();
            game.add("Chet");

            // Act
            game.roll(1);
            game.wrongAnswer();
            game.roll(1);
            game.wasCorrectlyAnswered();

            for (int i = 0; i < 5; i++)
            {
                game.roll(1);
                isGameStillInProgress = game.wasCorrectlyAnswered();
            }

            // Assert
            Assert.IsFalse(isGameStillInProgress);
        }

        // TODO-user-intent: the game should be over if a player rolls the dice for 8 times and answers the question wrongly for 1 time followed by an even rolling number but then correctly for 7 times
    }
}
