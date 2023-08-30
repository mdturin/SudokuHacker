using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SudokuHacker.Dtos;
using SudokuHacker.Models;
using SudokuHacker.Services;

namespace SudokuHacker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolverController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly SudokuService _service;

    public SolverController(SudokuService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    //[HttpPost]
    //public ActionResult<SudokoSolvedDto> Post([FromBody] SudokuGrid grid)
    //{
    //    try
    //    {
    //        var result = _service.Solve(grid);
    //        var answer = _mapper
    //            .Map<SudokoSolvedDto>(result);
    //        return Ok(answer);
    //    }
    //    catch(Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}
