using CompanyDDD.API.Services;
using CompanyDDD.Domain.DTOs;
using CompanyDDD.Domain.Entities;
using CompanyDDD.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet("ListarFuncionarios")]
    public async Task<ActionResult<List<Funcionario>>> GetAllFuncionarios()
    {
        var funcionarios = await _funcionarioService.GetAllAsync();
        return Ok(funcionarios);
    }

    [HttpGet("BuscarPorId{id}")]
    public async Task<ActionResult<Funcionario>> GetFuncionarioById(int id)
    {
        var funcionario = await _funcionarioService.GetByIdAsync(id);
        if (funcionario == null)
        {
            return BadRequest("Funcionario não encontrado");
        }
        return Ok(funcionario);
    }

    [HttpPost("AdicionarFuncionario")]
    public async Task<ActionResult<Funcionario>> AddFuncionario(FuncionarioCreateDTO funcionarioCreateDTO)
    {
        var validator = new FuncionarioCreateDTOValidator();
        var validationResult = await validator.ValidateAsync(funcionarioCreateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest("Erro ao adicionar funcionario");
            return BadRequest(validationResult.Errors);
        }

        var funcionario = await _funcionarioService.AddAsync(funcionarioCreateDTO);
        return Ok(funcionario);
    }

    [HttpPut("AtualizarFuncionario{id}")]
    public async Task<ActionResult<Funcionario>> UpdateFuncionario(int id, FuncionarioUpdateDTO funcionarioUpdateDTO)
    {
        var validator = new FuncionarioUpdateDTOValidator();
        var validationResult = await validator.ValidateAsync(funcionarioUpdateDTO);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var funcionario = await _funcionarioService.UpdateAsync(funcionarioUpdateDTO);
        if (funcionario == null)
        {
            return NotFound();
        }

        return Ok(funcionario);
    }

    [HttpDelete("DeletarFuncionario{id}")]
    public async Task<ActionResult> DeleteFuncionario(int id)
    {
        await _funcionarioService.DeleteAsync(id);
        return NoContent();
    }
}
