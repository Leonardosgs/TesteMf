using FluentValidation;
using FluentValidation.Validators;
using GmfApi.Models.Entities;

namespace GmfApi.Model.Data.Validator
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator() 
        { 
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100).MinimumLength(3).WithMessage("Erro ao inserir o nome");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("Data de nascimento nao pode ser vazia");
            RuleFor(x => x.Rg).NotEmpty().MinimumLength(4).MaximumLength(9).WithMessage("Erro ao inserir RG");
            RuleFor(x => x.Salario).NotEmpty().PrecisionScale(18, 2, false).WithMessage("Erro ao inserir Salario");
            RuleFor(x => x.Cargo).NotNull().WithMessage("Cargo Não encontrado");
        }
    }
}
