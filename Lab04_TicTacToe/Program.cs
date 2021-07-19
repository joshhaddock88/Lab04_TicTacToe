using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
            // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner. 

            // 1. Create Players
            Player PlayerOne = new Player();
            Player PlayerTwo = new Player();
            // 2. Assign player properties.
            Console.WriteLine("Welcome to a game of Tic-Tac-Toe!");
            Console.WriteLine("This may seem rather obvious, but you'll need at least two people to play.");
            Console.WriteLine("Have two people?");
            string userAnswer = Console.ReadLine();
            userAnswer = userAnswer.ToLower();
            Console.Clear();

            while (userAnswer != "yes")
            {
                Console.WriteLine("Oh, well, you'll need at least two people. Do you have someone else now?");
                userAnswer = Console.ReadLine();
                userAnswer = userAnswer.ToLower();
                Console.Clear();
            }
            Console.WriteLine("Great, let's begin!");
            Console.WriteLine("Player 1, what should I call you?");
            PlayerOne.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Nice to meet you {PlayerOne.Name}! You'll be 'X', which means you go first!");
            Console.WriteLine("And now you, Player 2, what's your name?");
            PlayerTwo.Name = Console.ReadLine();
            Console.Clear();

            PlayerOne.Marker = "X";
            PlayerTwo.Marker = "O";
            PlayerOne.IsTurn = true;
            PlayerTwo.IsTurn = false;

            Game NewGame = new Game(PlayerOne, PlayerTwo);
            NewGame.Board.DisplayBoard();
            Player Winner = NewGame.Play();

            if (Winner.Name == "draw")
            {
                Console.WriteLine("A draw! Sorry, nobody wins.");
            }
            else
            {
                Console.WriteLine($"{Winner.Name} is the winner!");
            }

        }


    }
}