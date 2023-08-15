using GmfApi.Models.Entities;

namespace GmfView.Service
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetFuncionarios();
        Task<Funcionario> AddFuncionario(Funcionario funcionario);
    }
}
