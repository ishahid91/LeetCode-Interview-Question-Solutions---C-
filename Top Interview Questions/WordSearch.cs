using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class WordSearch
    {
        public static bool Exist(char[][] board, string word)
        {
            board = new char[][]
            {
                new  char[] { 'A', 'B', 'C', 'E' },
                    new  char[] { 'S', 'F', 'C', 'S' },
                new  char[] { 'A', 'D', 'E', 'E' }
            };

            if (board == null || board.Length == 0)
            {
                return false;
            }

            if (string.IsNullOrEmpty(word))
            {
                return true;
            }

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    if (ExploreBoard(board, word, row, col, 0))
                    {
                        return true;
                    }

                }

            }

            return false;
        }

            static bool ExploreBoard(char[][] board, string word, int row, int col, int index)
            {
            Console.WriteLine("checking: " + board[row][col]);
            if (index >= word.Length)
                {
                    return true;
                }

                if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != word[index] || board[row][col] == '#')
                {
                    return false;
                }
            Console.WriteLine("Found: " + board[row][col]);

                board[row][col] = '#';

                bool isMatch = ExploreBoard(board, word, row + 1, col, index + 1)
                    || ExploreBoard(board, word, row , col + 1, index + 1)
                    || ExploreBoard(board, word, row, col - 1, index + 1)
                    || ExploreBoard(board, word, row - 1, col, index + 1);

                board[row][col] = word[index];

                return isMatch;

            }

        }
    }

