using SudokuHacker.Abstractors;
using SudokuHacker.Extensions;
using SudokuHacker.Interfaces;
using SudokuHacker.Models;

namespace SudokuHacker.Solvers;

public class NormalSudokuSolver : ABaseSolver, ISolver
{
    public SudokuGrid Solve(
        SudokuGrid grid,
        List<List<PairModel>> blocks,
        Dictionary<PairModel, int> blockToId)
    {
        if (!ValidationCheck(grid, blocks))
            throw new ArgumentException("ValidationCheck: Invalid Grid");

        return DoExecute(grid, blocks, blockToId, 0, 0) ??
            throw new ArgumentException("DoExecute: Invalid Grid");
    }

    private SudokuGrid? DoExecute(
        SudokuGrid grid,
        List<List<PairModel>> blocks,
        Dictionary<PairModel, int> blockToId, int i, int j)
    {
        if (i == grid.Data.Count) return grid;

        if (j == grid.Data[i].Count)
            return DoExecute(grid, blocks, blockToId, i + 1, 0);

        if (grid.Data[i][j] != 0)
            return DoExecute(grid, blocks, blockToId, i, j + 1);

        PairModel currentPair = new() { X = i, Y = j };
        var block = blocks[blockToId[currentPair]];

        var options = grid.GetOptions(block, i, j);
        foreach (var option in options)
        {
            grid.Data[i][j] = option;
            if (DoExecute(grid, blocks, blockToId, i, j + 1) != null)
                return grid;
        }

        grid.Data[i][j] = 0;
        return null;
    }
}
