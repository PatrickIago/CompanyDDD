using CompanyDDD.API.Services;
using CompanyDDD.Domain.DTOs;
using CompanyDDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyDDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> GetAllFuncionarios()
        {
            var funcionarios = await _funcionarioService.GetAllAsync();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionarioById(int id)
        {
            var funcionario = await _funcionarioService.GetByIdAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> AddFuncionario(FuncionarioCreateDTO funcionarioCreateDTO)
        {
            var funcionario = await _funcionarioService.AddAsync(funcionarioCreateDTO);
            return funcionario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Funcionario>> UpdateFuncionario(int id, FuncionarioUpdateDTO funcionarioUpdateDTO)
        {
            if (id != funcionarioUpdateDTO.Id)
            {
                return BadRequest();
            }

            var funcionario = await _funcionarioService.UpdateAsync(funcionarioUpdateDTO);
            if (funcionario == null)
            {
                return null;
            }

            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFuncionario(int id)
        {
            await _funcionarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}