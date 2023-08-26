using SudokuHacker.Interfaces;
using SudokuHacker.Models;

namespace SudokuHacker.Abstractions;

public abstract class ABaseSolver : ISolver
{
    public abstract SudokuGrid Solve(
        SudokuGrid grid, 
        List<List<PairModel>> blocks, 
        Dictionary<PairModel, int> blockToId);

    public virtual bool ValidationCheck(
        SudokuGrid grid, 
        List<List<PairModel>> blocks)
    {
        var data = grid.Data;
        if(data.Count == 0)
        {
            return false;
        }

        var rowSize = data[0].Count;
        foreach(var row in data)
        {
            if(row.Count != rowSize) 
                return false;

            foreach(var num in row)
            {
                if(num < 0 || num > rowSize)
                    return false;
            }
        }

        foreach(var block in blocks)
        {
            var validationErrors = new Dictionary<int, bool>();

            foreach(var cell in block)
            {
                var x = cell.X;
                var y = cell.Y;
                var num = data[x][y];

                if(num == 0)
                    continue;

                if(validationErrors.ContainsKey(num))
                {
                    Console.WriteLine($"Validation error: {num} already exists in block {block}");
                    return false;
                }

                if(num < 0 || num > rowSize)
                {
                    Console.WriteLine($"Validation error: {num} is out of range in block {block}");
                    return false;
                }

                validationErrors[num] = true;
            }
        }

        return true;
    }
}
