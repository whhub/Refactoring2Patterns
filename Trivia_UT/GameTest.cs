using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace Trivia_UT
{
    [TestClass]
    public class GameTest
    {
        //TODO-user-intent: the game should be over if a player rolls the dice and answers each question correctly for 6 times
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

        // TODO-user-intent: the game should be over if a player rolls the dice for 7 times and answers the question wrongly for 1 time followed by an odd rolling number but then correctly for 6 times
        // TODO-user-intent: the game should be over if a player rolls the dice for 8 times and answers the question wrongly for 1 time followed by an even rolling number but then correctly for 7 times
    }
}
