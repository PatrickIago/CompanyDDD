using CompanyDDD.Domain.DTOs.FuncionarioDto;
using CompanyDDD.Domain.Entities;
using CompanyDDD.Domain.Repositories;
using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyDDD.API.Services;

public class FuncionarioService : IFuncionarioRepository
{
    private readonly CompanyDbContext _context;
    public FuncionarioService(CompanyDbContext context)
    {
        _context = context;
    }

    public async Task<FuncionarioDTO> AddAsync(FuncionarioCreateDTO dto)
    {
        var departamento = await _context.Departamentos
            .FirstOrDefaultAsync(d => d.Id == dto.DepartamentoId);

        if (departamento == null)
            throw new Exception("Departamento informado não existe.");

        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            Salario = dto.Salario,
            Email = dto.Email,
            Contato = dto.Contato,
            DataNascimento = dto.DataNascimento,
            DepartamentoId = dto.DepartamentoId
        };

        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        return new FuncionarioDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email,
            Salario = funcionario.Salario,
            DepartamentoId = departamento.Id,
            DepartamentoNome = departamento.Nome,
            Descricao = departamento.Descricao
        };
    }

    public async Task<FuncionarioDTO?> DeleteAsync(int id)
    {
        var funcionario = await _context.Funcionarios.Include(f => f.Departamento)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (funcionario == null) return null;

        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();

        return new FuncionarioDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email,
            Salario = funcionario.Salario,
            DepartamentoId = funcionario.DepartamentoId,
            DepartamentoNome = funcionario.Departamento.Nome,
            Descricao = funcionario.Departamento.Descricao
        };
    }

    public async Task<List<FuncionarioDTO>> GetAllAsync()
    {
        var funcionarios = await _context.Funcionarios.Include(f => f.Departamento).ToListAsync();

        return funcionarios.Select(f => new FuncionarioDTO
        {
            Id = f.Id,
            Nome = f.Nome,
            Email = f.Email,
            Salario = f.Salario,
            DepartamentoId = f.DepartamentoId,
            DepartamentoNome = f.Departamento.Nome,
            Descricao = f.Departamento.Descricao
        }).ToList();
    }

    public async Task<FuncionarioDTO?> GetByIdAsync(int id)
    {
        var f = await _context.Funcionarios.Include(f => f.Departamento)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (f == null) return null;

        return new FuncionarioDTO
        {
            Id = f.Id,
            Nome = f.Nome,
            Email = f.Email,
            Salario = f.Salario,
            DepartamentoId = f.DepartamentoId,
            DepartamentoNome = f.Departamento.Nome,
            Descricao = f.Departamento.Descricao
        };
    }

    public async Task<FuncionarioDTO?> UpdateAsync(FuncionarioUpdateDTO dto)
    {
        var funcionario = await _context.Funcionarios.Include(f => f.Departamento)
            .FirstOrDefaultAsync(f => f.Id == dto.Id);

        if (funcionario == null) return null;

        funcionario.Nome = dto.Nome;
        funcionario.Salario = dto.Salario;
        funcionario.Email = dto.Email;
        funcionario.Contato = dto.Contato;
        funcionario.DataNascimento = dto.DataNascimento;

        await _context.SaveChangesAsync();

        return new FuncionarioDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email,
            Salario = funcionario.Salario,
            DepartamentoId = funcionario.DepartamentoId,
            DepartamentoNome = funcionario.Departamento.Nome,
            Descricao = funcionario.Departamento.Descricao
        };
    }
}
