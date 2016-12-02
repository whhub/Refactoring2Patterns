using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        // TODO: Move playerName, places, purses and inPenaltyBox to a new class Player
        private List<string> players = new List<string>();
        private int[] places = new int[6];
        private int[] purses = new int[6];
        private bool[] inPenaltyBox = new bool[6];

        private int currentPlayer = 0;
        private bool isGettingOutOfPenaltyBox;
        private QuestionMaker _questionMaker = new QuestionMaker();

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                _questionMaker.AddPopQuestion("Pop Question " + i);
                _questionMaker.AddScienceQuestion(("Science Question " + i));
                _questionMaker.AddSportsQuestion(("Sports Question " + i));
                _questionMaker.AddRockQuestion("Rock Question " + i);
            }
        }
        


        public void add(String playerName)
        {


            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            // TODO-later: Replace Console.WriteLine with a log method of a logger
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
        }

        private int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int rollingNumber)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + rollingNumber);

            if (inPenaltyBox[currentPlayer])
            {
                if (rollingNumber % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    currentPlayerMovesToNewPlaceAndAnswersAQuestion(rollingNumber);
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                currentPlayerMovesToNewPlaceAndAnswersAQuestion(rollingNumber);
            }

        }

        private void currentPlayerMovesToNewPlaceAndAnswersAQuestion(int rollingNumber)
        {
            places[currentPlayer] = places[currentPlayer] + rollingNumber;
            if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

            Console.WriteLine(players[currentPlayer]
                              + "'s new location is "
                              + places[currentPlayer]);
            Console.WriteLine("The category is " + currentCategory());
            askQuestion();
        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(_questionMaker.RemoveFirstPopQuestion());
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(_questionMaker.RemoveFirstScienceQuestion());
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(_questionMaker.RemoveFirstSportsQuestion());
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(_questionMaker.RemoveFirstRockQuestion());
            }
        }


        private String currentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    return currentPlayerGetsAGoldCoinAndSelectNextPlayer();
                }
                else
                {
                    nextPlayer();
                    return true;
                }
            }
            else
            {
                return currentPlayerGetsAGoldCoinAndSelectNextPlayer();
            }
        }

        private bool currentPlayerGetsAGoldCoinAndSelectNextPlayer()
        {
            Console.WriteLine("Answer was correct!!!!");
            purses[currentPlayer]++;
            Console.WriteLine(players[currentPlayer]
                              + " now has "
                              + purses[currentPlayer]
                              + " Gold Coins.");

            bool isGameStillInProgress = this.isGameStillInProgress();
            nextPlayer();

            return isGameStillInProgress;
        }

        private void nextPlayer()
        {
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            // TODO-later: The return value of method Game.wrongAnswer() is unnecessary and should be eliminated
            return true;
        }

        private bool isGameStillInProgress()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}
