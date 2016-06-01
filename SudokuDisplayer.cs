using System.Text;
using System;

namespace SudokuSolver
{
    static class SudokuDisplayer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="puzzleArray"></param>
        /// <returns></returns>
        public static string Display(int[,] puzzleArray)
        {
            StringBuilder puzzleRep = new StringBuilder();

            if(SudokuValidator.IsValidPuzzle(puzzleArray))
            {
                for(int i = 0; i < puzzleArray.GetLength(0); i++)
                {
                    if(i % 3 == 0)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            puzzleRep.Append("+");
                            puzzleRep.Append(new string('-', puzzleArray.GetLength(1) / 2 + 3));
                        }
                        puzzleRep.Append("+\n");
                    }

                    for(int j = 0; j < puzzleArray.GetLength(1); j++)
                    {
                        if(j % 3 == 0)
                        {
                            puzzleRep.Append("| ");
                        }

                        if(puzzleArray[i, j] == 0)
                        {
                            puzzleRep.Append(". ");
                        }
                        else
                        {
                            puzzleRep.Append(puzzleArray[i, j].ToString() + " ");
                        }
                    }

                    puzzleRep.Append("|\n");
                }

                for(int k = 0; k < 3; k++)
                {
                    puzzleRep.Append("+");
                    puzzleRep.Append(new string('-', puzzleArray.GetLength(1) / 2 + 3));
                }
                puzzleRep.Append("+\n");
            }
            else
            {
                throw new ArgumentException(String.Format("{0} must be a valid sudoku puzzle.",
                    puzzleArray), "puzzleArray");
            }

            return puzzleRep.ToString();
        }
    }
}
