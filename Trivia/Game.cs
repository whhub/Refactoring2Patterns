﻿using System;
using System.Collections.Generic;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private List<Player> players = new List<Player>();

        private int currentPlayer = 0;
        private QuestionMaker _questionMaker = new QuestionMaker();
        private static readonly int MaxNumberOfQuestions = 50;
        public static readonly int NumberOfGoldCoinsToWonAndGameOver = 6;

        public Game()
        {
            PrepareQuestions();
        }

        private void PrepareQuestions()
        {
            for (int i = 0; i < MaxNumberOfQuestions; i++)
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

            // TODO-later: Replace Console.WriteLine with a log method of a logger
            Console.WriteLine(playerName + " was added");
            Console.WriteLine("The total amount of players is " + players.Count);
        }

        public void roll(int rollingNumber)
        {
            var player = players[currentPlayer];
            Console.WriteLine(player + " is the current player");
            Console.WriteLine("They have rolled a " + rollingNumber);

            if (!player.IsInPenaltyBox())
            {
                currentPlayerMovesToNewPlaceAndAnswersAQuestion(rollingNumber);
                return;
            }
            
            var isRollingNumberOdd = rollingNumber%2 != 0;
            if (isRollingNumberOdd)
            {
                player.GetOutOfPenaltyBox();

                Console.WriteLine(player + " is getting out of the penalty box");
                currentPlayerMovesToNewPlaceAndAnswersAQuestion(rollingNumber);
                return;
            }
            
            Console.WriteLine(player + " is not getting out of the penalty box");
            player.SentToPenaltyBox();
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
            var category = player.CurrentCategory();
            switch (category)
            {
                case "Pop":
                    Console.WriteLine(_questionMaker.RemoveFirstPopQuestion());
                    break;
                case "Science":
                    Console.WriteLine(_questionMaker.RemoveFirstScienceQuestion());
                    break;
                case "Sports":
                    Console.WriteLine(_questionMaker.RemoveFirstSportsQuestion());
                    break;
                case "Rock":
                    Console.WriteLine(_questionMaker.RemoveFirstRockQuestion());
                    break;
            }
        }


        public bool wasCorrectlyAnswered()
        {
            var player = players[currentPlayer];
            if (player.IsInPenaltyBox())
            {
                if (player.IsGettingOutOfPenaltyBox())
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
            
            players[currentPlayer].SentToPenaltyBox();

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            // TODO-later: The return value of method Game.wrongAnswer() is unnecessary and should be eliminated
            return true;
        }

        private bool isGameStillInProgress()
        {
            return players[currentPlayer].CountGoldCoin() != NumberOfGoldCoinsToWonAndGameOver;
        }
    }
}
