using SudokuHacker.Abstractors;
using SudokuHacker.Interfaces;
using SudokuHacker.Solvers;

namespace SudokuHacker.Creators;

public class NormalSudokuSolverCreator : ASudokuCreator
{
    public override ISolver GetSolver()
    {
        return new NormalSudokuSolver();
    }
}
