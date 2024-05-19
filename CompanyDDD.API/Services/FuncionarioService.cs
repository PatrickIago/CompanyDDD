using CompanyDDD.Domain.DTOs;
using CompanyDDD.Domain.Entities;
using CompanyDDD.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyDDD.API.Services;
    public class FuncionarioService
    {
        private readonly CompanyDbContext _context;
        public FuncionarioService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<Funcionario> AddAsync(FuncionarioCreateDTO funcionarioCreateDTO)
        {
            var funcionario = new Funcionario()
            {
                Nome = funcionarioCreateDTO.Nome,
            Salario = funcionarioCreateDTO.Salario,
            DataNascimento = funcionarioCreateDTO.DataNascimento
            };
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task DeleteAsync(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario != null)
            {
                _context.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Funcionario>> GetAllAsync()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            return funcionarios;
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
            if (funcionario == null)
            {
                return null;
            }

            return funcionario;
        }

        public async Task<Funcionario> UpdateAsync(FuncionarioUpdateDTO funcionarioUpdateDTO)
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcionarioUpdateDTO.Id);

            if (funcionario == null)
            {
                return null;
            }

            funcionario.Nome = funcionarioUpdateDTO.Nome;
        funcionario.Salario = funcionarioUpdateDTO.Salario;
        funcionario.DataNascimento = funcionarioUpdateDTO.DataNascimento;
            await _context.SaveChangesAsync();
            return funcionario;
        }
    }
}

