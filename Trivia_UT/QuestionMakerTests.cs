using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace Trivia_UT
{
    [TestClass]
    public class QuestionMakerTests
    {
        [TestMethod]
        public void Add_two_pop_questions_and_could_remove_the_first_one()
        {
            // Arrange
            var questionMaker = new QuestionMaker();

            // Act
            questionMaker.AddPopQuestion("Pop Question 1");
            questionMaker.AddPopQuestion("Pop Question 2");

            // Assert
            Assert.AreEqual("Pop Question 1", questionMaker.RemoveFirstPopQuestion());
        }

        [TestMethod]
        public void Add_two_Science_questions_and_could_remove_the_first_one()
        {
            // Arrange
            var questionMaker = new QuestionMaker();

            // Act
            questionMaker.AddScienceQuestion("Science Question 1");
            questionMaker.AddScienceQuestion("Science Question 2");

            // Assert
            Assert.AreEqual("Science Question 1", questionMaker.RemoveFirstScienceQuestion());
        }
        [TestMethod]
        public void Add_two_Sports_questions_and_could_remove_the_first_one()
        {
            // Arrange
            var questionMaker = new QuestionMaker();

            // Act
            questionMaker.AddSportsQuestion("Sports Question 1");
            questionMaker.AddSportsQuestion("Sports Question 2");

            // Assert
            Assert.AreEqual("Sports Question 1", questionMaker.RemoveFirstSportsQuestion());
        }
        [TestMethod]
        public void Add_two_Rock_questions_and_could_remove_the_first_one()
        {
            // Arrange
            var questionMaker = new QuestionMaker();

            // Act
            questionMaker.AddRockQuestion("Rock Question 1");
            questionMaker.AddRockQuestion("Rock Question 2");

            // Assert
            Assert.AreEqual("Rock Question 1", questionMaker.RemoveFirstRockQuestion());
        }


    }
}
