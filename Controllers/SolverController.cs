using Microsoft.AspNetCore.Mvc;
using SudokuHacker.Dtos;
using SudokuHacker.Models;
using SudokuHacker.Services;

namespace SudokuHacker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolverController : ControllerBase
{
    private readonly SudokuService _service;

    public SolverController(SudokuService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<SudokoSolvedDto> Post([FromBody] SudokuGrid grid)
    {
        try
        {
            var result = _service.Solve(grid);

            var answer = new SudokoSolvedDto
            {
                Data = result.Data
            };

            return Ok(answer);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
