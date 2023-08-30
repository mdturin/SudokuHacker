using SudokuHacker.Interfaces;

namespace SudokuHacker.Abstractors;

public abstract class ASudokuCreator : ISudokuCreator
{
    public abstract ISolver GetSolver();
}
