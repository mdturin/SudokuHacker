using SudokuHacker.Factories;
using SudokuHacker.Models;

namespace SudokuHacker.Services;

public class SudokuService
{
    private const string _blocks = "Blocks.json";

    public SudokuGrid Solve(SudokuGrid grid)
    {
        var type = grid.Type.ToLower();
        var solver = SudokuSolverFactory.GetSolver(type);
        var blocks = JsonReaderService
            .ReadDictionaryData<List<List<PairModel>>>(_blocks, type);

        var blockToId = new Dictionary<PairModel, int>();   
        for(int i=0; i<blocks.Count; ++i)
            foreach(var pair in blocks[i])
                blockToId.Add(pair, i);

        var result = solver.Solve(grid, blocks, blockToId);

        return result;
    }
}
