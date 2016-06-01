using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    static class SudokuValidator
    {
        /// <summary>
        /// Checks if a given sudoku array is a valid Sudoku puzzle
        /// </summary>
        /// <param name="sudokuArray">2D array representing Sudoku puzzle</param>
        /// <returns>True if it is a valid puzzle, false otherwise</returns>
        public static bool IsValidPuzzle(int[,] sudokuArray)
        {
            if(IsValidArray(sudokuArray))
            {
                for(int i = 0; i < 9; i++)
                {
                    HashSet<int> row = new HashSet<int>();
                    HashSet<int> column = new HashSet<int>();

                    for(int j = 0; j < 9; j++)
                    {
                        if(sudokuArray[i, j] != 0 && !row.Add(sudokuArray[i, j]))
                        {
                            return false;
                        }

                        if(sudokuArray[j, i] != 0 && !column.Add(sudokuArray[j, i]))
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
                                if(sudokuArray[i + a, j + b] != 0 
                                    && !region.Add(sudokuArray[i + a, j + b]))
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
        /// Checks if a given sudoku array is a valid and complete Sudoku puzzle
        /// </summary>
        /// <param name="sudokuArray">2D array representing Sudoku puzzle</param>
        /// <returns>True if it is a valid and complete puzzle, false otherwise</returns>
        public static bool IsValidComplete(int[,] sudokuArray)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(sudokuArray[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return IsValidPuzzle(sudokuArray);
        }

        /// <summary>
        /// Checks if given 2D array has the correct dimensions and contains no invalid values
        /// </summary>
        /// <param name="sudokuArray">2D array to be validated</param>
        /// <returns>True if it is valid, false otherwise</returns>
        private static bool IsValidArray(int[,] sudokuArray)
        {
            if(sudokuArray.GetLength(0) == 9 && sudokuArray.GetLength(1) == 9)
            {
                for(int i = 0; i < 9; i++)
                {
                    for(int j = 0; j < 9; j++)
                    {
                        if(sudokuArray[i, j] > 9 || sudokuArray[i, j] < 0)
                        {
                            return false;
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
