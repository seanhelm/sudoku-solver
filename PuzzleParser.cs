using System;
using System.Text.RegularExpressions;

namespace SudokuSolver
{
    class PuzzleParser
    {
        /// <summary>
        /// Int array to hold numbers for puzzle
        /// </summary>
        public int[,] PuzzleArray { get; private set; }

        /// <summary>
        /// Constructor to call ParsePuzzle() in order to parse the string argument
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        public PuzzleParser(string puzzleFormat)
        {
            ParsePuzzle(puzzleFormat);
        }

        /// <summary>
        /// Parses a square puzzle as a string to a 2D number array
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        /// <returns>Puzzle array</returns>
        public void ParsePuzzle(string puzzleFormat)
        {
            puzzleFormat = Regex.Replace(puzzleFormat, @"\s+", "");

            if(Math.Sqrt(puzzleFormat.Length) % 1 == 0)
            {
                int width = (int)Math.Sqrt(puzzleFormat.Length);
                int[,] puzzleArray = new int[width, width];

                int stringIndex = 0;
                for(int i = 0; i < puzzleArray.GetLength(0); i++)
                {
                    for(int j = 0; j < puzzleArray.GetLength(1); j++)
                    {
                        if(Char.IsDigit(puzzleFormat[stringIndex]))
                        {
                            puzzleArray[i, j] = (int)Char.GetNumericValue(puzzleFormat[stringIndex]);
                        }
                        else if(puzzleFormat[stringIndex] == '.')
                        {
                            puzzleArray[i, j] = 0;
                        }
                        else
                        {
                            throw new ArgumentException(String.Format("{0} contains invalid characters.", 
                                puzzleFormat), "puzzleFormat");
                        }

                        stringIndex++;
                    }
                }

                PuzzleArray = puzzleArray;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} is not a valid square.", 
                    puzzleFormat), "puzzleFormat");
            }
        }
    }
}
