using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	public class Game
	{
		//instantiating new obects of the player and board class.
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		public Player Winner { get; set; }
		public Board Board { get; set; }

		/// Require 2 players and a board to start a game. 
		public Game(Player p1, Player p2)
		{
			PlayerOne = p1;
			PlayerTwo = p2;
			Board = new Board();
		}
		/// Activate the Play of the game
		public Player Play()
		{
			PlayerOne.Marker = "X";
			PlayerTwo.Marker = "O";
			PlayerOne.IsTurn = true;
			PlayerTwo.IsTurn = false;
			PlayerOne.Name = "PlayerOne";
			PlayerTwo.Name = "PlayerTwo";

			Board.DisplayBoard();
			// while the counter is less than 9, call up the next player by checking which player has a positie IsTurn boolean.
			// Was greatly aided by Jona Brown in creating this logic.
			bool winner = false;
			while(winner == false && PlayerOne.TurnAmount < 5 && PlayerTwo.TurnAmount < 5)
            {
				Player currentPlayer = NextPlayer();
				currentPlayer.TakeTurn(Board);
				winner = CheckForWinner(Board);
				SwitchPlayer();
				Console.Clear();
				Board.DisplayBoard();
				if (winner == true) return Winner;
            }
			return Winner;
		}


		/// Check if winner exists
		public bool CheckForWinner(Board board)
		{
			int[][] winners = new int[][]
			{
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

				new[] {1,5,9},
				new[] {3,5,7}
			};

			// Given all the winning conditions, Determine the winning logic. 
			for (int i = 0; i < winners.Length; i++)
			{
				Position p1 = Player.PositionForNumber(winners[i][0]);
				Position p2 = Player.PositionForNumber(winners[i][1]);
				Position p3 = Player.PositionForNumber(winners[i][2]);

				string a = Board.GameBoard[p1.Row, p1.Column];
				string b = Board.GameBoard[p2.Row, p2.Column];
				string c = Board.GameBoard[p3.Row, p3.Column];

				if (a == "X" && b == "X" && c == "X")
				{
					Winner = PlayerOne;
					return true;
				}
				else if (a == "O" && b == "O" && c == "O")
                {
					Winner = PlayerTwo;
					return true;
                }

			}// if there is no winner, false

			return false;
		}

		/// Determine next player
		public Player NextPlayer()
		{
			return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
		}

		/// End one players turn and activate the other
		public void SwitchPlayer()
		{
			if (PlayerOne.IsTurn)
			{

				PlayerOne.IsTurn = false;


				PlayerTwo.IsTurn = true;
			}
			else
			{
				PlayerOne.IsTurn = true;
				PlayerTwo.IsTurn = false;
			}
		}


	}
}