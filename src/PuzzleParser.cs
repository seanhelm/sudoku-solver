using System;
using System.Text.RegularExpressions;

namespace SudokuSolver
{
    class PuzzleParser
    {
        /// <summary>
        /// Puzzle object to hold parsed puzzle data
        /// </summary>
        public Puzzle Puzzle { get; private set; }

        /// <summary>
        /// Puzzle represented as one line string
        /// </summary>
        public string PuzzleAsString { get; private set; }

        /// <summary>
        /// Constructor to call ParsePuzzle() in order to parse the string argument
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        public PuzzleParser(string puzzleFormat)
        {
            Parse(puzzleFormat);
        }

        /// <summary>
        /// Constructor to call ParsePuzzle() in order to parse the string argument
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        /// <param name="emptyCell">Integer value to represent an empty cell in the puzzle</param>
        public PuzzleParser(string puzzleFormat, int emptyCell)
        {
            Parse(puzzleFormat, emptyCell);
        }

        /// <summary>
        /// Parses a square puzzle as a string to a 2D number array
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        public void Parse(string puzzleFormat)
        {
            Parse(puzzleFormat, 0);
        }

        /// <summary>
        /// Parses a square puzzle as a string to a 2D number array
        /// </summary>
        /// <param name="puzzleFormat">String representation of puzzle (using digits and dots)</param>
        /// <param name="emptyCell">Integer value to represent an empty cell in the puzzle</param>
        public void Parse(string puzzleFormat, int emptyCell)
        {
            puzzleFormat = Regex.Replace(puzzleFormat, @"\s+", "");

            if(Math.Sqrt(puzzleFormat.Length) % 1 == 0)
            {
                PuzzleAsString = puzzleFormat;

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
                            puzzleArray[i, j] = emptyCell;
                        }
                        else
                        {
                            throw new ArgumentException(String.Format("{0} contains invalid characters.",
                                puzzleFormat), "puzzleFormat");
                        }

                        stringIndex++;
                    }
                }

                Puzzle = new Puzzle(puzzleArray, emptyCell);
            }
            else
            {
                throw new ArgumentException(String.Format("{0} is not a valid square.",
                    puzzleFormat), "puzzleFormat");
            }
        }
    }
}
