﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class QuestionMaker
    {
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

        public string RemoveFirstPopQuestion()
        {
            var question = popQuestions.First;
            popQuestions.RemoveFirst();
            return question.ToString();
        }

        public string RemoveFirstScienceQuestion()
        {
            var question = scienceQuestions.First;
            scienceQuestions.RemoveFirst();
            return question.ToString();
        }

        public string RemoveFirstSportsQuestion()
        {
            var question = sportsQuestions.First;
            sportsQuestions.RemoveFirst();
            return question.ToString();
        }

        public string RemoveFirstRockQuestion()
        {
            var question = rockQuestions.First;
            rockQuestions.RemoveFirst();
            return question.ToString();
        }
    }
}
