using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace Trivia_UT
{
    [TestClass]
    public class QuestionMakerTest
    {
        // TODO-Working-On: add two pop questions and could remove the first one
        [TestMethod]
        public void Add_two_pop_questions_and_could_remove_the_first_one()
        {
            // Arrange
            var questionMaker = new QuestionMaker();
            // Assert
            Assert.AreEqual("Pop Question 1", questionMaker.RemoveFirstPopQuestion());
        }

        // TODO: add two science questions and could remove the first one
        // TODO: add two sports questions and could remove the first one
        // TODO: add two rock questions and could remove the first one
    }
}
