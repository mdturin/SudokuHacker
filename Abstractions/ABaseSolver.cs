using SudokuHacker.Interfaces;
using SudokuHacker.Models;
using System.Collections.Concurrent;

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

        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = 5
        };

        var validationResults = new ConcurrentBag<bool>();

        Parallel.ForEach(blocks, options, block =>
        {
            var validationErrors = new ConcurrentDictionary<int, bool>();
            Parallel.ForEach(block, options, cell => {
                var x = cell.X;
                var y = cell.Y;
                var num = data[x][y];

                if(num == 0) return;

                if(validationErrors.ContainsKey(num))
                {
                    Console.WriteLine($"Validation error: {num} already exists in block {block}");
                    validationResults.Add(false);
                    return;
                }
                
                if(num < 0 || num > rowSize)
                {
                    Console.WriteLine($"Validation error: {num} is out of range in block {block}");
                    validationResults.Add(false);
                    return;
                }

                validationErrors.TryAdd(num, true);
            });
        });

        return validationResults.All(r => r);
    }
}
