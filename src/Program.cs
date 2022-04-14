using System;
using static System.Console;

namespace TicTacToe
{
    public class Program 
    {
        public static void Main()
        {
            bool keepPlaying = true;
            while (keepPlaying) {
                NewGame();
                WriteLine("Do you wish to restart? y/n");
                if (!ReadLine().Equals("y")) {
                    keepPlaying = false;
                }
            }
        }
        static void NewGame() {
            string[] board = NewBoard();
            string playerSymbol = ChoosePlayerSymbol();
            string computerSymbol = playerSymbol == "x" ? "o" : "x";
            string gameStatus = CheckGameStatus(board);
            Console.Clear();
            PrintBoard(board);
            WriteLine($"Your symbol is: {playerSymbol}");

            while(gameStatus == "ongoing") {

                playerTurn(playerSymbol, board);
                computerTurn(computerSymbol, board);

                gameStatus = CheckGameStatus(board);

                Console.Clear();
                PrintBoard(board);
            }
            WriteLine($"{gameStatus} won");
        }

        static void playerTurn(string playerSymbol, string[] board) {
            string[] validInputs = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string input = "wrong";

            while (Array.IndexOf(validInputs, input) == -1) {
                WriteLine("Select a number from 1-9 to place symbol on a square");
                input = ReadLine();
            }

            int index = int.Parse(input) - 1;

            // not my proudest moment but nothing else works
            // just dont input taken position 100,000 times
            if (board[index] != " ") {
                playerTurn(playerSymbol, board);
                return;
            }
            board[index] = playerSymbol;
        }

        static void computerTurn(string computerSymbol, string[] board) {
            Random rand = new Random();
            
            // get every index of board where board[index] == " "
            int[] availableIndices = board.Select((b,i) => b == " " ? i : -1).Where(i => i != -1).ToArray();

            int index = availableIndices[rand.Next(availableIndices.Length)];
            board[index] = computerSymbol;
        }

        static string[] NewBoard()
        {
            string[] board = {" ", " ", " ", " ", " ", " ", " ", " ", " "};
            return board;
        }

        static void PrintBoard(string[] board)
        {
            string s = "";
            for (int i = 0; i < board.Length; i++) {
                s += $"[{board[i]}] ";
                if (i == 2 || i == 5) {
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

        static string CheckGameStatus(string[] board)
        {
            static bool BoardPositionComparer(int a, int b, int c, string[] board) {
                // returns true if board indices a, b, c are equal and are either "x" or "y"
                string[] playerSymbols = {"x", "o"};

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