namespace SudokuHacker.Models;

public class PairModel
{
    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        var other = obj as PairModel;
        return other!.X == X && other.Y == Y;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}