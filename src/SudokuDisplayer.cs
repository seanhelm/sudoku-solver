using System.Text;
using System;

namespace SudokuSolver
{
    static class SudokuDisplayer
    {
        /// <summary>
        /// Converts a 2D array representing a Sudoku puzzle to a string to be displayed
        /// </summary>
        /// <param name="puzzle">Sudoku puzzle as Puzzle object</param>
        /// <returns>String representing Sudoku puzzle</returns>
        public static string Display(Puzzle puzzle)
        {
            StringBuilder puzzleRep = new StringBuilder();

            if(SudokuValidator.IsValidPuzzle(puzzle))
            {
                for(int i = 0; i < 9; i++)
                {
                    if(i % 3 == 0)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            puzzleRep.Append("+");
                            puzzleRep.Append(new string('-', puzzle.Array.GetLength(1) / 2 + 3));
                        }
                        puzzleRep.Append("+\n");
                    }

                    for(int j = 0; j < 9; j++)
                    {
                        if(j % 3 == 0)
                        {
                            puzzleRep.Append("| ");
                        }

                        if(puzzle.Array[i, j] == puzzle.EmptyCell)
                        {
                            puzzleRep.Append(". ");
                        }
                        else
                        {
                            puzzleRep.Append(puzzle.Array[i, j].ToString() + " ");
                        }
                    }

                    puzzleRep.Append("|\n");
                }

                for(int k = 0; k < 3; k++)
                {
                    puzzleRep.Append("+");
                    puzzleRep.Append(new string('-', puzzle.Array.GetLength(1) / 2 + 3));
                }
                puzzleRep.Append("+\n");
            }
            else
            {
                throw new ArgumentException(String.Format("{0} must be a valid sudoku puzzle.",
                    puzzle), "puzzle");
            }

            return puzzleRep.ToString();
        }
    }
}
