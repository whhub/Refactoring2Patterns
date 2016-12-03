using Microsoft.VisualStudio.TestTools.UnitTesting;
using UglyTrivia;

namespace Trivia_UT
{
    [TestClass]
    public class GameTests
    {
        private Game _game;
        private bool _isGameStillInProgress;

        [TestInitialize]
        public void SetUp()
        {
            _game = new Game();
            _game.add("Chet");
            _isGameStillInProgress = true;
        }
        [TestMethod]
        public void The_game_should_be_over_if_a_player_rolls_the_dice_and_answers_each_question_correctly_for_6_times()
        {
            // Arrange

            // Act
            for (int i = 0; i < 6; i++)
            {
                _game.roll(1);
                _isGameStillInProgress = _game.wasCorrectlyAnswered();
            }

            // Asert
            Assert.IsFalse(_isGameStillInProgress);
        }

        [TestMethod]
        public void The_game_should_be_over_if_a_player_rolls_the_dice_for_7_times_and_answers_the_question_wrongly_for_1_time_followed_by_an_rolling_number_which_is_not_4_but_then_correctly_for_6_times()
        {
            // Arrange

            // Act
            _game.roll(1);
            _game.wrongAnswer();
            _game.roll(6);
            _game.wasCorrectlyAnswered();

            for (int i = 0; i < 5; i++)
            {
                _game.roll(1);
                _isGameStillInProgress = _game.wasCorrectlyAnswered();
            }

            // Assert
            Assert.IsFalse(_isGameStillInProgress);
        }

        [TestMethod]
        public void
            The_game_should_be_over_if_a_player_rolls_the_dice_for_7_times_and_answers_the_question_wrongly_for_1_time_followed_by_an_rolling_number_which_is_4_but_then_correctly_for_7_times
            ()
        {
            // Arrange

            // Act
            _game.roll(1);
            _game.wrongAnswer();
            _game.roll(4);
            _game.wasCorrectlyAnswered();

            for (int i = 0; i < 6; i++)
            {
                _game.roll(1);
                _isGameStillInProgress = _game.wasCorrectlyAnswered();
            }

            // Assert
            Assert.IsFalse(_isGameStillInProgress);
        }
    }
}
