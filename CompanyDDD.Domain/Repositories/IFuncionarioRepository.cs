using CompanyDDD.Domain.DTOs;
using CompanyDDD.Domain.Entities;
namespace CompanyDDD.Domain.Repositories;
public interface IFuncionarioRepository
{
    Task<Funcionario> GetByIdAsync(int id);
    Task<List<Funcionario>> GetAllAsync();
    Task<Funcionario> AddAsync(FuncionarioCreateDTO funcionarioCreateDTO);
    Task <Funcionario> UpdateAsync(FuncionarioUpdateDTO funcionarioUpdateDTO);
    Task DeleteAsync(int id);
}
 