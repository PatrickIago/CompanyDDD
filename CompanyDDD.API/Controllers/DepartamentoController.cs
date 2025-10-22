using CompanyDDD.Application.Validators.DepartamentoValidators;
using CompanyDDD.Domain.DTOs.DepartamentoDto;
using CompanyDDD.Domain.Entities;
using CompanyDDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoRepository _departamentoRepository;

    public DepartamentoController(IDepartamentoRepository departamentoRepository)
    {
        _departamentoRepository = departamentoRepository;
    }

    [HttpGet("Lista todos os departamentos")]
    public async Task<ActionResult<List<Departamento>>> GetAllDepartamentos()
    {
        var departamentos = await _departamentoRepository.GetAllAsync();
        return Ok(departamentos);
    }

    [HttpGet("Busca um departamento por Id especifico")]
    public async Task<ActionResult<Departamento>> GetDepartamentoById(int id)
    {
        var departamento = await _departamentoRepository.GetByIdAsync(id);
        if (departamento == null)
            return NotFound("Departamento não encontrado");

        return Ok(departamento);
    }

    [HttpPost("Adiciona um novo departamento")]
    public async Task<ActionResult<Departamento>> AddDepartamento(DepartamentoCreateDto departamentoCreateDto)
    {
        var departamento = await _departamentoRepository.AddAsync(departamentoCreateDto);
        return Ok(departamento);
    }

    [HttpPut("Atualiza os dados de um departamento existente")]
    public async Task<ActionResult<Departamento>> UpdateDepartamento(int id, DepartamentoUpdateDto departamentoUpdateDto)
    {
        if (id != departamentoUpdateDto.Id)
            return BadRequest("O ID informado não corresponde ao departamento a ser atualizado.");

        var departamento = await _departamentoRepository.UpdateAsync(departamentoUpdateDto);
        if (departamento == null)
            return NotFound();

        return Ok(departamento);
    }

    [HttpDelete("Remove um departamento especifico")]
    public async Task<ActionResult> DeleteDepartamento(int id)
    {
        var departamento = await _departamentoRepository.DeleteAsync(id);
        if (departamento == null)
            return NotFound("Departamento não encontrado");

        return NoContent();
    }
}
