using CompanyDDD.Domain.DTOs.DepartamentoDto;
using CompanyDDD.Domain.Entities;

public interface IDepartamentoRepository
{
    Task<Departamento?> GetByIdAsync(int id);                
    Task<List<Departamento>> GetAllAsync();
    Task<Departamento> AddAsync(DepartamentoCreateDto dto);
    Task<Departamento> UpdateAsync(DepartamentoUpdateDto dto);
    Task<Departamento?> DeleteAsync(int id);      
}
