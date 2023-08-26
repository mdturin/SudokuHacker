using SudokuHacker.Models;

namespace SudokuHacker.Extensions;

public static class SudokuGridExtension
{
    public static List<int> GetOptions(
        this SudokuGrid grid, List<PairModel> block, int i, int j)
    {
        var options = new List<int>();

        foreach(var num in Enumerable.Range(1, grid.Data.Count))
            if(grid.IsValidOption(block, i, j, num))
                options.Add(num);

        return options;
    }

    private static bool IsValidOption(
        this SudokuGrid grid, 
        List<PairModel> block,
        int i, int j, int num)
    {
        if(Enumerable
            .Range(0, grid.Data.Count)
            .Any(k => grid.Data[i][k] == num || grid.Data[k][j] == num))
        {
            return false;
        }

        if(block.Any(cell => cell.X == i && cell.Y == j) && 
            block.All(cell => grid.Data[cell.X][cell.Y] != num))
        {
            return true;
        }

        return false;
    }
}
