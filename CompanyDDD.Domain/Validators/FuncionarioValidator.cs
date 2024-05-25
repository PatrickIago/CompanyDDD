using CompanyDDD.Domain.Entities;
using FluentValidation;
namespace CompanyDDD.Domain.Validators;
public class FuncionarioValidator : AbstractValidator<Funcionario>
{
    public FuncionarioValidator()
    {
        RuleFor(Funcionario => Funcionario.Nome).NotEmpty().WithMessage("Nome é obrigatorio");
        RuleFor(Funcionario => Funcionario.Email).NotEmpty().WithMessage("O email não pode estar vazio");
        RuleFor(Funcionario => Funcionario.Contato).NotEmpty().WithMessage("O contato não pode estar vazio");
    }
}
