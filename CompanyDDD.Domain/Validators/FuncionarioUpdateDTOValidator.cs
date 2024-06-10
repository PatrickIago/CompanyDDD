using CompanyDDD.Domain.DTOs;
using FluentValidation;
namespace CompanyDDD.Domain.Validators;
public class FuncionarioUpdateDTOValidator : AbstractValidator<FuncionarioUpdateDTO>
{
    public FuncionarioUpdateDTOValidator()
    {
        RuleFor(Funcionario => Funcionario.Nome).NotEmpty().WithMessage("Nome é obrigatorio");
        RuleFor(Funcionario => Funcionario.Email)
            .NotEmpty().WithMessage("O email não pode estar vazio")
            .Must(email => email.Contains("@gmail")).WithMessage("Email precisa conter '@gmail'.");
        RuleFor(Funcionario => Funcionario.Contato).NotEmpty().WithMessage("O contato não pode estar vazio");
    }
}
