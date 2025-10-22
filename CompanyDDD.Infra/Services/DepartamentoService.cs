using CompanyDDD.Domain.DTOs.DepartamentoDto;
using CompanyDDD.Domain.Entities;
using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;
namespace CompanyDDD.Infra.Services;

public class DepartamentoService : IDepartamentoRepository
{
    private readonly CompanyDbContext _context;

    public DepartamentoService(CompanyDbContext context)
    {
        _context = context;
    }

    public async Task<Departamento> AddAsync(DepartamentoCreateDto dto)
    {
        var departamento = new Departamento
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };

        _context.Departamentos.Add(departamento);
        await _context.SaveChangesAsync();
        return departamento;
    }

    public async Task<Departamento?> DeleteAsync(int id)
    {
        var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
        if (departamento == null) return null;

        _context.Departamentos.Remove(departamento);
        await _context.SaveChangesAsync();
        return departamento;
    }

    public async Task<List<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<Departamento?> GetByIdAsync(int id)
    {
        return await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Departamento> UpdateAsync(DepartamentoUpdateDto dto)
    {
        var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == dto.Id);
        if (departamento == null)
            throw new Exception("Departamento não encontrado");

        departamento.Nome = dto.Nome;
        departamento.Descricao = dto.Descricao;

        _context.Departamentos.Update(departamento);
        await _context.SaveChangesAsync();
        return departamento;
    }
}

