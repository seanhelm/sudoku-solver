using System.Collections.Generic;

namespace SudokuSolver
{
    static class SudokuValidator
    {
        /// <summary>
        /// Checks if a given 2D array is a valid Sudoku puzzle
        /// </summary>
        /// <param name="puzzle">Sudoku puzzle as Puzzle object</param>
        /// <returns>True if it is a valid puzzle, false otherwise</returns>
        public static bool IsValidPuzzle(Puzzle puzzle)
        {
            if(IsValidArray(puzzle))
            {
                for(int i = 0; i < 9; i++)
                {
                    HashSet<int> row = new HashSet<int>();
                    HashSet<int> column = new HashSet<int>();

                    for(int j = 0; j < 9; j++)
                    {
                        if(puzzle.Array[i, j] != puzzle.EmptyCell 
                            && !row.Add(puzzle.Array[i, j]))
                        {
                            return false;
                        }

                        if(puzzle.Array[j, i] != puzzle.EmptyCell 
                            && !column.Add(puzzle.Array[j, i]))
                        {
                            return false;
                        }
                    }
                }

                for(int i = 0; i < 9; i += 3)
                {
                    for(int j = 0; j < 9; j += 3)
                    {
                        HashSet<int> region = new HashSet<int>();

                        for(int a = 0; a < 3; a++)
                        {
                            for(int b = 0; b < 3; b++)
                            {
                                if(puzzle.Array[i + a, j + b] != puzzle.EmptyCell 
                                    && !region.Add(puzzle.Array[i + a, j + b]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a given 2D array is a valid and complete Sudoku puzzle
        /// </summary>
        /// <param name="puzzle">Sudoku puzzle as Puzzle object</param>
        /// <returns>True if it is a valid and complete puzzle, false otherwise</returns>
        public static bool IsValidComplete(Puzzle puzzle)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(puzzle.Array[i, j] == puzzle.EmptyCell)
                    {
                        return false;
                    }
                }
            }

            return IsValidPuzzle(puzzle);
        }

        /// <summary>
        /// Checks if a given cell in a Sudoku puzzle can hold a given value
        /// </summary>
        /// <param name="puzzle">Sudoku puzzle as Puzzle object</param>
        /// <param name="value">Number to be tested</param>
        /// <param name="row">Row position in puzzle</param>
        /// <param name="column">Column position in puzzle</param>
        /// <returns></returns>
        public static bool IsValidCell(Puzzle puzzle, int value, int row, int column)
        {
            for(int i = 0; i < 9; i++)
            {
                if(puzzle.Array[row, i] == value || puzzle.Array[i, column] == value)
                {
                    return false;
                }
            }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(puzzle.Array[i + (row - row % 3), j + (column - column % 3)] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if given 2D array has the correct dimensions and contains no invalid values
        /// </summary>
        /// <param name="puzzle">Sudoku puzzle as Puzzle object</param>
        /// <returns>True if it is valid, false otherwise</returns>
        private static bool IsValidArray(Puzzle puzzle)
        {
            if(puzzle.Array.GetLength(0) == 9 && puzzle.Array.GetLength(1) == 9)
            {
                for(int i = 0; i < 9; i++)
                {
                    for(int j = 0; j < 9; j++)
                    {
                        if(!(puzzle.Array[i, j] >= 1 && puzzle.Array[i, j] <= 9))
                        {
                            if(puzzle.Array[i, j] != puzzle.EmptyCell)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
