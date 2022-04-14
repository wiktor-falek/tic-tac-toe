using System;
using static System.Console;

namespace TicTacToe
{
    public class Program 
    {
        public static void Main()
        {
            NewGame();
        }
        static void NewGame() {
            string[] board = NewBoard();
            string playerSymbol = ChoosePlayerSymbol();
            string gameStatus = CheckGameStatus(board);
            WriteLine($"Your symbol is: {playerSymbol}");

            while(gameStatus == "ongoing") {
            PrintBoard(board);
            PlayerInput(playerSymbol, board);

            }

            WriteLine($"{gameStatus}");


        }

        static void PlayerInput(string playerSymbol, string[] board) {
            WriteLine($"Choose position to place your symbol ({playerSymbol})");
            string input = ReadLine();
            
        }

        static string[] NewBoard()
        {
            string[] board = {" ", " ", " ", " ", " ", " ", " ", " ", " "};
            return board;
        }

        static void PrintBoard(string[] board)
        {
            string s = "";
            for (int i = 0; i < board.Length; i++)
            {
                s += $"[{board[i]}] ";
                if (i == 2 || i == 5) 
                {
                    s += "\n";
                }
            }
            WriteLine(s);
        }

        static string ChoosePlayerSymbol()
        {
            Random rand = new Random(); // no clue where this belongs so i'll just leave it here
            return rand.NextDouble() >= 0.5 ? "x" : "o";
        }

        static string CheckGameStatus(string[] board)
        {
            static bool BoardPositionComparer(int a, int b, int c, string[] board) {
                // returns true if board indices a, b, c are equal and are either "x" or "y"
                string[] playerSymbols = {"x", "o"};

                WriteLine($"{board[a]} {board[b]} {board[c]}");

                if (board[a] != " " && board[a] == board[b] && board[b] == board[c]) {
                    return true;
                }
                return false;
            }

            if(BoardPositionComparer(0, 1, 2, board)) {
                return board[0];
            }

            // check horizonal
            if (BoardPositionComparer(0, 1, 2, board)) {
                return board[0];
            }

            if (BoardPositionComparer(3, 4, 5, board)) {
                return board[3];
            }

            if (BoardPositionComparer(6, 7, 8, board)) {
                return board[6];
            }
            
            // check vertical
            if (BoardPositionComparer(0, 3, 6, board)) {
                return board[0];
            }

            if (BoardPositionComparer(1, 4, 7, board)) {
                return board[1];
            }

            if (BoardPositionComparer(2, 5, 8, board)) {
                return board[2];
            }

            // check diagonal
            if (BoardPositionComparer(0, 4, 8, board)) {
                return board[0];
            }

            if (BoardPositionComparer(2, 4, 6, board)) {
                return board[2];
            }

            if (!board.Contains(" ")) {
                return "draw";
            }

            return "ongoing";
        }
    }
}