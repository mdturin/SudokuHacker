namespace SudokuHacker.Models;

public class SudokuGrid
{
    public string Type { get; set; } = string.Empty;
    public IList<IList<int>> Data { get; set; } = new List<IList<int>>();
    public int Size() => Data.Count;
}
