using AutoMapper;
using SudokuHacker.Dtos;
using SudokuHacker.Models;
using SudokuHacker.Services;

namespace SudokuHacker.Extensions;

public static class SudokuControllerExtension
{
    public static WebApplication MapSudoku(this WebApplication app)
    {
        app.MapPost("api/sudoku", (SudokuGrid grid, SudokuService service, IMapper mapper) =>
        {
            try
            {
                var result = service.Solve(grid);
                var answer = mapper
                    .Map<SudokoSolvedDto>(result);
                return Results.Ok(answer);
            }
            catch(Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        return app;
    }
}
