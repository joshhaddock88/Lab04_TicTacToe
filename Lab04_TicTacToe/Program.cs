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
            // 1. Create Players
            Player PlayerOne = new Player();
            Player PlayerTwo = new Player();
            // 2. Start a new game
            Game NewGame = new Game(PlayerOne, PlayerTwo);
            Player Winner = NewGame.Play();

            if (Winner.Name != "null")
            {
                Console.WriteLine($"{Winner.Name} is the winner!");
            }
            else
            {
                Console.WriteLine("A draw! Sorry, nobody wins.");
            }

        }


    }
}