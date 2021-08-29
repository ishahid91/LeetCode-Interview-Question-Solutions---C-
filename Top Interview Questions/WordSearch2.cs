using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class WordSearch2
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {

            var result = new List<string>();
            if (board == null || board.Length == 0)
            {
                return result;
            }

            if (words.Length == 0)
            {
                return result;
            }

            foreach (var word in words)
            {

                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[0].Length; col++)
                    {
                        if (ExploreBoard(board, word, row, col, 0))
                        {
                            result.Add(word);
                        }

                    }

                }
            }

            return result;
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
                || ExploreBoard(board, word, row, col + 1, index + 1)
                || ExploreBoard(board, word, row, col - 1, index + 1)
                || ExploreBoard(board, word, row - 1, col, index + 1);

            board[row][col] = word[index];

            return isMatch;

        }
    }
}
