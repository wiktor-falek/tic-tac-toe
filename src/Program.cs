using System;
using static System.Console;

namespace TicTacToe
{
    public class Program 
    {
        public static void Main()
        {
            string[] board = NewBoard();
            string playerSymbol = ChoosePlayerSymbol();
            PrintBoard(board);
            WriteLine(playerSymbol);
        }

        static string[] NewBoard()
        {
            string[] board = {"x", "x", "x", "x", "x", "x", "x", "x", "x"};
            return board;
        }

        static void PrintBoard(string[] board)
        {
            string s = "";
            for (int i = 0; i < board.Length; i++)
            {
                s += board[i] + " ";
                if (i == 2 || i == 5) 
                {
                    s += "\n";
                }
            }
            WriteLine(s);
        }

        static string ChoosePlayerSymbol()
        {
            Random rand = new Random();
            return rand.NextDouble() >= 0.5 ? "x" : "o";
        }
    }
}