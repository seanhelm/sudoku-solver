namespace SudokuSolver
{
    class Puzzle
    {
        /// <summary>
        /// Int array to hold numbers for puzzle
        /// </summary>
        public int[,] Array { get; set; }

        /// <summary>
        /// Integer value to represent an empty cell in the 2D array
        /// </summary>
        public int EmptyCell { get; private set; }

        /// <summary>
        /// Constructor for new Puzzle to hold puzzle number data
        /// </summary>
        /// <param name="puzzle">2D array representing puzzle data</param>
        public Puzzle(int[,] puzzle)
        {
            Array = puzzle;
            EmptyCell = 0;
        }

        /// <summary>
        /// Constructor for new Puzzle to hold puzzle number data
        /// </summary>
        /// <param name="puzzle">2D array representing puzzle data</param>
        /// <param name="emptyCell">Integer value to represent an empty cell</param>
        public Puzzle(int[,] puzzle, int emptyCell)
        {
            Array = puzzle;
            EmptyCell = emptyCell;
        }
    }
}
