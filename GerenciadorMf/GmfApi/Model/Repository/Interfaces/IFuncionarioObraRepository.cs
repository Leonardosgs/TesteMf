using GmfApi.Models.Entities;

namespace GmfApi.Models.Repository.Interfaces
{
    public interface IFuncionarioObrasRepository
    {
        Task<FuncionarioObra> AddFuncionarioObra(FuncionarioObra funcionarioObra);
    }
}
