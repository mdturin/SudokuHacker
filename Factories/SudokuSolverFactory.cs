using SudokuHacker.Helpers;
using SudokuHacker.Interfaces;

namespace SudokuHacker.Factories;

public class SudokuSolverFactory
{
    public static ISolver GetSolver(string solverType)
    {
        return solverType switch
        {
            "normal" => new SudokuSolver(),
            _ => throw new NotImplementedException()
        };
    }
}
