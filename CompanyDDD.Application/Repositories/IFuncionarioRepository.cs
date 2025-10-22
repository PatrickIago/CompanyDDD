using CompanyDDD.Domain.DTOs.FuncionarioDto;
namespace CompanyDDD.Domain.Repositories;

public interface IFuncionarioRepository
{
    Task<FuncionarioDTO> GetByIdAsync(int id);
    Task<List<FuncionarioDTO>> GetAllAsync();
    Task<FuncionarioDTO> AddAsync(FuncionarioCreateDTO funcionarioCreateDTO);
    Task<FuncionarioDTO> UpdateAsync(FuncionarioUpdateDTO funcionarioUpdateDTO);
    Task<FuncionarioDTO?> DeleteAsync(int id);
}
