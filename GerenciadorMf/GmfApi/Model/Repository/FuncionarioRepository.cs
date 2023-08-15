using GmfApi.Models.Data;
using GmfApi.Models.Entities;
using GmfApi.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GmfApi.Models.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly GmfDbContext _dbContext;

        public FuncionarioRepository(GmfDbContext gmfDbContext) 
        { 
            _dbContext = gmfDbContext;
        }


        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            Cargo cargo = await _dbContext.Cargos.FirstOrDefaultAsync(x => x.Nome == funcionario.Cargo.Nome);
            
            if (cargo == null)
            {
                return funcionario;
            }
            else
            {
                funcionario.Cargo = cargo;
                await _dbContext.Funcionarios.AddAsync(funcionario);
                await _dbContext.SaveChangesAsync();

                return funcionario;
            }

         
        }

        public async Task<List<Funcionario>> GetAllFuncionarios()
        {
            return await _dbContext.Funcionarios.Include(x => x.Cargo).ToListAsync<Funcionario>();
        }

    }
}
