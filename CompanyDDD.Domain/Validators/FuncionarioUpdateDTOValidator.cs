using CompanyDDD.Domain.DTOs;
using FluentValidation;
namespace CompanyDDD.Domain.Validators;
public class FuncionarioUpdateDTOValidator : AbstractValidator<FuncionarioUpdateDTO>
{
    public FuncionarioUpdateDTOValidator()
    {
        RuleFor(Funcionario => Funcionario.Nome).NotEmpty().WithMessage("Nome é obrigatorio");
        RuleFor(Funcionario => Funcionario.Email).NotEmpty().WithMessage("Email não pode estar vazio");
        RuleFor(Funcionario => Funcionario.Contato).NotEmpty().WithMessage("Contato não pode estar vazio");
    }
}
