using CompanyDDD.Domain.DTOs.FuncionarioDto;
using FluentValidation;
namespace CompanyDDD.Application.Validators.FuncionarioValidators;

public class FuncionarioUpdateValidator : AbstractValidator<FuncionarioUpdateDTO>
{
    public FuncionarioUpdateValidator()
    {
        RuleFor(Funcionario => Funcionario.Id)
            .NotEmpty()
            .WithMessage("O Id deve ser informado");

        RuleFor(Funcionario => Funcionario.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatorio");

        RuleFor(Funcionario => Funcionario.DataNascimento)
            .NotEmpty()
            .WithMessage("A data de nascimento não pode estar vazia");

        RuleFor(Funcionario => Funcionario.Email)
            .NotEmpty().WithMessage("O email não pode estar vazio")
            .Must(email => email.Contains("@gmail"))
            .WithMessage("Email precisa conter '@gmail'.");

        RuleFor(Funcionario => Funcionario.Contato)
            .NotEmpty()
            .WithMessage("O contato não pode estar vazio");
    }
}
