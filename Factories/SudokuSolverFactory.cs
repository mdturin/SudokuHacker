using SudokuHacker.Abstractors;
using SudokuHacker.Helpers;
using SudokuHacker.Interfaces;

namespace SudokuHacker.Factories;

public class SudokuSolverFactory
{
    public static ISolver GetSolver(string solverType)
    {
        var creator = GetCreator(solverType);
        return creator.GetSolver();
    }

    private static ISudokuCreator GetCreator(string solverType)
    {
        var creatorName = ConfigurationHelper.GetValue("SudokuCreators", solverType);

        var creatorType = Type.GetType(creatorName!);
        if (creatorType == null)
            throw new Exception($"Creator {creatorName} not found");

        if(!typeof(ASudokuCreator).IsAssignableFrom(creatorType))
            throw new Exception($"Creator {creatorName} is not a ISudokuCreator");

        var instance = (ASudokuCreator) Activator.CreateInstance(creatorType)!;
        if (instance == null)
            throw new Exception($"Creator {creatorName} not found");

        return instance;
    }
}
