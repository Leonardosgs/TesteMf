using FluentValidation;
using GmfApi.Models.Data;
using GmfApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GmfApi.Model.Data.Validator
{
    public class FuncionarioObraValidator : AbstractValidator<FuncionarioObra>
    {

        protected readonly GmfDbContext _dBContext;
        public FuncionarioObraValidator(GmfDbContext dbContext) 
        {
            _dBContext = dbContext;

            RuleFor(x => x.Funcionario).NotNull().WithMessage("Funcionário não pode ser nulo");
            RuleFor(x => x.Obra).NotNull().WithMessage("Obra não pode ser nulo");
            RuleFor(x => x.Obra).Must(HasEncarregadoObraNaObra).WithMessage("A Obra ja pussui um Encarregado de Obra");
            RuleFor(x => x.DtInicio).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Data de início deve ser maior ou igual que a data atual");
            RuleFor(x => x.DtInicio).Must(HasDateEmConflito).WithMessage("Data inicial em conflito com outro período");
            RuleFor(x => x.DtFim).NotEmpty().GreaterThanOrEqualTo(x => x.DtInicio.Date).WithMessage("Data fim deve ser maior que a data inicial");
            RuleFor(x => x.DtFim).Must(HasDateEmConflito).WithMessage("Data final em conflito com outro período");
            RuleFor(x => x).Must(HasPeriodoEmConflito).WithMessage("Periodo selecionado em conflito com outo");

        }

        public  bool HasDateEmConflito(FuncionarioObra f, DateTime date)
        {
            FuncionarioObra? fo = _dBContext.FuncionarioObras.SingleOrDefault(x => x.Funcionario.Id == f.Funcionario.Id && DateTime.Compare(date.Date, x.DtInicio.Date) >= 0 && DateTime.Compare(date.Date, x.DtFim.Date) <= 0);
            if ( fo != null)
            {
                return false;
            }
            return true;
        }

        public bool HasPeriodoEmConflito(FuncionarioObra fo)
        {
            FuncionarioObra? f = _dBContext.FuncionarioObras.SingleOrDefault(x => (x.Funcionario.Id == fo.Funcionario.Id &&  DateTime.Compare(x.DtInicio.Date, fo.DtInicio.Date) >= 0 && DateTime.Compare(x.DtInicio.Date, fo.DtFim.Date) <= 0) ||
                                                                            x.Funcionario.Id == fo.Funcionario.Id && (DateTime.Compare(x.DtFim.Date, fo.DtInicio.Date) >= 0 && DateTime.Compare(x.DtFim.Date, fo.DtFim.Date) <= 0));
            if ( f != null)
            {
                return false;
            }
            return true;
        }

        public bool HasEncarregadoObraNaObra(FuncionarioObra fo, Obra obra)
        {
            FuncionarioObra? f = _dBContext.FuncionarioObras.SingleOrDefault(x => x.Obra.Nome == obra.Nome && x.Funcionario.Cargo.Nome.Equals("Encarregado de Obra"));
            if (f == null)
            {
                return true;
            }
            return false;
        }

    }
}
