using CompanyDDD.Domain.DTOs.DepartamentoDto;
using FluentValidation;
namespace CompanyDDD.Application.Validators.DepartamentoValidators;

public class DepartamentoUpdateValidator : AbstractValidator<DepartamentoUpdateDto>
{
    public DepartamentoUpdateValidator()
    {
        RuleFor(Departamento => Departamento.Descricao)
            .NotEmpty()
            .WithMessage("O Nome não pode estar vazio");

        RuleFor(Departamento => Departamento.Descricao)
            .NotEmpty()
            .WithMessage("A descrição não pode estar vazia");
    }
}
