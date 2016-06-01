using System.Text;
using System;

namespace SudokuSolver
{
	class SudokuDisplayer
	{
		/// <summary>
		/// String display to allow for printing to the console
		/// </summary>
		public string Display { get; private set; }

		/// <summary>
		/// Constructor to set new display for a valid Sudoku puzzle
		/// </summary>
		/// <param name="puzzleArray">Puzzle in 2D array</param>
		public SudokuDisplayer(int[,] puzzleArray)
		{
			SetDisplay(puzzleArray);
		}

		/// <summary>
		/// Set the display for a valid Sudoku puzzle
		/// </summary>
		/// <param name="puzzleArray">Puzzle in 2D array</param>
		public void SetDisplay(int[,] puzzleArray)
		{
			StringBuilder puzzleRep = new StringBuilder();

			if (CheckValid(puzzleArray))
			{
				for (int i = 0; i < puzzleArray.GetLength(0); i++)
				{
					if (i % 3 == 0)
					{
						for (int k = 0; k < 3; k++)
						{
							puzzleRep.Append("+");
							puzzleRep.Append(new string('-', puzzleArray.GetLength(1) / 2 + 3));
						}
						puzzleRep.Append("+\n");
					}

					for (int j = 0; j < puzzleArray.GetLength(1); j++)
					{
						if (j % 3 == 0)
						{
							puzzleRep.Append("| ");
						}

						if (puzzleArray[i, j] == 0)
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

				for (int k = 0; k < 3; k++)
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

			Display = puzzleRep.ToString();
		}

		/// <summary>
		/// Determines if a given puzzle is a valid Sudoku puzzle
		/// </summary>
		/// <param name="puzzleArray">2D array representing puzzle</param>
		/// <returns>True if array is a valid Sudoku puzzle, false otherwise</returns>
		private bool CheckValid(int[,] puzzleArray)
		{
			if (puzzleArray.GetLength(0) == 9 && puzzleArray.GetLength(1) == 9)
			{
				for (int i = 0; i < puzzleArray.GetLength(0); i++)
				{
					for (int j = 0; j < puzzleArray.GetLength(1); j++)
					{
						if (puzzleArray[i, j] > 9 || puzzleArray[i, j] < 0)
						{
							return false;
						}
					}
				}
			}
			else
			{
				return false;
			}

			return true;
		}
	}
}
