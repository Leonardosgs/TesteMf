using GmfApi.Models.Entities;

namespace GmfApi.Models.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<List<Funcionario>> GetAllFuncionarios();
        Task<Funcionario> AddFuncionario(Funcionario funcionario);
    }
}
