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
        // TODO-working-on: Move inPenaltyBox into class Player
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

            players.Add(new Player(playerName));
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
            var player = players[currentPlayer];
            Console.WriteLine(player + " is the current player");
            Console.WriteLine("They have rolled a " + rollingNumber);

            if (inPenaltyBox[currentPlayer] || player.IsInPenaltyBox())
            {
                if (rollingNumber % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;
                    player.GetOutOfPenaltyBox();

                    Console.WriteLine(player + " is getting out of the penalty box");
                    currentPlayerMovesToNewPlaceAndAnswersAQuestion(rollingNumber);
                }
                else
                {
                    Console.WriteLine(player + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                    player.StayInPenaltyBox();
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
            var player = players[currentPlayer];
            if (inPenaltyBox[currentPlayer] || player.IsInPenaltyBox())
            {
                if (isGettingOutOfPenaltyBox || player.IsGettingOutOfPenaltyBox())
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
            var player = players[currentPlayer];
            player.WinAGoldCoin();
            Console.WriteLine(player
                              + " now has "
                              + player.CountGoldCoin()
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
            players[currentPlayer].SentToPenaltyBox();

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            // TODO-later: The return value of method Game.wrongAnswer() is unnecessary and should be eliminated
            return true;
        }

        private bool isGameStillInProgress()
        {
            // TODO: The magic number 6
            return players[currentPlayer].CountGoldCoin() != 6;
        }
    }
}
