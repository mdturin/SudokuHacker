using AutoMapper;
using SudokuHacker.Dtos;
using SudokuHacker.Models;

namespace SudokuHacker.Helpers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<SudokuGrid, SudokoSolvedDto>();
    }
}
