using GmfApi.Models.Data;
using GmfApi.Models.Entities;
using GmfApi.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GmfApi.Models.Repository
{
    public class FuncionarioObraRepository : IFuncionarioObrasRepository
    {
        protected readonly GmfDbContext _dBContext;

        public FuncionarioObraRepository(GmfDbContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<FuncionarioObra> AddFuncionarioObra(FuncionarioObra funcionarioObra)
        {
            Funcionario? funcionario = await _dBContext.Funcionarios.Include(x => x.Cargo).FirstOrDefaultAsync(x => x.Id == funcionarioObra.Funcionario.Id);
            Obra? obra = await _dBContext.Obras.FirstOrDefaultAsync(x => x.Nome == funcionarioObra.Obra.Nome);
            if (funcionario == null || obra == null) 
            {
                funcionarioObra.Funcionario = funcionario;
                funcionarioObra.Obra = obra;
                return funcionarioObra;
            }
            else
            {
                funcionarioObra.Funcionario = funcionario;
                funcionarioObra.Obra = obra;
                _dBContext.FuncionarioObras.Add(funcionarioObra);
                await _dBContext.SaveChangesAsync();
                return funcionarioObra;
            }

            
        }

    }
}
