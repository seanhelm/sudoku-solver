using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Solver
    {
        /// <summary>
        /// Puzzle object to hold Sudoku puzzle data
        /// </summary>
        public Puzzle Puzzle { get; private set; }

        /// <summary>
        /// Creates new Solver to hold Sudoku puzzle data
        /// </summary>
        /// <param name="puzzle"></param>
        public Solver(Puzzle puzzle)
        {
            if(SudokuValidator.IsValidPuzzle(puzzle))
            {
                Puzzle = puzzle;
            }
            else
            {
                throw new ArgumentException(String.Format("{0} must be a valid sudoku puzzle.",
                    puzzle), "puzzle");
            }
        }

        /// <summary>
        /// Solves Sudoku puzzle using a Backtracking algorithm
        /// </summary>
        /// <returns>Completed Sudoku puzzle, or null if not solveable</returns>
        public Puzzle Solve()
        {
            Puzzle pp = new Puzzle(Puzzle.Array);

            if(SolveWithBacktracking(pp))
            {
                return pp;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Solves Sudoku puzzle using a Backtracking algorithm
        /// </summary>
        /// <param name="puzzle">Sudoku Puzzle to be modified and solved</param>
        /// <returns>True if solved, false otherwise</returns>
        private bool SolveWithBacktracking(Puzzle puzzle)
        {
            int row, column;
            
            if(!nextEmptyCell(puzzle, out row, out column))
            {
                return true;
            }

            for(int value = 1; value <= 9; value++)
            {
                if(SudokuValidator.IsValidCell(puzzle, value, row, column))
                {
                    puzzle.Array[row, column] = value;

                    if(SolveWithBacktracking(puzzle))
                    {
                        return true;
                    }

                    puzzle.Array[row, column] = puzzle.EmptyCell;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds the next empty cell in a Puzzle
        /// </summary>
        /// <param name="puzzle">Puzzle to be searched</param>
        /// <param name="row">Out row to return the row of the next empty cell</param>
        /// <param name="column">Out column to return the column of the next empty cell</param>
        /// <returns>True if there are any empty cells, false otherwise</returns>
        private bool nextEmptyCell(Puzzle puzzle, out int row, out int column)
        {
            row = column = 0;

            for(row = 0; row < 9; row++)
            {
                for(column = 0; column < 9; column++)
                {
                    if(puzzle.Array[row, column] == puzzle.EmptyCell)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
