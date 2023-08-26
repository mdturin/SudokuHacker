namespace SudokuHacker.Dtos;

public class SudokoSolvedDto
{
    public IList<IList<int>> Data { get; set; } = new List<IList<int>>();
}
