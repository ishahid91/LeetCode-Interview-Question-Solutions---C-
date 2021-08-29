using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class TicTacToe
    {
        int[] rows;
        int[] cols;
        int diagonal;
        int antiDiagonal;

        public TicTacToe(int n)
        {
            rows = new int[n];
            cols = new int[n];
        }

        public int move(int row, int col, int player)
        {
            int currentPlayer = (player == 1) ? 1 : -1;
            // update currentPlayer in rows and cols arrays
            rows[row] += currentPlayer;
            cols[col] += currentPlayer;
            // update diagonal
            if (row == col)
            {
                diagonal += currentPlayer;
            }
            //update anti diagonal
            if (col == (cols.Length - row - 1))
            {
                antiDiagonal += currentPlayer;
            }
            int n = rows.Length;
            // check if the current player wins
            if (Math.Abs(rows[row]) == n ||
                    Math.Abs(cols[col]) == n ||
                    Math.Abs(diagonal) == n ||
                    Math.Abs(antiDiagonal) == n)
            {
                return player;
            }
            // No one wins
            return 0;
        }
    }
}
