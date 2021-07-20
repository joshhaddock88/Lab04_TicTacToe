using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	public class Player
	{
		public string Name { get; set; }
		/// P1 is X and P2 will be O
		public string Marker { get; set; }

		/// Flag to determine if it is the user's turn
		public bool IsTurn { get; set; }

		// idea given by Jona Brown to check if the correct number of turns has been taken.
		public int TurnAmount { get; set; }

		// Gets the input position from the user and returns it in the form of cordinates.
		public Position GetPosition(Board board)
		{
			// Position starts out null, no user input yet.
			Position desiredCoordinate = null;
			// while null, as long as the user does not input -
			while (desiredCoordinate is null)
			{
				// we ask the user for their desired location.
				Console.WriteLine("Please select a location");
				// Then take their input(a string) and parse it into an Int32
				// that give us a position.
				Int32.TryParse(Console.ReadLine(), out int position);
				// we now plug position into the method PositionForNumber
				// PositionForNumber is declared after this method.
				desiredCoordinate = PositionForNumber(position);
			}
			//return the desiredCordinate. This will get used during the TakeTurn method, further down.
			return desiredCoordinate;

		}


		public static Position PositionForNumber(int position)
		{
			//The user was prompted to type in a number 1-9.
			// Depending on the answer, their marker is dropped into the grid.
			switch (position)
			{
				case 1: return new Position(0, 0); // Top Left
				case 2: return new Position(0, 1); // Top Middle
				case 3: return new Position(0, 2); // Top Right
				case 4: return new Position(1, 0); // Middle Left
				case 5: return new Position(1, 1); // Middle Middle
				case 6: return new Position(1, 2); // Middle Right
				case 7: return new Position(2, 0); // Bottom Left
				case 8: return new Position(2, 1); // Bottom Middle 
				case 9: return new Position(2, 2); // Bottom Right
					// This represents a 3x3 square. TicTacToe board.
				default: return null; //if they don't type in 1-9 we get null.
			}
		}


		public void TakeTurn(Board board)
		{
			IsTurn = true; // used by NextPlater method to make sure we're switching turns.

			Console.WriteLine($"{Name} it is your turn"); // tells player it is their turn.

			Position position = GetPosition(board); // calls the GetPosition method with the board as an argument
			// promtps user for a cordinate. See line 20 for details.

			if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _)) //tests to see if user value is a number
			{
				TurnAmount++;
				board.GameBoard[position.Row, position.Column] = Marker; // the value of the position from GetPosition
				// is now either "X" or "O"
			}
			else // occurs when ther is already a marker on the coordinate.
			{
				Console.WriteLine("This space is already occupied");
				Console.ReadLine();
			}
		}
	}
}