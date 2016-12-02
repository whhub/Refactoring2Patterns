using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class QuestionMaker
    {
        // TODO-Working-On: Move question lists to a new  class QuestionMaker
        private LinkedList<string> popQuestions = new LinkedList<string>();
        private LinkedList<string> scienceQuestions = new LinkedList<string>();
        private LinkedList<string> sportsQuestions = new LinkedList<string>();
        private LinkedList<string> rockQuestions = new LinkedList<string>();

        public void AddPopQuestion(string s)
        {
            popQuestions.AddLast(s);

        }

        public void AddScienceQuestion(string s)
        {
            scienceQuestions.AddLast(s);

        }

        public void AddSportsQuestion(string s)
        {
            sportsQuestions.AddLast(s);

        }

        public void AddRockQuestion(string s)
        {
            rockQuestions.AddLast(s);
        }
    }
}
