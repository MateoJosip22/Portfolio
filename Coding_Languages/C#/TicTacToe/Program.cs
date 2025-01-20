using System;

class Program
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
    static char currentPlayer = 'X';

    static void Main()
    {
        int turns = 0;
        while (true)
        {
            Console.Clear();
            DisplayBoard();
            Console.WriteLine($"Player {currentPlayer}, enter a position (1-9): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
            {
                if (PlaceMarker(position))
                {
                    turns++;
                    if (CheckWinner())
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    if (turns == 9)
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Position already taken. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine("Current Board:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---|---|---");
        }
    }

    static bool PlaceMarker(int position)
    {
        int row = (position - 1) / 3;
        int col = (position - 1) % 3;

        if (board[row, col] != 'X' && board[row, col] != 'O')
        {
            board[row, col] = currentPlayer;
            return true;
        }
        return false;
    }

    static bool CheckWinner()
    {
        // Check rows, columns, and diagonals
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer) return true;
        }
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer) return true;

        return false;
    }
}
