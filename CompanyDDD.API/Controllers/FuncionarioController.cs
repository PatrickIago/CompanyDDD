using CompanyDDD.Application.Validators.FuncionarioValidators;
using CompanyDDD.Domain.DTOs.FuncionarioDto;
using CompanyDDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioController(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    // Lista todos os funcionarios
    [HttpGet("Lista todos os funcionarios")]
    public async Task<ActionResult<List<FuncionarioDTO>>> GetAllFuncionarios()
    {
        var funcionarios = await _funcionarioRepository.GetAllAsync();
        return Ok(funcionarios);
    }

    // Buscar funcionario por um Id especifico
    [HttpGet("Buscar funcionario por um Id especifico/{id}")]
    public async Task<ActionResult<FuncionarioDTO>> GetFuncionarioById(int id)
    {
        var funcionario = await _funcionarioRepository.GetByIdAsync(id);
        if (funcionario == null)
            return NotFound("Funcionario não encontrado");

        return Ok(funcionario);
    }

    // Adiciona um novo funcionario
    [HttpPost("Adiciona um novo funcionario")]
    public async Task<ActionResult<FuncionarioDTO>> AddFuncionario(FuncionarioCreateDTO funcionarioCreateDTO)
    {
        var validator = new FuncionarioCreateValidator();
        var validationResult = await validator.ValidateAsync(funcionarioCreateDTO);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var funcionario = await _funcionarioRepository.AddAsync(funcionarioCreateDTO);
        return Ok(funcionario);
    }

    // Atualiza dados de um funcionario ja existente
    [HttpPut("Atualiza dados de um funcionario ja existente/{id}")]
    public async Task<ActionResult<FuncionarioDTO>> UpdateFuncionario(int id, FuncionarioUpdateDTO funcionarioUpdateDTO)
    {
        if (id != funcionarioUpdateDTO.Id)
            return BadRequest("ID não corresponde ao funcionario a ser atualizado");

        var validator = new FuncionarioUpdateValidator();
        var validationResult = await validator.ValidateAsync(funcionarioUpdateDTO);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var funcionario = await _funcionarioRepository.UpdateAsync(funcionarioUpdateDTO);
        if (funcionario == null)
            return NotFound();

        return Ok(funcionario);
    }

    // Remove um funcionario por Id especifico
    [HttpDelete("Remove um funcionario por Id especifico/{id}")]
    public async Task<ActionResult> DeleteFuncionario(int id)
    {
        var funcionario = await _funcionarioRepository.DeleteAsync(id);
        if (funcionario == null)
            return NotFound("Funcionario não encontrado");

        return NoContent();
    }
}
