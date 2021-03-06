﻿using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleParser pp = new PuzzleParser(".9......6...96.485...581.....4......5172..9..6.2...37.1..8.4.2.7.6...81.3...9....");
            Console.WriteLine(pp.PuzzleAsString);
            Console.WriteLine(SudokuDisplayer.Display(pp.Puzzle));

            Solver sp = new Solver(pp.Puzzle);
            Console.WriteLine(SudokuDisplayer.Display(sp.Solve()));

            Console.ReadKey();
        }
    }
}
