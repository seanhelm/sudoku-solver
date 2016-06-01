using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    static class SudokuValidator
    {
        public static bool IsValidPuzzle(int[,] sudokuArray)
        {
            if(IsValidArray(sudokuArray))
            {
                for(int i = 0; i < sudokuArray.GetLength(0); i++)
                {
                    HashSet<int> row = new HashSet<int>();
                    HashSet<int> column = new HashSet<int>();

                    for(int j = 0; j < sudokuArray.GetLength(1); j++)
                    {
                        if(sudokuArray[i, j] != 0)
                        {
                            if(!row.Add(sudokuArray[i, j]))
                            {
                                return false;
                            }
                        }

                        if(sudokuArray[j, i] != 0)
                        {
                            if(!column.Add(sudokuArray[j, i]))
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

        public static bool IsValidComplete(int[,] sudokuArray)
        {
            return false;
        }

        private static bool IsValidArray(int[,] sudokuArray)
        {
            if(sudokuArray.GetLength(0) == 9 && sudokuArray.GetLength(1) == 9)
            {
                for(int i = 0; i < sudokuArray.GetLength(0); i++)
                {
                    for(int j = 0; j < sudokuArray.GetLength(1); j++)
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
