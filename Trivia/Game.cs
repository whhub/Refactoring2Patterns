using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        // TODO-working-on: Move purses into class Player
        private int[] purses = new int[6];
        // TODO: Move inPenaltyBox into class Player
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

            // TODO: Move playerName into class Player
            players.Add(new Player(playerName));
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            // TODO-later: Replace Console.WriteLine with a log method of a logger
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("The total amount of players is " + players.Count);
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
            var player = players[currentPlayer];
            player.MoveForwardSteps(rollingNumber);

            Console.WriteLine(player
                              + "'s new location is "
                              + player.Place);
            Console.WriteLine("The category is " + player.CurrentCategory());
            askQuestion();
        }

        private void askQuestion()
        {
            var player = players[currentPlayer];
            if (player.CurrentCategory() == "Pop")
            {
                Console.WriteLine(_questionMaker.RemoveFirstPopQuestion());
            }
            if (player.CurrentCategory() == "Science")
            {
                Console.WriteLine(_questionMaker.RemoveFirstScienceQuestion());
            }
            if (player.CurrentCategory() == "Sports")
            {
                Console.WriteLine(_questionMaker.RemoveFirstSportsQuestion());
            }
            if (player.CurrentCategory() == "Rock")
            {
                Console.WriteLine(_questionMaker.RemoveFirstRockQuestion());
            }
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
            players[currentPlayer].WinAGoldCoin();
            players[currentPlayer].CountGoldCoin();
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
            // TODO: The magic number 6
            return !(purses[currentPlayer] == 6);
        }
    }
}
