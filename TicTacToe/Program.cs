using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };
            char player = 'X';

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe\n");
                PrintBoard(board);

                Console.WriteLine($"\nPlayer {player}, enter row (0-2): ");
                int row = int.Parse(Console.ReadLine());

                Console.WriteLine($"Player {player}, enter column (0-2): ");
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] != '-')
                {
                    Console.WriteLine("This cell is already occupied. Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                board[row, col] = player;

                if (CheckWin(board, player))
                {
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine($"Player {player} has won the game!");
                    break;
                }

                if (CheckDraw(board))
                {
                    Console.Clear();
                    PrintBoard(board);
                    Console.WriteLine("The game is a draw!");
                    break;
                }

                player = player == 'X' ? 'O' : 'X';
            }
        }

        static bool CheckWin(char[,] board, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }

        static bool CheckDraw(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                        return false;
                }
            }

            return true;
        }

        static void PrintBoard(char[,] board)
        {
            Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
        }
    }
}