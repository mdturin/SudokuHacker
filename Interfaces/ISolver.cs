using SudokuHacker.Models;

namespace SudokuHacker.Interfaces;

public interface ISolver
{
    SudokuGrid Solve(
        SudokuGrid grid, 
        List<List<PairModel>> blocks,
        Dictionary<PairModel, int> blockToId
    );
}
